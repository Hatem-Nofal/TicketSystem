using Shared.Helpers;

namespace TicketSystem.Domain.Tickets.Enums;

public sealed class StatusEnum : Enumeration<StatusEnum>
{
    public static readonly StatusEnum New = new(1, "New");
    public static readonly StatusEnum Active = new(2, "Active");
    public static readonly StatusEnum Resolved = new(3, "Resolved");
    public static readonly StatusEnum Closed = new(4, "Closed");
    public static readonly StatusEnum Removed = new(5, "Removed");

    public StatusEnum(int value, string name) : base(value, name)
    {
    }
}