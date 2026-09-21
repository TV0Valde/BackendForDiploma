using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Buildings.CreateBuilding
{
    /// <summary>
    /// Команда добавления здания
    /// </summary>
    public record CreateBuildingCommand(
        Guid? Id,
        string Name,
        string? Description,
        string? ModelObjectKey,
        string? ModelFormat
    ) : IRequest<BuildingDto>;
}
