using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Buildings.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, BuildingDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBuildingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BuildingDto> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = new Building
            {
                Id = request.Id ?? Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ModelObjectKey = request.ModelObjectKey ?? string.Empty,
                ModelFormat = request.ModelFormat ?? "glb"
            };

            await _unitOfWork.Buildings.AddAsync(building, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return BuildingMapper.ToDto(building);
        }
    }
}
