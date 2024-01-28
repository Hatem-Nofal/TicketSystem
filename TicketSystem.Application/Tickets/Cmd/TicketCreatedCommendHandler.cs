using MediatR;
using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Tickets;

namespace TicketSystem.Application.Tickets.Cmd;
internal sealed class TicketCreatedCommendHandler : IRequestHandler<TicketCreatedCommend>
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketCreatedCommendHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TicketCreatedCommend request, CancellationToken cancellationToken)
    {
        var ticket = Ticket.Create(request.title, request.status, request.assingTo, request.describtion, request.originalEstimate, request.severity);

        _unitOfWork.Repository<Ticket>().Add(ticket);

        await _unitOfWork.CommitAsync();
    }
}
