using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICustomersRepo CustomersRepo { get; }
        public IStatesRepo StatesRepo { get; }
        public ILocalGovtsRepo LocalGovtsRepo { get; }

        public UnitOfWork(ApplicationDbContext context,
            ICustomersRepo customersRepo, IStatesRepo statesRepo, ILocalGovtsRepo localGovtsRepo)
        {
            _context = context;
            CustomersRepo = customersRepo;
            LocalGovtsRepo = localGovtsRepo;
            StatesRepo = statesRepo;
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
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
