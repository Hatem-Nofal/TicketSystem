using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Common.Helpers.Errors.ValueObjects;
public static class PhoneErrors
{
    public static readonly Error Empty = new("Error.Empty", "Phone is empty");
    public static readonly Error InvalidFormate = new("Error.InvalidFormate", "phone Formate is invalid");


}
