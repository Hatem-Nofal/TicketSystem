namespace TicketSystem.Presentation.BackgroundJobs;

public interface IprocessOutboxMessagesJob
{
    Task Execute(CancellationToken cancellationToken = default);
}