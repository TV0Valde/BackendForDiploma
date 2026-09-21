using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.PointRecords.CreatePointRecord
{
    public class CreatePointRecordCommandHandler : IRequestHandler<CreatePointRecordCommand, PointRecordDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePointRecordCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointRecordDto?> Handle(CreatePointRecordCommand request, CancellationToken cancellationToken)
        {
            var point = await _unitOfWork.Points.GetByIdAsync(request.PointId, cancellationToken);

            if (point is null) return null;

            var record = new PointRecord
            {
                Id = request.Id ?? Guid.NewGuid(),
                PointId = request.PointId,
                PhotoObjectKey = request.PhotoObjectKey,
                InspectionDate = request.InspectionDate,
                State = request.State
            };

            await _unitOfWork.PointRecords.AddAsync(record, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return PointRecordMapper.ToDto(record);
        }
    }
}
