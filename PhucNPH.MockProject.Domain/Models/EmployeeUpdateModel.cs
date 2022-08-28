namespace PhucNPH.MockProject.Domain.Models
{
    public class EmployeeUpdateModel
    {
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int YearExperience { get; set; }
        public JobDetailUpdateModel? JobDetailUpdateModel { get; set; }
    }
}
