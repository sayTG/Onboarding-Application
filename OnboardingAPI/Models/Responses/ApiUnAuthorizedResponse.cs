namespace OnboardingAPI.Models.Responses
{
    public sealed class ApiUnAuthorizedResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiUnAuthorizedResponse(string message) : base(false)
        {
            Message = message;
        }
    }
}
