using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Tickets.Enums;
public enum SeverityEnum
{
    [Description("1-Critical")]
    Critical = 1,

    [Description("2-High")]
    High = 2,

    [Description("3-Medium")]
    Medium = 3,

    [Description("4-Low")]
    Low = 4
}
