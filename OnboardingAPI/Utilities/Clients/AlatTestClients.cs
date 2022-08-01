using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;
using System.Net.Http.Headers;

namespace OnboardingAPI.Utilities.Clients
{
    public class AlatTestClients
    {
        private readonly HttpClient _httpClient;

        public AlatTestClients(HttpClient httpClient) => _httpClient = httpClient;
        public async Task<ApiBaseResponse> GetAllBanks()
        {
            _httpClient.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
            //_httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AlatTestKey.AlatTestSubcriptionKey);
            HttpResponseMessage response = await _httpClient.GetAsync("GetAllBanks");
            if (response.IsSuccessStatusCode)
            {
                BankEnvelopeDTO? result = await response.Content.ReadFromJsonAsync<BankEnvelopeDTO>();
                if (result == null)
                    return new ApiOkResponse<List<BankDTO>?>(null);

                return new ApiOkResponse<List<BankDTO>?>(result.BankDTO);
            }
            else
            {
                return new ApiUnAuthorizedResponse(response.ReasonPhrase + ": Invalid Subcription Key");
            }
        }
    }
}
