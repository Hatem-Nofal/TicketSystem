using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Tickets.Cmd;
using TicketSystem.Application.Tickets.Events;
using TicketSystem.Domain.Common.Helpers;
using TicketSystem.Domain.Tickets.Events;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Application.IoC
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection ApplicationServiceConfiguration(this IServiceCollection services, IConfiguration configuratio)
        {

            services.AddScoped<IRequestHandler<TicketCreatedCommend, Result<TicketId>>, TicketCreatedCommendHandler>();

            services.AddTransient<INotificationHandler<TicketCreatedDomainEvent>, TicketCreatedDomainEventHandler>();
            services.AddTransient<INotificationHandler<CommentCreatedDomainEvent>, CommentCreatedDomainEventHandler>();
            services.AddTransient<INotificationHandler<CommentUpdatedDomainEvent>, CommentUpdatedDomainEventHandler>();
            services.AddTransient<INotificationHandler<TicketUpdatedDomainEvent>, TicketUpdatedDomainEventHandler>();

            return services;

        }
    }
}
