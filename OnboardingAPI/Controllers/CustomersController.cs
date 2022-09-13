using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IServices;
using OnboardingAPI.Extensions;
using OnboardingAPI.Models;
using OnboardingAPI.Models.DTOs;
using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ApiControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IClientService _clientService;
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(ICustomerService customerService, IClientService clientService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _clientService = clientService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {
            ApiBaseResponse result = await _customerService.GetAllCustomers();
            if (!result.Success)
                return ProcessError(result);
            return Ok(result.GetResult<IEnumerable<Customers>>());
        }
        [HttpGet("GetAllBanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            ApiBaseResponse result = await _clientService.GetAllBanks();
            if (!result.Success)
                return ProcessError(result);
            return Ok(result.GetResult<List<BankDTO>>());
        }
        [HttpGet("Verify")]
        public async Task<IActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return ProcessError(new ApiBadRequestResponse("Phone number cannot be null"));
            ApiBaseResponse result = await _customerService.VerifyPhoneNumber(phoneNumber);
            if (!result.Success)
                return ProcessError(result);
            return Ok(result.GetResult<string>());
        }
        [HttpPost("Onboard")]
        public async Task<IActionResult> OnboardCustomers(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return ProcessError(new ApiBadRequestResponse("Please fill in the necessary fields!"));
            ApiBaseResponse result = await _customerService.OnboardCustomer(customerDTO);
            if (!result.Success)
                return ProcessError(result);
            return Ok(result.GetResult<string>());
        }
        [HttpDelete("DeleteOnboard")]
        public async Task<IActionResult> DeleteCustomers(Guid id)
        {
            var gg = await _unitOfWork.CustomersRepo.Get(id);
            _unitOfWork.CustomersRepo.Delete(gg);
            await _unitOfWork.Save();
            return Ok("heeh");
        }
    }
}
