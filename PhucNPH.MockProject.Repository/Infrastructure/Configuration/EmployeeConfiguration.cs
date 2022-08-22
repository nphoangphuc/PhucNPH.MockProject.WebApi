﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucNPH.MockProject.Domain.Entities;

namespace PhucNPH.MockProject.Repository.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Username }).IsUnique();
        }
    }
}
