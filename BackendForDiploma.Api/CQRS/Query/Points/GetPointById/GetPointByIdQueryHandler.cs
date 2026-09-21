using BackendForDiploma.Api.DTOs;
using BackendForDiploma.Api.Infrastucture.UnitOfWork;
using BackendForDiploma.Api.Mappers;
using MediatR;

namespace BackendForDiploma.Api.CQRS.Query.Points.GetPointById
{
    public class GetPointByIdQueryHandler : IRequestHandler<GetPointByIdQuery, PointDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPointByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PointDto?> Handle(GetPointByIdQuery request, CancellationToken cancellationToken)
        {
            var point = await _unitOfWork.Points.GetByIdAsync(request.Id, cancellationToken);

            return point is null ? null : PointMapper.ToDto(point);
        }
    }
}
