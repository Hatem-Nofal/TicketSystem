using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Tickets.Enums;
 
public sealed class StatusEnum : Enumeration<StatusEnum>
{
    public static readonly SeverityEnum New = new(1, "New");
    public static readonly SeverityEnum Active = new(2, "Active");
    public static readonly SeverityEnum Resolved = new(3, "Resolved");
    public static readonly SeverityEnum Closed = new(4, "Closed");
    public static readonly SeverityEnum Removed = new(4, "Removed");

    public StatusEnum(int value, string name) : base(value, name)
    {
    }
}