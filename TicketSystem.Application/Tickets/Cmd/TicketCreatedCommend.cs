using MediatR;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Application.Tickets.Cmd;
public sealed record TicketCreatedCommend(string title, int status, UserId assingTo, string describtion, decimal originalEstimate, int severity) : IRequest
{
}
