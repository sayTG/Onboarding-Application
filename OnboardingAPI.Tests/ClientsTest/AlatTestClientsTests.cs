using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;
using OnboardingAPI.Utilities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAPI.Tests.ClientsTest
{
    public class AlatTestClientsTests
    {
        #region GetAllBanks
        [Fact]
        public async void GetAllBanks_ErrorHttpResponse_ReturnsUnAuthorized()
        {
            // Arrange
            int page = 1;
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        Content = new StringContent("")
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/"),
            };
            AlatTestClients alatClient = new(httpClient);

            // Act
            ApiBaseResponse actual = await alatClient.GetAllBanks();

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiUnAuthorizedResponse>(actual);
        }
        [Fact]
        public async void AllStarWarsPeople_OkHttpResponseAndValidDataType_ReturnsOk()
        {
            // Arrange
            BankEnvelopeDTO bankEnvDTO = new();
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(bankEnvDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/"),
            };
            AlatTestClients alatClient = new(httpClient);

            // Act
            ApiBaseResponse actual = await alatClient.GetAllBanks();

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<List<BankDTO>>>(actual);
        }
        [Fact]
        public async void GetAllBanks_OkHttpResponseAndInValidDataType_ThrowsJsonException()
        {
            // Arrange
            string bankDTO = "";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync
                (
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(bankDTO)),
                    }
                );
            var httpClient = new HttpClient(mockMessageHandler.Object)
            {
                BaseAddress = new Uri("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/"),
            };
            AlatTestClients alatClient = new(httpClient);

            // Act

            // Assert
            await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => alatClient.GetAllBanks());
        }
        #endregion
    }
}
