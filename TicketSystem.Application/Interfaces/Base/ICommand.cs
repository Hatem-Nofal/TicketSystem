using Gatherly.Domain.Shared;
using MediatR;

namespace TicketSystem.Application.Interfaces.Base;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
