using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICustomersRepo CustomersRepo { get; }

        public UnitOfWork(ApplicationDbContext context,
            ICustomersRepo customersRepo)
        {
            _context = context;
            CustomersRepo = customersRepo;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
