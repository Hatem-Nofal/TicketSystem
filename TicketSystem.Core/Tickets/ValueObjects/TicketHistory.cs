using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public UserId CreatorId { get; protected set; }
    public Ticket Ticket { get; set; }

    public override IEnumerable<object> GetEqualityComponents() => throw new NotImplementedException();


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
}
