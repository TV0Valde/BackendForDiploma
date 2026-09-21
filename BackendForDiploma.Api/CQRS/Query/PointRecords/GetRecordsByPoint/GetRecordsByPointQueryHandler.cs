using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.PointRecords.GetRecordsByPoint
{
    public class GetRecordsByPointQueryHandler : IRequestHandler<GetRecordsByPointQuery, List<PointRecordDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRecordsByPointQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PointRecordDto>> Handle(GetRecordsByPointQuery request, CancellationToken cancellationToken)
        {
            var records = await _unitOfWork.PointRecords.GetByPointIdAsync(request.PointId, cancellationToken);

            return records.Select(PointRecordMapper.ToDto).ToList();
        }
    }
}
