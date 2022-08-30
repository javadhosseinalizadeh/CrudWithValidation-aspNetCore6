using System.ComponentModel.DataAnnotations;

namespace SampleCrud.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string PersonnelCode { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
