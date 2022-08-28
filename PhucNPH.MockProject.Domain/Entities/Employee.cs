namespace PhucNPH.MockProject.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Username { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int YearExperience { get; set; }
        public bool Deleted { get; set; }

		// 1-to-1 relationship
		public Guid JobDetailId { get; set; }
		public JobDetail JobDetail { get; set; }

		// 1-to-many relationship
		public Guid DepartmentId { get; set; }
		public Department Department { get; set; }

	}
}
