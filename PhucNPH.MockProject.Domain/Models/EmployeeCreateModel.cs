namespace PhucNPH.MockProject.Domain.Models
{
    public class EmployeeCreateModel
    {
        public string Username { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int YearExperience { get; set; }
        public JobDetailCreateModel JobDetailCreateModel { get; set; }
	}
}
