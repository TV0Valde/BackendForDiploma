using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Buildings.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, BuildingDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBuildingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BuildingDto?> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.Buildings.GetByIdAsync(request.Id, cancellationToken);

            if (building is null) return null;

            building.Name = request.Name;
            building.Description = request.Description;

            if (request.ModelObjectKey is not null)
                building.ModelObjectKey = request.ModelObjectKey;

            if (request.ModelFormat is not null)
                building.ModelFormat = request.ModelFormat;

            _unitOfWork.Buildings.Update(building);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BuildingMapper.ToDto(building);
        }
    }
}