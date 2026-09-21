using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.PointRecords.GetPointRecordById
{
    public class GetPointRecordByIdQueryHandler : IRequestHandler<GetPointRecordByIdQuery, PointRecordDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPointRecordByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointRecordDto?> Handle(GetPointRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.PointRecords.GetByIdAsync(request.Id, cancellationToken);

            return record is null ? null : PointRecordMapper.ToDto(record);
        }
    }
}
