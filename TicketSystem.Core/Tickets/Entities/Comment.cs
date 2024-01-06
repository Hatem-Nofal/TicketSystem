using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets.Entities;
public sealed class Comment : AggregateRoot<CommentId>
{
    private Comment() : base(null)
    {

    }
    private Comment(CommentId id) : base(id)
    {
    }

    public string Body { get; protected set; }
    public TicketId TicketId { get; protected set; }

    public static Comment Create(string Body, TicketId TicketId)
    {
        var comment = new Comment();
        comment.Body = Body;
        comment.TicketId = TicketId;
        comment.Raise(new CommentCreatedDomainEvent(Guid.NewGuid(), comment!.Id));
        return comment;

    }
    public void Update(string body)
    {
        Body = body;
    }
}
