﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnboardingAPI.Models;

namespace OnboardingAPI.Interceptors
{
    public class SavingChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
           DbContextEventData eventData,
           InterceptionResult<int> result,
           CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var changedEntity in eventData.Context.ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity baseEntity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedDate = DateTime.Now;
                            baseEntity.UpdatedDate = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            baseEntity.UpdatedDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            baseEntity.UpdatedDate = DateTime.Now;
                            baseEntity.Deleted = baseEntity.Id;
                            break;
                    }
                }
            }
            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
