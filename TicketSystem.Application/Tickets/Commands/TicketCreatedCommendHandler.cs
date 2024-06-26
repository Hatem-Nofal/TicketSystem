﻿using Gatherly.Domain.Shared;
using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Application.Tickets.Cmd;
internal sealed class TicketCreatedCommendHandler : ICommandHandler<TicketCreatedCommend, TicketId>
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketCreatedCommendHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TicketId>> Handle(TicketCreatedCommend request, CancellationToken cancellationToken)
    {
        var ticket = Ticket.Create(request.title, request.status, UserId.Create(request.assingTo), request.describtion, request.originalEstimate, request.severity);

        try
        {
            _unitOfWork.Repository<Ticket>().Add(ticket);

            await _unitOfWork.CommitAsync();

            return ticket.Id;

        }
        catch (Exception e)
        {

            throw;
        }
    }
}
