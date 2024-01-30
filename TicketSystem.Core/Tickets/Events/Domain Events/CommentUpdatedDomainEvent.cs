﻿using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Tickets.Events;
public sealed record CommentUpdatedDomainEvent(Guid Id, Guid CommentId) : DomainEvent(Id);

