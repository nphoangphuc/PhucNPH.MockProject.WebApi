using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Entities
{
	public class Department : BaseEntity
	{
		public string DepartmentName { get; set; }
		public string DepartmentLocation { get; set; }
	}
}
