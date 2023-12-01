using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
public sealed class TicketHistory : ValueObject
{
    public TicketId TicketId { get; set; }
    public int Status { get; set; }
    public Guid AssingTo { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
