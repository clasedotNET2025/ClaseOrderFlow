namespace OrderFlowClase.API.Identity.Dto.Users
{
    public sealed class PasswordChangeRequest
    {
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}