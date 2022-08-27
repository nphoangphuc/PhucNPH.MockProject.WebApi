using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucNPH.MockProject.Domain.Entities;

namespace PhucNPH.MockProject.Repository.Infrastructure.Configuration
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.ToTable("Departments");

			builder.HasKey(x => x.Id);

			builder.HasMany<Employee>(d => d.Employees)
				.WithOne(e => e.Department)
				.HasForeignKey(e => e.Id);
		}
	}
}
