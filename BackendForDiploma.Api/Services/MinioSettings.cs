namespace BackendForDiploma.Api.Services;

public class MinioSettings
{
    public string Endpoint { get; set; } = "localhost:9000";
    public string AccessKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public bool UseSsl { get; set; } = false;
    public string PhotosBucket { get; set; } = "building-photos";
    public string ModelsBucket { get; set; } = "building-models";
}