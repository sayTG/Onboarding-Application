using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingAPI.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int Deleted { get; set; }
    }
}
