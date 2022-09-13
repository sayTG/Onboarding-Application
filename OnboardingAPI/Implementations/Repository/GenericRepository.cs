using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;
using System.Reflection;

namespace OnboardingAPI.Implementations.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> Get(dynamic id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).Property(x => x.Id).IsModified = false;
            _context.Set<T>().Remove(entity);
            //entity.Deleted = entity.Id;
            //_context.Set<T>().Update(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.Entry(entity).Property(x => x.Id).IsModified = false;
        }
    }
}
