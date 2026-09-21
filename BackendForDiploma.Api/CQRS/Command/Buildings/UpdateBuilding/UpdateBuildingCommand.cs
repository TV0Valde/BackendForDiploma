using BackendForDiploma.Api.DTOs;
using MediatR;

public record UpdateBuildingCommand(
    Guid Id,
    string Name,
    string? Description,
    string? ModelObjectKey,
    string? ModelFormat
) : IRequest<BuildingDto?>;