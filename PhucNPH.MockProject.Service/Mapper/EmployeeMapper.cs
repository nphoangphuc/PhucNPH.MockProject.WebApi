using Microsoft.AspNet.Identity;
using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Service.Mapper
{
    public interface IEmployeeMapper
    {
        EmployeeModel MapEmployeeToEmployeeModel(Employee employee);
        Employee MapEmployeeCreateModelToEmployee(EmployeeCreateModel employee);
        Employee MapEmployeeUpdateModelToEmployee(EmployeeUpdateModel employee, Employee currentEmployee);

    }

    public class EmployeeMapper : IEmployeeMapper
    {
        public Employee MapEmployeeCreateModelToEmployee(EmployeeCreateModel employee)
        {
            var hasher = new PasswordHasher();

            if (employee == null)
            {
                return null;
            }

            return new Employee
            {
                Address = employee.Address,
                DOB = employee.DOB,
                Password = hasher.HashPassword(employee.Password),
                Phone = employee.Phone,
                Username = employee.Username,
                YearExperience = employee.YearExperience,
                DepartmentId = employee.DepartmentId,
            };
        }

        public EmployeeModel MapEmployeeToEmployeeModel(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            return new EmployeeModel
            {
                Id = employee.Id,
                Address = employee.Address,
                DOB = employee.DOB,
                Phone = employee.Phone,
                Username = employee.Username,
                YearExperience = employee.YearExperience,
            };
        }

        public Employee MapEmployeeUpdateModelToEmployee(EmployeeUpdateModel employee, Employee currentEmployee)
        {
            if (employee == null || currentEmployee == null)
            {
                return null;
            }

            currentEmployee.Address = employee.Address;
            currentEmployee.DOB = employee.DOB;
            currentEmployee.Password = employee.Password;
            currentEmployee.Phone = employee.Phone;
            currentEmployee.YearExperience = employee.YearExperience;

            return currentEmployee;
        }
    }
}
