using Microsoft.AspNetCore.Identity;
using Moq;
using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IMappingConfig;
using OnboardingAPI.Implementations.Services;
using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Tests.ServicesTest
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomMapping> _customMappingMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IPasswordHasher<Customers>> _passwordHarsherMock;
        public CustomerServiceTests()
        {
            _customMappingMock = new Mock<ICustomMapping>(MockBehavior.Default);
            _unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Default);
            _passwordHarsherMock = new Mock<IPasswordHasher<Customers>>(MockBehavior.Default);
        }
        #region VerifyPhoneNumber
        [Fact]
        public async void VerifyPhoneNumber_NullCustomer_ReturnsApiNotFoundResponse()
        {
            // Arrange
            string phoneNumber = "234";
            Customers? customer = new();
            _unitOfWorkMock.Setup(d => d.CustomersRepo.GetCustomerByPhoneNumber(phoneNumber)).Returns(customer = null);
            CustomerService customerService = new(_unitOfWorkMock.Object, _customMappingMock.Object, _passwordHarsherMock.Object);

            // Act
            ApiBaseResponse actual = await customerService.VerifyPhoneNumber(phoneNumber);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiNotFoundResponse>(actual);
        }
        [Fact]
        public async void VerifyPhoneNumber_ValidCustomer_ReturnsOkResponse()
        {
            // Arrange
            string phoneNumber = "234";
            Customers? customer = new();
            _unitOfWorkMock.Setup(d => d.CustomersRepo.GetCustomerByPhoneNumber(phoneNumber)).Returns(customer = new());
            CustomerService customerService = new(_unitOfWorkMock.Object, _customMappingMock.Object, _passwordHarsherMock.Object);

            // Act
            ApiBaseResponse actual = await customerService.VerifyPhoneNumber(phoneNumber);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<string>>(actual);
        }
        #endregion

        #region OnboardCustomer
        [Fact]
        public async void OnboardCustomer_ReturningCustomer_ReturnsApiOkResponse()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            customerDTO.PhoneNumber = "234";
            _unitOfWorkMock.Setup(d => d.CustomersRepo.GetCustomerByPhoneNumber(customerDTO.PhoneNumber)).Returns(new Customers());
            CustomerService customerService = new(_unitOfWorkMock.Object, _customMappingMock.Object, _passwordHarsherMock.Object);

            // Act
            ApiBaseResponse actual = await customerService.OnboardCustomer(customerDTO);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<string>>(actual);
        }
        [Fact]
        public async void OnboardCustomer_NewCustomer_ReturnsOkResponse()
        {
            // Arrange
            CustomerDTO customerDTO = new();
            customerDTO.PhoneNumber = "234";
            Customers? customer = new();
            var password = new PasswordHasher<Customers>();
            _unitOfWorkMock.Setup(d => d.CustomersRepo.GetCustomerByPhoneNumber(customerDTO.PhoneNumber)).Returns(customer = null);
            _unitOfWorkMock.Setup(d => d.LocalGovtsRepo.Insert(new LocalGovernments()));
            _unitOfWorkMock.Setup(d => d.StatesRepo.Insert(new States()));
            _passwordHarsherMock.Setup(m => m.HashPassword(It.IsAny<Customers>(), It.IsAny<string>())).Returns("Hash value");
            CustomerService customerService = new(_unitOfWorkMock.Object, _customMappingMock.Object, _passwordHarsherMock.Object);

            // Act
            ApiBaseResponse actual = await customerService.OnboardCustomer(customerDTO);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<ApiOkResponse<string>>(actual);
        }
        #endregion
    }
}
