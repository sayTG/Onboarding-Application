using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Interceptors;

namespace OnboardingAPI.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customers>()
                   .HasIndex(c => new { c.Email, c.PhoneNumber })
                   .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.AddInterceptors(new SavingChangesInterceptor());

        public DbSet<Customers>? Customers { get; set; }
        public DbSet<States>? States { get; set; }
        public DbSet<LocalGovernments>? LocalGovts { get; set; }
    }
}
