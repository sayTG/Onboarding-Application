using OnboardingAPI.Abstractions.IRepository;

namespace OnboardingAPI.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepo CustomersRepo { get; }
        IStatesRepo StatesRepo { get; }
        ILocalGovtsRepo LocalGovtsRepo { get; }
        int Save();
    }
}
