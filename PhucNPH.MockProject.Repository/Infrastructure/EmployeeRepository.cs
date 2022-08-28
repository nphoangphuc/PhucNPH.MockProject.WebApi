using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Domain.Models;
using PhucNPH.MockProject.Repository.Infrastructure.Repository;

namespace PhucNPH.MockProject.Repository.Infrastructure.Repository
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
		Task<Employee> GetByEmployeeId(Guid emoloyeeId);
		Task<Employee> GetByEmployeeUsername(string Username);
		Task<Employee> LoginAsync(LoginModel loginModel);
		Task SoftDelete(Employee employee);
		Task<List<Employee>> GetMultipleEmployees();
	}

	public class EmployeeRepository : Repository<AppDbContext, Employee>, IEmployeeRepository
	{
		public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Employee> GetByEmployeeId(Guid emoloyeeId)
		{
			var employee = await base.SearchForSingleItemAsync(q => q.Id == emoloyeeId && q.Deleted == false, e => e.JobDetail);

			return employee;
		}

		public async Task<Employee> GetByEmployeeUsername(string Username)
		{
			var employee = await base.SearchForSingleItemAsync(q => q.Username == Username && q.Deleted == false);

			return employee;
		}

		public async Task<Employee> LoginAsync(LoginModel loginModel)
		{
			var hasher = new PasswordHasher();
			var password = hasher.HashPassword(loginModel.Password);

			var employee = await base.SearchForSingleItemAsync(emp => emp.Username == loginModel.Username && emp.Deleted == false);

			try
			{
				if (employee != null
					&& hasher.VerifyHashedPassword(employee.Password, loginModel.Password) == PasswordVerificationResult.Success)
				{
					return employee;
				}
			}
			catch (Exception)
			{
				return null;
			}

			return null;
		}

		public async Task SoftDelete(Employee employee)
		{
			employee.Deleted = true;
			await base.UpdateAsync(employee);
		}

		public async Task<List<Employee>> GetMultipleEmployees()
		{
			var employees = await base.SearchForMultipleItemAsync(emp => emp.Deleted == false, e => e.Include(e => e.JobDetail));
			return employees;
		}
	}
}