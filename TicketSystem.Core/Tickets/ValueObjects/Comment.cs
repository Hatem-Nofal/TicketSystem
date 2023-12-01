using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
public sealed class Comment : ValueObject
{
    public string Body { get; set; }
    public TicketId TicketId { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
