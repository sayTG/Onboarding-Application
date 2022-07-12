using OnboardingAPI.Abstractions.IServices;

namespace OnboardingAPI.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerService _customerService;
        public CustomerService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

    }
}
