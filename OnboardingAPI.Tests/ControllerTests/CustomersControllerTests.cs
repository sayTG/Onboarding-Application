using Microsoft.AspNetCore.Mvc;
using Moq;
using OnboardingAPI.Abstractions.IServices;
using OnboardingAPI.Controllers;
using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAPI.Tests.ControllerTests
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;
        public CustomersControllerTests()
        {
            _customerServiceMock = new Mock<ICustomerService>(MockBehavior.Default);
        }
        #region GetAllCustomers 
        [Fact]
        public async void GetAllCustomers_ApiNotFoundResponse_ReturnsNotFound()
        {
            // Arrange
            _customerServiceMock.Setup(d => d.GetAllCustomers()).ReturnsAsync(new ApiNotFoundResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.GetAllCustomers();
            NotFoundObjectResult actualStatusCode = (NotFoundObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NotFoundObjectResult>(actual);
            Assert.Equal(404, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void GetAllCustomers_ApiBadRequestResponse_ReturnBadRequest()
        {
            // Arrange
            _customerServiceMock.Setup(d => d.GetAllCustomers()).ReturnsAsync(new ApiBadRequestResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.GetAllCustomers();
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void GetAllCustomers_ApiOkResponseAndInvalidReturnType_ThrowsInvalidCastException()
        {
            // Arrange
            string value = "";
            _customerServiceMock.Setup(d => d.GetAllCustomers()).ReturnsAsync(new ApiOkResponse<string>(value));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.GetAllCustomers());
        }
        [Fact]
        public async void GetAllCustomers_ApiOkResponseAndValidReturnType_ReturnOk()
        {
            // Arrange
            IEnumerable<Customers> customers = new List<Customers>();
            _customerServiceMock.Setup(d => d.GetAllCustomers()).ReturnsAsync(new ApiOkResponse<IEnumerable<Customers>>(customers));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.GetAllCustomers();
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<List<Customers>>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
        #endregion 

        #region VerifyPhoneNumber 
        [Fact]
        public async void VerifyPhoneNumber_InValidRequest_ReturnsBadRequest()
        {
            // Arrange
            string phoneNumber = string.Empty;
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.VerifyPhoneNumber(phoneNumber);
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void VerifyPhoneNumber_ApiNotFoundResponseAndValidRequest_ReturnsNotFound()
        {
            // Arrange
            string phoneNumber = "1234";
            _customerServiceMock.Setup(d => d.VerifyPhoneNumber(phoneNumber)).ReturnsAsync(new ApiNotFoundResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.VerifyPhoneNumber(phoneNumber);
            NotFoundObjectResult actualStatusCode = (NotFoundObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NotFoundObjectResult>(actual);
            Assert.Equal(404, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void VerifyPhoneNumber_ApiBadRequestResponseAndValidRequest_ReturnBadRequest()
        {
            // Arrange
            string phoneNumber = "1234";
            _customerServiceMock.Setup(d => d.VerifyPhoneNumber(phoneNumber)).ReturnsAsync(new ApiBadRequestResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.VerifyPhoneNumber(phoneNumber);
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void VerifyPhoneNumber_ApiOkResponseWithInvalidReturnTypeAndValidRequest_ThrowsInvalidCastException()
        {
            // Arrange
            string phoneNumber = "1234";
            int value = 0;
            _customerServiceMock.Setup(d => d.VerifyPhoneNumber(phoneNumber)).ReturnsAsync(new ApiOkResponse<int>(value));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.VerifyPhoneNumber(phoneNumber));
        }
        [Fact]
        public async void VerifyPhoneNumber_ApiOkResponseWithValidReturnTypeAndValidRequest_ReturnOk()
        {
            // Arrange
            string phoneNumber = "1234";
            string result = "Successfully";
            _customerServiceMock.Setup(d => d.VerifyPhoneNumber(phoneNumber)).ReturnsAsync(new ApiOkResponse<string>(result));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.VerifyPhoneNumber(phoneNumber);
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<string>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
        #endregion 

        #region OnboardCustomers 
        [Fact]
        public async void OnboardCustomers_ApiNotFoundResponseAndValidRequest_ReturnsNotFound()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            _customerServiceMock.Setup(d => d.OnboardCustomer(customerDTO)).ReturnsAsync(new ApiNotFoundResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.OnboardCustomers(customerDTO);
            NotFoundObjectResult actualStatusCode = (NotFoundObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NotFoundObjectResult>(actual);
            Assert.Equal(404, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void OnboardCustomers_ApiBadRequestResponseAndValidRequest_ReturnBadRequest()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            _customerServiceMock.Setup(d => d.OnboardCustomer(customerDTO)).ReturnsAsync(new ApiBadRequestResponse(""));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.OnboardCustomers(customerDTO);
            BadRequestObjectResult actualStatusCode = (BadRequestObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
            Assert.Equal(400, actualStatusCode.StatusCode);
        }
        [Fact]
        public async void OnboardCustomers_ApiOkResponseWithInvalidReturnTypeAndValidRequest_ThrowsInvalidCastException()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            int value = 0;
            _customerServiceMock.Setup(d => d.OnboardCustomer(customerDTO)).ReturnsAsync(new ApiOkResponse<int>(value));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act

            // Assert
            await Assert.ThrowsAsync<InvalidCastException>(() => _controller.OnboardCustomers(customerDTO));
        }
        [Fact]
        public async void OnboardCustomers_ApiOkResponseWithValidReturnTypeAndValidRequest_ReturnOk()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            string result = "Successfully";
            _customerServiceMock.Setup(d => d.OnboardCustomer(customerDTO)).ReturnsAsync(new ApiOkResponse<string>(result));
            CustomersController _controller = new(_customerServiceMock.Object);

            // Act
            IActionResult actual = await _controller.OnboardCustomers(customerDTO);
            OkObjectResult actualStatusCode = (OkObjectResult)actual;

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsType<string>(actualStatusCode.Value);
            Assert.Equal(200, actualStatusCode.StatusCode);
        }
        #endregion 
    }
}
