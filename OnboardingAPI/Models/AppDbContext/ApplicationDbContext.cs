using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Interceptors;

namespace OnboardingAPI.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customers>()
                   .HasIndex(c => c.Email)
                   .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.AddInterceptors(new SavingChangesInterceptor());

        public DbSet<Customers>? Customers { get; set; }
        public DbSet<States>? States { get; set; }
        public DbSet<LocalGovernments>? LocalGovts { get; set; }
    }
}
