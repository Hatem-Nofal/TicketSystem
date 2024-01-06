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
using TicketSystem.Domain.Users;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Infrastructure.EntityConfigurations.Tickets;

internal sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        UserConfigure(builder);

    }
    private void UserConfigure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        builder.Property(d => d.IdentityUsersId)
           .ValueGeneratedNever()
           .HasConversion(
               id => id.Value,
               value => IdentityUsersId.Create(value));
        builder.Property(m => m.UserName).HasMaxLength(100);
        builder.Property(m => m.IdentityUsersId);
        builder.Property(m => m.PhotoURL);
     
        builder.OwnsOne(user => user.Email,
                        navigationBuilder =>
                        {
                            navigationBuilder.Property(comment => comment.Value)
                                             .HasColumnName("Email").HasMaxLength(255);
                            navigationBuilder.HasIndex(m => m.Value).IsUnique();


                        });
        builder.OwnsOne(user => user.Phone,
                        navigationBuilder =>
                        {
                            navigationBuilder.Property(comment => comment.Value)
                                             .HasColumnName("Phone").HasMaxLength(255);
                            navigationBuilder.HasIndex(m => m.Value).IsUnique();


                        });

    }



}