using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations.Repository
{
    public class CustomersRepo : GenericRepository<Customers>, ICustomersRepo
    {
        public CustomersRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
