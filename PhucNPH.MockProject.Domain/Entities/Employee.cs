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
        public uint RecordVersion { get; set; }
    }
}
