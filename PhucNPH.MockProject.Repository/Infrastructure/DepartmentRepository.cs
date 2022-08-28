using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Repository.Infrastructure.Repository;

namespace PhucNPH.MockProject.Repository.Infrastructure.Repository
{
	public interface IDepartmentRepository : IRepository<Department>
	{
		Task<Department> GetByDepartmentId(Guid departmentId);
		Task SoftDelete(Department department);
		Task<List<Department>> GetMultipleDepartments();
	}

	public class DepartmentRepository : Repository<AppDbContext, Department>, IDepartmentRepository
	{
		public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Department> GetByDepartmentId(Guid departmentId)
		{
			var department = await base.SearchForSingleItemAsync(d => d.Id == departmentId && d.Deleted == false);

			return department;
		}

		public async Task<List<Department>> GetMultipleDepartments()
		{
			var employees = await base.SearchForMultipleItemAsync(d => d.Deleted == false);
			return employees;
		}

		public async Task SoftDelete(Department department)
		{
			department.Deleted = true;
			await base.UpdateAsync(department);
		}
	}
}
