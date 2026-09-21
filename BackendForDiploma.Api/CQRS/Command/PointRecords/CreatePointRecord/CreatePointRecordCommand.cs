using BackendForDiploma.Api.DTOs;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.CreatePointRecord
{
    public record CreatePointRecordCommand(
        Guid? Id,
        Guid PointId,
        string PhotoObjectKey,
        string InspectionDate,
        string State
    ) : IRequest<PointRecordDto?>;
}