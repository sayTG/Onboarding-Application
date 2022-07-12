using OnboardingAPI.Abstractions.IRepository;

namespace OnboardingAPI.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepo CustomersRepo { get; }
        int Save();
    }
}
