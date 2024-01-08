using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.Entities;
using TicketSystem.Domain.Tickets.Enums;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets;
public sealed class Ticket : AggregateRoot<TicketId>
{

    private Ticket() : base(null){}
    private Ticket(TicketId id) : base(id){}
    public string Title { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public UserId AssingTo { get; protected set; }
    public string Describtion { get; protected set; }
    public decimal OriginalEstimate { get; protected set; }
    public decimal RemainingWork { get; protected set; }
    public decimal CompletedWork { get; protected set; }
    public SeverityEnum Severity { get; protected set; }




    private HashSet<Comment> _comments = new();
    private HashSet<TicketHistory> _ticketHistories = new();

    public IReadOnlyList<Comment> Comments => _comments.ToList();
    public IReadOnlyList<TicketHistory> TicketHistories => _ticketHistories.ToList();


    public Ticket Create(string title, StatusEnum status, UserId assingTo, string describtion, decimal originalEstimate, SeverityEnum severity)
    {
        var ticket = new Ticket(TicketId.CreateUnique())
        {
            Title = title,
            Status = status,
            AssingTo = assingTo,
            Describtion = describtion,
            OriginalEstimate = originalEstimate,
            RemainingWork = default,
            Severity = severity,
            CompletedWork = default

        };
        CreateTicketHistory();
        ticket.Raise(new TicketCreatedDomainEvent(Guid.NewGuid(), ticket!.Id));
        return ticket;

    }
    public Ticket Update(Ticket Updatedticket)
    {

        var ticket = new Ticket(TicketId.Create(Updatedticket.Id.Value))
        {
            Title = Updatedticket.Title,
            Status = Updatedticket.Status,
            AssingTo = Updatedticket.AssingTo,
            Describtion = Updatedticket.Describtion,
            OriginalEstimate = Updatedticket.OriginalEstimate,
            RemainingWork = Updatedticket.RemainingWork,
            Severity = Updatedticket.Severity,
            CompletedWork = Updatedticket.CompletedWork,
            _comments = Updatedticket._comments
        };
        CreateTicketHistory();
        ticket.Raise(new TicketUpdatedDomainEvent(Guid.NewGuid(), ticket!.Id));
        return ticket;

    }
    public void CreateTicketHistory()
    {
         var ticketHistory = TicketHistory.Create(Status, Id, AssingTo,CreatorId);
        _ticketHistories.Add(ticketHistory);
    }
    public void CreateComment(string Body)
    {
        var comment = Comment.Create(Body, Id,CreatorId);
        _comments.Add(comment);
    }
    public void RemoveComment(Comment comment)
    {
        if (comment is null)
            return;
        _comments.Remove(comment);
    }

    public void UpdateComment(CommentId commentId, string Body)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment is null)
            return;
        comment.Update(Body);
    }
}
