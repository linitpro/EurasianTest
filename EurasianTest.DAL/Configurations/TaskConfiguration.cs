using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Configurations
{
    public class TaskConfiguration: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Updated);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Started).IsRequired();
            builder.Property(x => x.Expired).IsRequired();

            builder.HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x => x.ProjectId);
            builder.HasMany(x => x.History).WithOne(x => x.Task).HasForeignKey(x => x.TaskId);
            builder.HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x => x.UserId);

        }
    }
}
