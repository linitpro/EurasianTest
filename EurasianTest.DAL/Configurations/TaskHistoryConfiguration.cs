using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Configurations
{
    public class TaskHistoryConfiguration: IEntityTypeConfiguration<TaskHistory>
    {
        public void Configure(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Updated);
            builder.Property(x => x.OldStatus).IsRequired();
            builder.Property(x => x.NewStatus).IsRequired();

            builder.HasOne(x => x.Task).WithMany(x => x.History).HasForeignKey(x => x.TaskId);
            builder.HasOne(x => x.User).WithMany(x => x.History).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.OldUser).WithMany(x => x.SendedHistory).HasForeignKey(x => x.OldUserId);
            builder.HasOne(x => x.NewUser).WithMany(x => x.RecievedHistory).HasForeignKey(x => x.NewUserId);

            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.OldUserId);
            builder.HasIndex(x => x.NewUserId);
            builder.HasIndex(x => x.TaskId);

        }
    }
}
