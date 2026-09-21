using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Points.GetPointById
{
    public record GetPointByIdQuery(Guid Id) : IRequest<PointDto?>;

}
