using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucNPH.MockProject.Domain.Entities;

namespace PhucNPH.MockProject.Repository.Infrastructure.Configuration
{
	public  class JobDetailConfiguration : IEntityTypeConfiguration<JobDetail>
	{
		public void Configure(EntityTypeBuilder<JobDetail> builder)
		{
			builder.ToTable("JobDetail");

			builder.HasKey(x => x.Id);

			builder.Property(p => p.JobTitle).HasConversion<string>();
		}
	}
}
