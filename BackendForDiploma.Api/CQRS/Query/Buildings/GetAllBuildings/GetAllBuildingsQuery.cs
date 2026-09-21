using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Buildings.GetAllBuildings
{
    public record GetAllBuildingsQuery : IRequest<List<BuildingDto>>;
}
