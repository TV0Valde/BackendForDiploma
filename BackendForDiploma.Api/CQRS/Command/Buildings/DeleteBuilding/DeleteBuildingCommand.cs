using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Buildings.DeleteBuilding
{
    public record DeleteBuildingCommand(Guid Id) : IRequest<bool>;
}
