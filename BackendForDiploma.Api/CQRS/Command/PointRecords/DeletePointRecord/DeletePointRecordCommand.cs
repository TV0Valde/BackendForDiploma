using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.DeletePointRecord
{
    public record DeletePointRecordCommand(Guid Id) : IRequest<bool>;
}
