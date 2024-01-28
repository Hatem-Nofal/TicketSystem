using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Tickets.Enums;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;

public sealed class TicketHistory : ValueObject
{


    public TicketId TicketId { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public UserId AssingTo { get; protected set; }
    public UserId CreatorId { get; protected set; }
    public Ticket Ticket { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return new TicketHistory();
    }

    public static TicketHistory Create(StatusEnum Status, TicketId TicketId, UserId AssingTo, UserId CreatorId)
    {
        var ticketHistory = new TicketHistory()
        {
            Status = Status,
            TicketId = TicketId,
            AssingTo = AssingTo,
            CreatorId = CreatorId

        };
        return ticketHistory;

    }

    internal static TicketHistory Create(int status, TicketId id, UserId assingTo, UserId creatorId)
    {
        throw new NotImplementedException();
    }
}
