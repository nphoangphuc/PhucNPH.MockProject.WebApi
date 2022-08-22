using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Domain.Models;
using PhucNPH.MockProject.Repository.Infrastructure.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhucNPH.MockProject.Repository.Infrastructure
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByEmployeeId(Guid emoloyeeId);
        Task<Employee> GetByEmployeeUsername(string Username);
        Task<Employee> LoginAsync(LoginModel loginModel);
    }

    public class EmployeeRepository : Repository<AppDbContext, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Employee> GetByEmployeeId(Guid emoloyeeId)
        {
            var employee = await base.SearchForSingleItemAsync(q => q.Id == emoloyeeId && q.Deleted == false);

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

            if (employee != null && hasher.VerifyHashedPassword(employee.Password, loginModel.Password) == PasswordVerificationResult.Success)
            {
                return employee;
            }

            return null;
        }
    }
}