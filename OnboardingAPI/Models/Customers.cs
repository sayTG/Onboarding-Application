using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class Customers : BaseEntity
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }    
        public string? Password { get; set; }    
        public string? StateId { get; set; }    
        public States? State { get; set; }    
        public string? LocalGovtId { get; set; }    
        public LocalGovernments? LocalGovt { get; set; }    
    }
}
