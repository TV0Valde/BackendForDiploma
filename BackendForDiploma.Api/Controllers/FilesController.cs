using BackendForDiploma.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackendForDiploma.Api.Controllers;

/// <summary>
/// Контроллер для работы с файлами (фото и 3D-модели)
/// </summary>
[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IFileStorageService _storage;
    private readonly MinioSettings _settings;

    public FilesController(IFileStorageService storage, IOptions<MinioSettings> settings)
    {
        _storage = storage;
        _settings = settings.Value;
    }

    /// <summary>
    /// Загрузка фото записи осмотра
    /// </summary>
    [HttpPost("photos/{recordId:guid}")]
    [RequestSizeLimit(50_000_000)]
    public async Task<ActionResult<string>> UploadPhoto(Guid recordId, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не передан.");

        var ext = Path.GetExtension(file.FileName);
        var objectKey = $"photos/{recordId}{ext}";

        using var stream = file.OpenReadStream();
        await _storage.UploadAsync(_settings.PhotosBucket, objectKey, stream, file.ContentType);

        return Ok(objectKey);
    }

    /// <summary>
    /// Загрузка 3D-модели здания
    /// </summary>
    [HttpPost("models/{buildingId:guid}")]
    [RequestSizeLimit(500_000_000)]
    public async Task<ActionResult<string>> UploadModel(Guid buildingId, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не передан.");

        var ext = Path.GetExtension(file.FileName);
        var objectKey = $"models/{buildingId}{ext}";

        using var stream = file.OpenReadStream();
        await _storage.UploadAsync(_settings.ModelsBucket, objectKey, stream, file.ContentType);

        return Ok(objectKey);
    }

    /// <summary>
    /// Получить presigned URL для скачивания фото
    /// </summary>
    [HttpGet("photos/url")]
    public async Task<ActionResult<string>> GetPhotoUrl([FromQuery] string objectKey)
    {
        if (string.IsNullOrEmpty(objectKey))
            return BadRequest("objectKey обязателен");

        var url = await _storage.GetPresignedUrlAsync(_settings.PhotosBucket, objectKey);

        return Ok(url);
    }

    /// <summary>
    /// Получить presigned URL для скачивания модели
    /// </summary>
    [HttpGet("models/{buildingId:guid}/url")]
    public async Task<ActionResult<string>> GetModelUrl(Guid buildingId, [FromQuery] string ext = ".glb")
    {
        var objectKey = $"models/{buildingId}{ext}";
        var url = await _storage.GetPresignedUrlAsync(_settings.ModelsBucket, objectKey);

        return Ok(url);
    }

    /// <summary>
    /// Скачать фото через backend (для случаев когда presigned URL не подходит)
    /// </summary>
    [HttpGet("photos/{recordId:guid}/download")]
    public async Task<IActionResult> DownloadPhoto(Guid recordId, [FromQuery] string ext = ".jpg")
    {
        var objectKey = $"photos/{recordId}{ext}";
        var stream = await _storage.DownloadAsync(_settings.PhotosBucket, objectKey);

        return File(stream, "image/jpeg", $"{recordId}{ext}");
    }
}