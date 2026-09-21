using MediatR;

namespace BackendForDiploma.Api.CQRS.Command.Points.DeletePointCommand
{
    public record DeletePointCommand(Guid Id) : IRequest<bool>;
}
