using OnboardingAPI.Models;

namespace OnboardingAPI.Abstractions.IRepository
{
    public interface ICustomersRepo : IGenericRepository<Customers>
    {
        Customers? GetCustomerByPhoneNumber(string? phoneNumber);
    }
}
