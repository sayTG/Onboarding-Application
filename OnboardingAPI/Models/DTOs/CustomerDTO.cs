using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models.DTOs
{
    public class CustomerDTO
    {
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? LGA { get; set; }
    }
}
