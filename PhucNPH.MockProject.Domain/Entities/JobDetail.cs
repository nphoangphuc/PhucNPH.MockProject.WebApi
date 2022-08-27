using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Entities
{
	public class JobDetail
	{
		public JobTitle JobTitle { get; set; }
		public string JobDescription { get; set; }
		public int JobLevel { get; set; }
	}
}
