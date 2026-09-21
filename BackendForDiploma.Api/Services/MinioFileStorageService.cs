using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;

namespace BackendForDiploma.Api.Services;

/// <summary>
/// Сервис для работы с файловым хранилищем MinIO
/// </summary>
public class MinioFileStorageService : IFileStorageService
{
    private readonly IMinioClient _client;

    public MinioFileStorageService(IOptions<MinioSettings> options)
    {
        var s = options.Value;
        _client = new MinioClient()
            .WithEndpoint(s.Endpoint)
            .WithCredentials(s.AccessKey, s.SecretKey)
            .WithSSL(s.UseSsl)
            .Build();
    }

    public async Task EnsureBucketExistsAsync(string bucket)
    {
        var exists = await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket));
        if (!exists)
            await _client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucket));
    }

    public async Task<string> UploadAsync(string bucket, string objectKey, Stream data, string contentType, CancellationToken ct = default)
    {
        await EnsureBucketExistsAsync(bucket);

        var args = new PutObjectArgs()
            .WithBucket(bucket)
            .WithObject(objectKey)
            .WithStreamData(data)
            .WithObjectSize(data.Length)
            .WithContentType(contentType);

        await _client.PutObjectAsync(args, ct);
        return objectKey;
    }

    public async Task<Stream> DownloadAsync(string bucket, string objectKey, CancellationToken ct = default)
    {
        var ms = new MemoryStream();

        var args = new GetObjectArgs()
            .WithBucket(bucket)
            .WithObject(objectKey)
            .WithCallbackStream(stream => stream.CopyTo(ms));

        await _client.GetObjectAsync(args, ct);
        ms.Position = 0;
        return ms;
    }

    public async Task<string> GetPresignedUrlAsync(string bucket, string objectKey, int expirySeconds = 3600)
    {
        var args = new PresignedGetObjectArgs()
            .WithBucket(bucket)
            .WithObject(objectKey)
            .WithExpiry(expirySeconds);

        return await _client.PresignedGetObjectAsync(args);
    }

    public async Task DeleteAsync(string bucket, string objectKey, CancellationToken ct = default)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(bucket)
            .WithObject(objectKey);

        await _client.RemoveObjectAsync(args, ct);
    }
}