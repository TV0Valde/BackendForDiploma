using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.UpdatePointRecord
{
    public record UpdatePointRecordCommand( Guid Id, string PhotoObjectKey, string InspectionDate, string State) : IRequest<PointRecordDto?>;
}
