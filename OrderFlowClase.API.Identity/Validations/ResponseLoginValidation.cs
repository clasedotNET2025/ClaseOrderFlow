namespace OrderFlowClase.API.Identity.Validations
{
    public class ResponseLoginValidation
    {
        public required string Token { get; set; }
        public DateTime ExpirationAtUtc { get; set; }
    }
}
