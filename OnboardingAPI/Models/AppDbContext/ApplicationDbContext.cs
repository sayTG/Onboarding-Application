﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnboardingAPI.Extensions;
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
            //builder.Entity<Customers>().Property(c => c.Id).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                //other automated configurations left out
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }

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
