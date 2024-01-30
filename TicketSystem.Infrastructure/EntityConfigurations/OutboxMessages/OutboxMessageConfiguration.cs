using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Models.Outbox;

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{

    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        OutboxMessageConfigure(builder);


    }
    private void OutboxMessageConfigure(EntityTypeBuilder<OutboxMessage> builder)
    {

        builder.ToTable("OutboxMessages");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();


    }
}