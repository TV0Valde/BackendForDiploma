using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.UpdatePointRecord
{
    public class UpdatePointRecordCommandHandler : IRequestHandler<UpdatePointRecordCommand, PointRecordDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePointRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointRecordDto?> Handle(UpdatePointRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.PointRecords.GetByIdAsync(request.Id, cancellationToken);

            if (record is null) return null;

            record.PhotoObjectKey = request.PhotoObjectKey;
            record.InspectionDate = request.InspectionDate;
            record.State = request.State;

            _unitOfWork.PointRecords.Update(record);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return PointRecordMapper.ToDto(record);
        }
    }
}
