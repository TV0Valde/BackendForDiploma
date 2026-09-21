using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.CreatePointCommand
{
    public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, PointDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePointCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointDto?> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var buildingExists = await _unitOfWork.Buildings.GetByIdAsync(request.BuildingId, cancellationToken);

            if (buildingExists is null) return null;

            var point = new Point
            {
                Id = request.Id ?? Guid.NewGuid(),
                BuildingId = request.BuildingId,
                SphereObjectName = request.SphereObjectName,
                X = request.X,
                Y = request.Y,
                Z = request.Z,
                CurrentColor = request.CurrentColor
            };

            await _unitOfWork.Points.AddAsync(point, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return PointMapper.ToDto(point);
        }
    }
}
