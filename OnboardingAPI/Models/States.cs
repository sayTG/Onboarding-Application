using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class States : BaseEntity
    {
        [Key]
        public string? StateId { get; set; }
        public string? Name { get; set; }
    }
}
