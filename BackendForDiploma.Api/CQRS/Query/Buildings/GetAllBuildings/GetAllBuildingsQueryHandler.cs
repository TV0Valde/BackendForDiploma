using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Buildings.GetAllBuildings
{
    public class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, List<BuildingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBuildingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BuildingDto>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            var buildings = await _unitOfWork.Buildings.GetAllAsync(cancellationToken);

            return buildings.Select(BuildingMapper.ToDto).ToList();
        }
    }
}
