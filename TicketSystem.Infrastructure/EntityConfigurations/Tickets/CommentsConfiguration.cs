using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Tickets;
using TicketSystem.Domain.Tickets.Entities;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal class CommentsConfiguration : IEntityTypeConfiguration<Comment>
{

    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        CommentConfigure(builder);

    }
    private void CommentConfigure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
 
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CommentId.Create(value));



        builder.Property(d => d.CreatorId)
                                 .ValueGeneratedNever()
                                 .HasConversion(
                                   id => id.Value,
                                   value => UserId.Create(value))
                                 .HasColumnName("CreatorId");

        builder.Property(d => d.ModifierId)
                                   .ValueGeneratedNever()
                                   .HasConversion(
                                     id => id.Value,
                                     value => UserId.Create(value))
                                   .HasColumnName("ModifierId");

        builder.Property(ticketHistory => ticketHistory.TicketId)
                                   .ValueGeneratedNever()
                                 .HasConversion(
                                   id => id.Value,
                                   value => TicketId.Create(value))
                                 .HasColumnName("TicketId");

        builder.Property(m => m.Body).HasMaxLength(250);
        //builder.HasOne(d => d.Ticket).WithMany().HasForeignKey(x => x.TicketId);

    }
}