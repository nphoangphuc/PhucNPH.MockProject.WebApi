using System.ComponentModel.DataAnnotations;

namespace PhucNPH.MockProject.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
