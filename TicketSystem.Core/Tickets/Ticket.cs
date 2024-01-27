using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.Entities;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets;
public sealed class Ticket : AggregateRoot<TicketId>
{

    private Ticket() : base(null) { }
    private Ticket(TicketId id) : base(id) { }
    public string Title { get; init; }
    public int Status { get; protected set; }
    public UserId AssingTo { get; protected set; }
    public string Describtion { get; protected set; }
    public decimal OriginalEstimate { get; init; }
    public decimal RemainingWork { get; protected set; }
    public decimal CompletedWork { get; protected set; }
    public int Severity { get; protected set; }




    private HashSet<Comment> _comments = new();
    private HashSet<TicketHistory> _ticketHistories = new();

    public Lazy<IReadOnlyList<Comment>> Comments => new Lazy<IReadOnlyList<Comment>>(_comments.ToList());
    public Lazy<IReadOnlyList<TicketHistory>> TicketHistories => new Lazy<IReadOnlyList<TicketHistory>>(_ticketHistories.ToList());


    public Ticket Create(string title, int status, UserId assingTo, string describtion, decimal originalEstimate, int severity)
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
    public Ticket Update(string title, int status, UserId assingTo, string describtion, decimal originalEstimate, int severity)
    {

        var ticket = new Ticket()
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
        ticket.Raise(new TicketUpdatedDomainEvent(Guid.NewGuid(), ticket!.Id));
        return ticket;

    }
    public void CreateTicketHistory()
    {
        var ticketHistory = TicketHistory.Create(Status, Id, AssingTo, CreatorId);
        _ticketHistories.Add(ticketHistory);
    }

    public void CreateComment(string Body)
    {
        var comment = Comment.Create(Body, Id, CreatorId);
        _comments.Add(comment);
    }
    public void RemoveComment(CommentId commentId)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
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

