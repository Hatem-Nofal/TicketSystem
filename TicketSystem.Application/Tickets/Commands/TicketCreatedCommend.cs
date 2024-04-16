using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Application.Tickets.Cmd;
public sealed record TicketCreatedCommend
    (
    string title,
    int status,
    Guid assingTo,
    string describtion,
    decimal originalEstimate,
    int severity)
    : ICommand<TicketId>
{
}
