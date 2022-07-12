using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Abstractions.IServices
{
    public interface IClientService
    {
        Task<ApiBaseResponse> GetAllBanks();
    }
}
