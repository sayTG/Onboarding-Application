using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Controllers;
using OnboardingAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAPI.Tests.ControllerTests
{
    public class ApiControllerBaseTest
    {
        [Fact]
        public void ProcessError_ApiBadRequestResponse_ReturnsBadRquest()
        {
            // Arrange
            ApiBaseResponse baseResponse = new ApiBadRequestResponse("");
            ApiControllerBase _controller = new();

            // Act
            IActionResult actual = _controller.ProcessError(baseResponse);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual);
        }
        [Fact]
        public void ProcessError_ApiNotFoundResponse_ReturnsNotFound()
        {
            // Arrange
            ApiBaseResponse baseResponse = new ApiNotFoundResponse("");
            ApiControllerBase _controller = new();

            // Act
            IActionResult actual = _controller.ProcessError(baseResponse);

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<NotFoundObjectResult>(actual);
        }
    }
}
