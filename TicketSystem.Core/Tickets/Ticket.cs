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
    public string Title { get; set; }
    public int Status { get; set; }
    public Guid AssingTo { get; set; }
    public string Describtion { get; set; }
}
