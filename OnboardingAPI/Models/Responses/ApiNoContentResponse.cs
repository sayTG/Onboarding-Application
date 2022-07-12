namespace OnboardingAPI.Models.Responses
{
    public sealed class ApiNoContentResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiNoContentResponse(string message) : base(true)
        {
            Message = message;
        }
    }
}
