using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Points.GetPointsByBuilding
{
    public record GetPointsByBuildingQuery(Guid BuildingId) : IRequest<List<PointDto>>;
}
