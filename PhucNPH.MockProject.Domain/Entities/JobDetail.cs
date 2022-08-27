using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Domain.Entities
{
	public class JobDetail : BaseEntity
	{
		public JobTitle JobTitle { get; set; }
		public string JobDescription { get; set; }
		public int JobLevel { get; set; }

		// 1-to-1 relationship
		public virtual Employee Employee { get; set; }
	}
}
