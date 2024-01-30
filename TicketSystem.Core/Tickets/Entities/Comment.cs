using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets.Entities;
public sealed class Comment : Entity<CommentId>
{
    private Comment() : base(null)
    {

    }
    private Comment(CommentId id) : base(id)
    {
    }

    public string Body { get; protected set; }
    public TicketId TicketId { get; protected set; }
    public Ticket Ticket { get; protected set; }

    public static Comment Create(string Body, TicketId TicketId, UserId CreatorId)
    {
        var comment = new Comment(CommentId.CreateUnique());
        comment.Body = Body;
        comment.TicketId = TicketId;
        comment.CreatorId = CreatorId;
        comment.Raise(new CommentCreatedDomainEvent(Guid.NewGuid(), comment!.Id.Value));
        return comment;

    }
    public void Update(string body) => Body = body;
}
