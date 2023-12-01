using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets;
public class Ticket : AggregateRoot<TicketId>
{
    public Ticket(TicketId id) : base(id)
    {
    }
}
