using OnboardingAPI.Models.Responses;

namespace OnboardingAPI.Extensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse)
            =>
                ((ApiOkResponse<TResultType>)apiBaseResponse).Result;
    }
}
