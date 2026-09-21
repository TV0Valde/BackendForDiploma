namespace BackendForDiploma.Api.DTOs
{
    public record BuildingDto(
        Guid Id,
        string Name,
        string? Description,
        string ModelObjectKey,
        string ModelFormat,
        DateTime CreatedAt
    );

    public record UpdateBuildingRequest(
        string Name,
        string? Description,
        string? ModelObjectKey,
        string? ModelFormat
    );
}