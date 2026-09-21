using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Buildings.GetBuildingId
{
    public class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, BuildingDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBuildingByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BuildingDto?> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.Buildings.GetByIdAsync(request.Id, cancellationToken);

            return building is null ? null : BuildingMapper.ToDto(building);
        }
    }
}
