using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Salt).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Updated);

            builder.HasMany(x => x.History).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.SendedHistory).WithOne(x => x.OldUser).HasForeignKey(x => x.OldUserId);
            builder.HasMany(x => x.RecievedHistory).WithOne(x => x.NewUser).HasForeignKey(x => x.NewUserId);
        }
    }
}
