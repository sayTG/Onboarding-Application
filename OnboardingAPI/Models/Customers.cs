using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class Customers : BaseEntity
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? StateId { get; set; }    
        public States? State { get; set; }
        [Required]
        public string? LocalGovtId { get; set; }    
        public LocalGovernments? LocalGovt { get; set; }    
    }
}
