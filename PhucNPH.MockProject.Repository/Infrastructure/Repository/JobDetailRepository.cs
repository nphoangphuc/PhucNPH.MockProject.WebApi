using PhucNPH.MockProject.Domain.Entities;

namespace PhucNPH.MockProject.Repository.Infrastructure.Repository
{
	public interface IJobDetailRepository : IRepository<JobDetail> { }

	public class JobDetailRepository : Repository<AppDbContext, JobDetail>, IJobDetailRepository
	{
		public JobDetailRepository(AppDbContext appDbContext) : base(appDbContext)
		{

		}
	}
}
