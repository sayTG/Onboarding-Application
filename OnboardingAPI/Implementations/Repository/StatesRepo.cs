using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations.Repository
{
    public class StatesRepo : GenericRepository<States>, IStatesRepo
    {
        public StatesRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
