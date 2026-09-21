using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.PointRecords.GetRecordsByPoint
{
    public record GetRecordsByPointQuery(Guid PointId) : IRequest<List<PointRecordDto>>;
}
