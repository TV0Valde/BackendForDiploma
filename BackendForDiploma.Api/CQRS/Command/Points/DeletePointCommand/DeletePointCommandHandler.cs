using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.DeletePointCommand
{
    public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePointCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePointCommand request, CancellationToken cancellationToken)
        {
            var point = await _unitOfWork.Points.GetByIdAsync(request.Id, cancellationToken);

            if (point is null) return false;

            _unitOfWork.Points.Delete(point);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
