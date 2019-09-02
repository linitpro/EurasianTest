using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Configurations
{
    public class ProjectAdministratorConfiguration: IEntityTypeConfiguration<ProjectAdministrator>
    {
        public void Configure(EntityTypeBuilder<ProjectAdministrator> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Updated);

            builder.HasOne(x => x.Project).WithMany(x => x.ProjectAdministrators).HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.User).WithMany(x => x.Projects).HasForeignKey(x => x.ProjectId);
        }
    }
}
