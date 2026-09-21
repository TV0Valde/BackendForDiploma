using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.UpdatePointCommand
{
    public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand, PointDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePointCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointDto?> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
        {
            var point = await _unitOfWork.Points.GetByIdAsync(request.Id, cancellationToken);
            if (point is null) return null;

            point.SphereObjectName = request.SphereObjectName;
            point.X = request.X;
            point.Y = request.Y;
            point.Z = request.Z;
            point.CurrentColor = request.CurrentColor;

            _unitOfWork.Points.Update(point);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return PointMapper.ToDto(point);
        }
    }
}
