using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;

namespace OnboardingAPI.Abstractions.IMappingConfig
{
    public interface ICustomMapping
    {
        void InMap(Customers customer, CustomerDTO customerDTO);
        void InMap(States state, CustomerDTO customerDTO);
        void InMap(LocalGovernments localgovt, CustomerDTO customerDTO);
    }
}
