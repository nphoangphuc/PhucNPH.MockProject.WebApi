using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Domain.Models
{
	public class DepartmentModel
	{
		public Guid Id { get; set; }
		public string DepartmentName { get; set; }
		public string DepartmentLocation { get; set; }
		public int NumberOfEmployees { get; set; }
		public List<EmployeeModel> EmployeeModels { get; set; }
	}
}
