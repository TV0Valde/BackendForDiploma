using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Points.GetPointsByBuilding
{
    public class GetPointsByBuildingQueryHandler : IRequestHandler<GetPointsByBuildingQuery, List<PointDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPointsByBuildingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PointDto>> Handle(GetPointsByBuildingQuery request, CancellationToken cancellationToken)
        {
            var points = await _unitOfWork.Points.GetByBuildingIdAsync(request.BuildingId, cancellationToken);

            return points.Select(PointMapper.ToDto).ToList();
        }
    }
}
