using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.CreatePointCommand
{
    public record CreatePointCommand(
        Guid? Id,
        Guid BuildingId,
        string? SphereObjectName,
        float X, float Y, float Z,
        string? CurrentColor
    ) : IRequest<PointDto?>;
}