namespace OnboardingAPI.Models.DTOs
{
    public class BankEnvelopeDTO
    {
        public List<BankDTO>? Result { get; set; }
        //public string? ErrorMessage { get; set; }
        //public bool HasError { get; set; }
    }
    public class BankDTO
    {
        public string? BankName { get; set; }
        public string? BankCode { get; set; }
    }
}
