namespace BackendForDiploma.Api.DTOs
{
    public record PointDto(Guid Id, Guid BuildingId, string? SphereObjectName, float X, float Y, float Z, string? CurrentColor);
    public record CreatePointRequest(Guid? Id, string? SphereObjectName, float X, float Y, float Z, string? CurrentColor);
    public record UpdatePointRequest(string? SphereObjectName, float X, float Y, float Z, string? CurrentColor);
}