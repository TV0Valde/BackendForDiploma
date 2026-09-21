using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Buildings.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBuildingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _unitOfWork.Buildings.GetByIdAsync(request.Id, cancellationToken);
            if (building is null) return false;

            _unitOfWork.Buildings.Delete(building);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
