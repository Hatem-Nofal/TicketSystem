using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Tickets.Enums;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
public sealed class TicketHistory : ValueObject
{
    public TicketId TicketId { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public UserId AssingTo { get; protected set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
     

    public static TicketHistory Create(StatusEnum Status, TicketId TicketId, UserId AssingTo)
    {
        var ticketHistory = new TicketHistory();
        ticketHistory.Status = Status;
        ticketHistory.TicketId = TicketId;
        ticketHistory.AssingTo = AssingTo;
        return ticketHistory;

    }
}
