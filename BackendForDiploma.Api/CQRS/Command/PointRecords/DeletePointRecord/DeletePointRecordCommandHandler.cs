using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.DeletePointRecord
{
    public class DeletePointRecordCommandHandler : IRequestHandler<DeletePointRecordCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePointRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePointRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.PointRecords.GetByIdAsync(request.Id, cancellationToken);

            if (record is null) return false;

            _unitOfWork.PointRecords.Delete(record);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
