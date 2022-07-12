using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Abstractions.IServices
{
    public interface ICustomerService
    {
        Task<ApiBaseResponse> GetAllCustomers();
        Task<ApiBaseResponse> VerifyPhoneNumber(string phoneNumber);
        Task<ApiBaseResponse> OnboardCustomer(CustomerDTO customerDTO);
    }
}
