using MediatR;

namespace TicketSystem.Domain.Common.Primitives
{
    /// <summary>
    /// Represents the event interface.
    /// </summary>
    public interface IEvent : INotification
    {
    }
}