using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.Entities;
using TicketSystem.Domain.Tickets.Enums;
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
    private List<Comment> _comments = new();
    private List<TicketHistory> _ticketHistories = new();

    public IReadOnlyList<Comment> Comments => _comments.ToList();
    public IReadOnlyList<TicketHistory> TicketHistories => _ticketHistories.ToList();



    public static Ticket Create(string title, int status, UserId assingTo, string describtion, decimal originalEstimate, int severity)
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
            CompletedWork = default,
            CreatorId = assingTo,
            ModifierId = assingTo


        };
        ticket.CreateTicketHistory(status, ticket!.Id, assingTo, ticket!.CreatorId);
        ticket.Raise(new TicketCreatedDomainEvent(ticket!.Id.Value));
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
        ticket.CreateTicketHistory(status, ticket!.Id, assingTo, ticket!.CreatorId);
        ticket.Raise(new TicketUpdatedDomainEvent(ticket!.Id.Value));
        return ticket;

    }
    public void CreateTicketHistory(int status, TicketId id, UserId assingTo, UserId creatorId)
    {
        var ticketHistory = TicketHistory.Create(StatusEnum.FromValue(status)!, id, assingTo, creatorId);

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

    public Lazy<IReadOnlyList<Comment>> GetComments()
    {
        return new Lazy<IReadOnlyList<Comment>>(_comments.ToList());
    }
    public Lazy<IReadOnlyList<TicketHistory>> GetTicketHistory()
    {
        return new Lazy<IReadOnlyList<TicketHistory>>(_ticketHistories.ToList());
    }
}

