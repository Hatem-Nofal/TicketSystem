using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets;
public sealed class Ticket : AggregateRoot<TicketId>
{

    private Ticket() : base(null)
    {

    }
    private Ticket(TicketId id) : base(id)
    {

    }
    public string Title { get; protected set; }
    public int Status { get; protected set; }
    public UserId AssingTo { get; protected set; }
    public string Describtion { get; protected set; }
    private List<Comment> _comments = new();
    private List<TicketHistory> _ticketHistories = new();

    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyList<TicketHistory> TicketHistories => _ticketHistories.AsReadOnly();
    //private Ticket(TicketId id, string title, int status, UserId assingTo, string describtion, List<Comment> comments, List<TicketHistory> ticketHistories) : base(id)
    //{
    //    Title = title;
    //    Status = status;
    //    AssingTo = assingTo;
    //    Describtion = describtion;
    //    _comments = comments;
    //    _ticketHistories = ticketHistories;
    //}

    public Ticket Create(string title, int status, UserId assingTo, string describtion, List<Comment> comments, List<TicketHistory> ticketHistories)
    {
        var ticket = new Ticket(TicketId.CreateUnique());
        ticket.Title = title;
        ticket.Status = status;
        ticket.AssingTo = assingTo;
        ticket.Describtion = describtion;
        ticket._comments = comments;
        ticket._ticketHistories = ticketHistories;
        ticket.Raise(new TicketCreatedDomainEvent(Guid.NewGuid(), ticket!.Id));
        return ticket;

    }


}
