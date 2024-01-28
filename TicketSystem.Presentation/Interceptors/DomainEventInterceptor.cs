using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TicketSystem.Presentation.Interceptors;
public sealed class DomainEventInterceptor : SaveChangesInterceptor
{


    public override async ValueTask<int> SavedChangesAsync
        (SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {

        return await base.SavedChangesAsync(eventData, result, cancellationToken);

    }

}
