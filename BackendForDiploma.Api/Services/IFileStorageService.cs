namespace BackendForDiploma.Api.Services;

public interface IFileStorageService
{
    /// <summary>
    /// Загрузка объёкта в хранилище
    /// </summary>
    Task<string> UploadAsync(string bucket, string objectKey, Stream data, string contentType, CancellationToken ct = default);

    /// <summary>
    /// Скачивание объекта из хранилища
    /// </summary>
    Task<Stream> DownloadAsync(string bucket, string objectKey, CancellationToken ct = default);

    /// <summary>
    /// Получение временной ссылки на объект в хранилище
    /// </summary>
    Task<string> GetPresignedUrlAsync(string bucket, string objectKey, int expirySeconds = 3600);

    /// <summary>
    /// Удаление объекта из хранилища
    /// </summary>
    Task DeleteAsync(string bucket, string objectKey, CancellationToken ct = default);

    /// <summary>
    /// Проверка существования бакета и создание его при необходимости
    /// </summary>
    Task EnsureBucketExistsAsync(string bucket);
}