using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;

namespace OnboardingAPI.Implementations.Repository
{
    public class LocalGovtsRepo : GenericRepository<LocalGovernments>, ILocalGovtsRepo
    {
        public LocalGovtsRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
