using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets;
public sealed class Ticket(TicketId id) : AggregateRoot<TicketId>(id)
{
    public   string Title { get;private set; }
    public int Status { get; private set; }
    public Guid AssingTo { get; private set; }
    public string Describtion { get; private set; }
}
