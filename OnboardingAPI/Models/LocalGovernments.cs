using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class LocalGovernments : BaseEntity
    {
        [Key]
        public string? LocalGovtId { get; set; }
        public string? Name { get; set; }
        public string? StateId { get; set; }
        public States? State { get; set; }
    }
}
