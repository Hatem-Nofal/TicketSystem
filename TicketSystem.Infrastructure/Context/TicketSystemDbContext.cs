using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Users;
using TicketSystem.Infrastructure.EntityConfigurations.Tickets;

namespace TicketSystem.Infrastructure.Context;
public class TicketSystemDbContext : DbContext
{

    private readonly IPublisher _publisher;


    public TicketSystemDbContext()
    {

    }
    public TicketSystemDbContext(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public TicketSystemDbContext(DbContextOptions<TicketSystemDbContext> options)
      : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Database=TicketSystemDb; Trusted_Connection=True; TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {



        builder.ApplyConfiguration(new TicketConfiguration());
        // builder.ApplyConfiguration(new CommentsConfiguration());
        builder.ApplyConfiguration(new UsersConfiguration());

        base.OnModelCreating(builder);
    }

    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int res = await base.SaveChangesAsync(cancellationToken);


        await PublishDomainEvents();

        return res;
    }

    private async Task PublishDomainEvents()
    {

        var domainEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(x => x.Entity)
            .SelectMany(e =>
            {
                List<DomainEvent> domainEvents = e.DomainEvents.ToList();
                e.ClearDomainEvents();
                return domainEvents;
            }).ToList();
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }

}

