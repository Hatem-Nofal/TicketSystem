using Microsoft.EntityFrameworkCore;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Users;
using TicketSystem.Infrastructure.EntityConfigurations.Tickets;

namespace TicketSystem.Infrastructure.Context;
public class TicketSystemDbContext : DbContext
{



    public TicketSystemDbContext()
    {

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


}



