﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ProcessError(ApiBaseResponse baseResponse)
        {
            return baseResponse switch
            {
                ApiNotFoundResponse => NotFound(new ErrorDetails
                {
                    Message = ((ApiNotFoundResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status404NotFound
                }),
                ApiBadRequestResponse => BadRequest(new ErrorDetails
                {
                    Message = ((ApiBadRequestResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status400BadRequest
                }),
                ApiUnAuthorizedResponse => Unauthorized(new ErrorDetails
                {
                    Message = ((ApiUnAuthorizedResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status401Unauthorized
                }),
                _ => throw new NotImplementedException()
            };
        }
    }
}
