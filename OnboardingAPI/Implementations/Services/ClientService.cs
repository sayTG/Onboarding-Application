using OnboardingAPI.Abstractions.IServices;
using OnboardingAPI.Models.Responses;
using OnboardingAPI.Utilities.Clients;

namespace OnboardingAPI.Implementations.Services
{
    public class ClientService : IClientService
    {
        private readonly AlatTestClients _alatTestClients;
        public ClientService(AlatTestClients alatTestClients)
        {
            _alatTestClients = alatTestClients;
        }
        public async Task<ApiBaseResponse> GetAllBanks() => await _alatTestClients.GetAllBanks();
    }
}
