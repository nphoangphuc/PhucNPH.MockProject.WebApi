using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Service.Mapper
{
	public interface IDepartmentMapper
	{
		Department MapDepartmentCreateModelToDepartment(DepartmentCreateModel departmentCreateModel);
		DepartmentModel MapDepartmentToDepartmentModel(Department department);
	}
	public class DepartmentMapper : IDepartmentMapper
	{
		public Department MapDepartmentCreateModelToDepartment(DepartmentCreateModel departmentCreateModel)
		{
			if (departmentCreateModel == null)
			{
				return null;
			}

			return new Department
			{
				DepartmentLocation = departmentCreateModel.DepartmentLocation,
				DepartmentName = departmentCreateModel.DepartmentName,
			};
		}

		public DepartmentModel MapDepartmentToDepartmentModel(Department department)
		{
			if (department == null)
			{
				return null;
			}

			return new DepartmentModel
			{
				Id = department.Id,
				DepartmentName = department.DepartmentName,
				DepartmentLocation = department.DepartmentLocation,
				NumberOfEmployees =	 department.Employees.Count,
				EmployeeModels = department.Employees.Select(emp => new EmployeeModel
				{
					Id=emp.Id,
					Username = emp.Username,
					Address = emp.Address,
					DOB	= emp.DOB,
					Phone = emp.Phone,
					YearExperience = emp.YearExperience,
					JobDetail = new JobDetailModel
					{
						Id = emp.JobDetail.Id,
						JobDescription = emp.JobDetail.JobDescription,
						JobLevel = emp.JobDetail.JobLevel,
						JobTitle = emp.JobDetail.JobTitle.ToString(),
					}
				}).ToList()
			};
		}
	}
}
