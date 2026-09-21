using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Buildings.GetBuildingId
{
    public record GetBuildingByIdQuery(Guid Id) : IRequest<BuildingDto?>;
}
