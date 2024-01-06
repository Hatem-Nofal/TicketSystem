using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{

    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        TicketConfigure(builder);
        TicketHistoryConfigure(builder);

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
        builder.HasMany(d => d.Comments).WithOne().HasForeignKey(x => x.TicketId);
        //builder.HasMany(d => d.TicketHistories ).WithOne().HasForeignKey(x => x.TicketId);

        builder.Property(m => m.Title).HasMaxLength(100);
        builder.Property(m => m.Describtion).HasMaxLength(250);
        builder.Property(m => m.AssingTo).ValueGeneratedNever().HasConversion(id => id.Value, value => UserId.Create(value));
    }
    private void TicketHistoryConfigure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsMany(ticket => ticket.TicketHistories,
                        navigationBuilder =>
                        {
                            navigationBuilder.Property(d => d.AssingTo)
                                    .ValueGeneratedNever()
                                    .HasConversion(
                                        id => id.Value,
                                        value => UserId.Create(value)).HasColumnName("AssingTo");
                            navigationBuilder.ToTable("TicketHistories");
                            navigationBuilder.Property(ticketHistory => ticketHistory.Status)
                                             .HasColumnName("Status");
                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatorId)
                                             .HasColumnName("CreatorId");
                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatedAt)
                                           .HasColumnName("CreatedAt");
                            navigationBuilder.Property(ticketHistory => ticketHistory.TicketId)
                                         .HasColumnName("TicketId");
                            //navigationBuilder.Property(ticketHistory => ticketHistory.AssingTo)
                            //         .HasColumnName("AssingTo");

                        });


    }

}