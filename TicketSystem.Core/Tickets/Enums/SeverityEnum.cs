using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Activity;

namespace TicketSystem.Domain.Tickets.Enums;
 public sealed class SeverityEnum : Enumeration<SeverityEnum>
{
    public static readonly SeverityEnum Critical = new(1, "1-Critical");
    public static readonly SeverityEnum High = new(2, "2-High");
    public static readonly SeverityEnum Medium = new(3, "3-Medium");
    public static readonly SeverityEnum Low = new(4, "4-Low");


    public SeverityEnum(int value, string name) : base(value,name )
    {
    }
}