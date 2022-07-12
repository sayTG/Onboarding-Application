using Microsoft.AspNetCore.Identity;
using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IMappingConfig;
using OnboardingAPI.Abstractions.IServices;
using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapping _customMapping;
        public CustomerService(IUnitOfWork unitOfWork, ICustomMapping customMapping)
        {
            _unitOfWork = unitOfWork;
            _customMapping = customMapping;
        }
        public async Task<ApiBaseResponse> GetAllCustomers() => new ApiOkResponse<IEnumerable<Customers>>(await _unitOfWork.CustomersRepo.GetAll());
        public async Task<ApiBaseResponse> VerifyPhoneNumber(string phoneNumber)
        {
            try
            {
                Customers? customer = _unitOfWork.CustomersRepo.GetCustomerByPhoneNumber(phoneNumber);
                if (customer == null)
                    return new ApiNotFoundResponse("Customer Not Found!");
                customer.VerifiedNumber = true;
                _unitOfWork.CustomersRepo.Update(customer);
                await _unitOfWork.Save();
                return new ApiOkResponse<string?>("Verified Successfully, Onboarding completed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Verfiy Phone Number caught: {0}", e.Message);
                throw new Exception(e.Message);
            }
        }
        public async Task<ApiBaseResponse> OnboardCustomer(CustomerDTO customerDTO)
        {
            try
            {
                if (_unitOfWork.CustomersRepo.GetCustomerByPhoneNumber(customerDTO.PhoneNumber) != null)
                    return new ApiOkResponse<string?>("Customer already exists!");
                Customers customer = new();
                var password = new PasswordHasher<Customers>();
                customer.Password = password.HashPassword(customer, customerDTO.Password);
                _customMapping.InMap(customer, customerDTO);
                await _unitOfWork.CustomersRepo.Insert(customer);

                LocalGovernments localGovt = new();
                _customMapping.InMap(localGovt, customerDTO);
                await _unitOfWork.LocalGovtsRepo.Insert(localGovt);

                States state = new();
                _customMapping.InMap(state, customerDTO);
                await _unitOfWork.StatesRepo.Insert(state);

                await _unitOfWork.Save();

                return new ApiOkResponse<string?>("Please verify your phone number to complete your onboarding process");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Onboard Customer caught: {0}", e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
