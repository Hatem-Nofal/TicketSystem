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

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{

    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        TicketConfigure(builder);
        TicketCommentsConfigure(builder);
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
        //builder.Property(m => m.Id).HasColumnName("TicketId").ValueGeneratedNever();
        ////builder.HasKey(t =>new { t.Id }).HasName("TicketId");
        //builder.OwnsOne(t => t.Id).HasKey(t=>t.Value).HasName("TicketId"); ;
        //builder.Property(m => m.Id).HasConversion(id => id.Value, value => TicketId.Create(value));
        builder.Property(m => m.Title).HasMaxLength(100);
        builder.Property(m => m.Describtion).HasMaxLength(250);
        builder.Property(m => m.AssingTo).ValueGeneratedNever().HasConversion(id => id.Value, value => UserId.Create(value));
    }
    private void TicketCommentsConfigure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsMany(ticket => ticket.Comments,
                         navigationBuilder =>
                         {
                             navigationBuilder.ToTable("Comments");

                             navigationBuilder.Property(comment => comment.Body)
                                              .HasColumnName("Body");
                             navigationBuilder.Property(comment => comment.CreatorId)
                                              .HasColumnName("CreatorId");
                             navigationBuilder.Property(comment => comment.CreatedAt)
                                            .HasColumnName("CreatedAt");
                             navigationBuilder.Property(comment => comment.TicketId)
                                          .HasColumnName("TicketId");
                         });


    }
    private void TicketHistoryConfigure(EntityTypeBuilder<Ticket> builder)
    {
        builder.OwnsMany(ticket => ticket.TicketHistories,
                        navigationBuilder =>
                        {
                            navigationBuilder.ToTable("TicketHistories");
                            navigationBuilder.Property(ticketHistory => ticketHistory.Status)
                                             .HasColumnName("Status");
                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatorId)
                                             .HasColumnName("CreatorId");
                            navigationBuilder.Property(ticketHistory => ticketHistory.CreatedAt)
                                           .HasColumnName("CreatedAt");
                            navigationBuilder.Property(ticketHistory => ticketHistory.TicketId)
                                         .HasColumnName("TicketId");
                            navigationBuilder.Property(ticketHistory => ticketHistory.AssingTo)
                                     .HasColumnName("AssingTo");

                        });


    }

}