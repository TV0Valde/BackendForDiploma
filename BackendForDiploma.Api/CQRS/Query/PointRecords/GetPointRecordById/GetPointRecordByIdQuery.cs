using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.PointRecords.GetPointRecordById
{
    public record GetPointRecordByIdQuery(Guid Id) : IRequest<PointRecordDto?>;
}
