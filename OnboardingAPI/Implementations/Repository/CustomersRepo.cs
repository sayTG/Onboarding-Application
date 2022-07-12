using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations.Repository
{
    public class CustomersRepo : GenericRepository<Customers>, ICustomersRepo
    {
        public CustomersRepo(ApplicationDbContext _context) : base(_context)
        {
            
        }
        public Customers? GetCustomerByPhoneNumber(string? phoneNumber) => _context.Customers?.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
    }
}
