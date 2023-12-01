using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Users.Events;
public  record UserCreatedDomainEvent(Guid Id, UserId UserId): DomainEvent(Id);
 
