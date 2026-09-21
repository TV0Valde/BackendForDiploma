using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.UpdatePointCommand
{
    public record UpdatePointCommand(Guid Id, string? SphereObjectName, float X, float Y, float Z, string? CurrentColor) : IRequest<PointDto?>;
}
