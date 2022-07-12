using OnboardingAPI.Abstractions.IMappingConfig;
using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;

namespace OnboardingAPI.Implementations.MappingConfig
{
    public class CustomMapping : ICustomMapping
    {
        public void InMap(Customers customer, CustomerDTO customerDTO)
        {
            customer.PhoneNumber = customerDTO.PhoneNumber;
            customer.Email = customerDTO.Email;
            customer.StateId = customerDTO.State;
            customer.LocalGovtId = customerDTO.LGA;
        }
        public void InMap(States state, CustomerDTO customerDTO)
        {
            state.Name = customerDTO.State;
            state.StateId = customerDTO.State;
        }
        public void InMap(LocalGovernments localgovt, CustomerDTO customerDTO)
        {
            localgovt.Name = customerDTO.LGA;
            localgovt.LocalGovtId = customerDTO.LGA;
        }
    }
}
