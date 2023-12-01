﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Domain.Common.Helpers.Errors;
public static class EmailErrors
{
    public static readonly Error Empty = new("Error.Empty", "Email is empty");
    public static readonly Error InvalidFormate = new("Error.InvalidFormate", "Email Formate is invalid");


}
