using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Tickets.Enums;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{

    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        TicketConfigure(builder);
        TicketHistoryConfigure(builder);
        CommentConfigure(builder);

    }
    private void TicketConfigure(EntityTypeBuilder<Ticket> builder)
    {

        builder.ToTable("Tickets");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TicketId.Create(value));

        builder.Property(d => d.AssingTo)
               .ValueGeneratedNever()
               .HasConversion(
                   id => id.Value,
                   value => UserId.Create(value)).HasColumnName("AssingTo");
        builder.Property(d => d.CreatorId)
              .ValueGeneratedNever()
              .HasConversion(
                  id => id.Value,
                  value => UserId.Create(value)).HasColumnName("CreatorId");

        builder.Property(d => d.ModifierId)
           .ValueGeneratedNever()
           .HasConversion(
               id => id.Value,
               value => UserId.Create(value)).HasColumnName("ModifierId");

        builder.Property(m => m.Title).HasMaxLength(100);
        builder.Property(m => m.Describtion).HasMaxLength(250);
        builder.OwnsMany(c => c.DomainEvents);
        builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt");
        // builder.HasMany(d => d.Comments).WithOne().HasForeignKey(x => x.TicketId);

    }

    private void TicketHistoryConfigure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsMany(ticket => ticket.TicketHistories,
                        navigationBuilder =>
                        {
                            navigationBuilder.ToTable("TicketHistories");
                            navigationBuilder.Property(d => d.Status).ValueGeneratedNever()
                                    .HasConversion(
                                        id => id.Value,
                                        value => StatusEnum.FromValue(value)).HasColumnName("Status");

                            navigationBuilder.Property(d => d.AssingTo)
                                    .ValueGeneratedNever()
                                    .HasConversion(
                                        id => id.Value,
                                        value => UserId.Create(value)).HasColumnName("AssingTo");

                            navigationBuilder.Property(d => d.CreatorId)
                                  .ValueGeneratedNever()
                                  .HasConversion(
                                      id => id.Value,
                                      value => UserId.Create(value)).HasColumnName("CreatorId");

                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatedAt)
                                                                      .HasColumnName("CreatedAt");

                            navigationBuilder.Property(ticketHistory => ticketHistory.TicketId)
                                          .ValueGeneratedNever()
                                 .HasConversion(
                                   id => id.Value,
                                   value => TicketId.Create(value))
                                 .HasColumnName("TicketId");



                        });


    }
    private void CommentConfigure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsMany(ticket => ticket.Comments,
                        navigationBuilder =>
                        {
                            navigationBuilder.ToTable("Comments");
                            navigationBuilder.HasKey(d => d.Id);

                            navigationBuilder.Property(d => d.Id)
                                             .ValueGeneratedNever()
                                             .HasConversion(
                                                 id => id.Value,
                                                 value => CommentId.Create(value));
                            navigationBuilder.Property(d => d.CreatorId)
                                  .ValueGeneratedNever()
                                  .HasConversion(
                                      id => id.Value,
                                      value => UserId.Create(value)).HasColumnName("CreatorId");

                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatedAt)
                                                                      .HasColumnName("CreatedAt");

                            navigationBuilder.Property(ticketHistory => ticketHistory.TicketId)
                                          .ValueGeneratedNever()
                                 .HasConversion(
                                   id => id.Value,
                                   value => TicketId.Create(value))
                                 .HasColumnName("TicketId");

                            navigationBuilder.Property(d => d.ModifierId)
                             .ValueGeneratedNever()
                             .HasConversion(
                               id => id.Value,
                               value => UserId.Create(value))
                             .HasColumnName("ModifierId");

                            navigationBuilder.Property(m => m.Body).HasMaxLength(250);

                            navigationBuilder.OwnsMany(c => c.DomainEvents);

                        });


    }
}