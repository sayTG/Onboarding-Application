using Microsoft.EntityFrameworkCore;

namespace OnboardingAPI.Models.AppDbContext
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customers>()
                   .HasIndex(c => c.Email)
                   .IsUnique();
        }
        public DbSet<Customers>? Customers { get; set; }
        public DbSet<States>? States { get; set; }
        public DbSet<LocalGovernments>? LocalGovts { get; set; }
    }
}
