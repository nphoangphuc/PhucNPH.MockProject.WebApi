﻿using Microsoft.AspNet.Identity;
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
                JobDetail = new JobDetailModel
                {
                    Id = employee.JobDetail.Id,
                    JobDescription = employee.JobDetail.JobDescription,
                    JobLevel = employee.JobDetail.JobLevel,
                    JobTitle = employee.JobDetail.JobTitle.ToString()
                }
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
            currentEmployee.Phone = employee.Phone;
            currentEmployee.YearExperience = employee.YearExperience;

            if(employee.JobDetailUpdateModel != null)
            {
                currentEmployee.JobDetail.JobTitle = Enum.Parse<JobTitle>(employee.JobDetailUpdateModel.JobTitle);
                currentEmployee.JobDetail.JobDescription = employee.JobDetailUpdateModel.JobDescription;
                currentEmployee.JobDetail.JobLevel = employee.JobDetailUpdateModel.JobLevel;
			}

            return currentEmployee;
        }
    }
}
