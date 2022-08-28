using System.ComponentModel.DataAnnotations;

namespace PhucNPH.MockProject.Domain.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int YearExperience { get; set; }
        public JobDetailModel JobDetail { get; set; }
    }
}
