using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Tickets.Enums;
public enum StatusEnum
{
    [Description(nameof(StatusEnum.New))]
    New = 1,

    [Description(nameof(StatusEnum.Active))]
    Active = 2,

    [Description(nameof(StatusEnum.Resolved))]
    Resolved = 3,

    [Description(nameof(StatusEnum.Closed))]
    Closed = 4,

    [Description(nameof(StatusEnum.Removed))]
    Removed = 5,

}
