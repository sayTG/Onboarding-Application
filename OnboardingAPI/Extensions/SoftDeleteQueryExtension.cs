using Microsoft.EntityFrameworkCore.Metadata;
using OnboardingAPI.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace OnboardingAPI.Extensions
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
            this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : BaseEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.Deleted != x.Id;
            return filter;
        }
    }
}
