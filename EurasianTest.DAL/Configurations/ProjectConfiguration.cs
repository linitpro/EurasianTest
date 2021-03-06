﻿using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Configurations
{
    public class ProjectConfiguration: IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Updated);
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Tasks).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
            builder.HasMany(x => x.ProjectAdministrators).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId);
        }
    }
}
