using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingAPI.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Deleted { get; set; }
    }
}
