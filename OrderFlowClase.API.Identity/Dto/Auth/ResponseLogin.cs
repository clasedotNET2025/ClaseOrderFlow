using FluentValidation;

namespace OrderFlowClase.API.Identity.Dto.Auth
{
    public class ResponseLogin
    {
        public required string Token { get; set; }
        public DateTime ExpirationAtUtc { get; set; }
    }

    public class ResponseLoginValidator : AbstractValidator<ResponseLogin>
    {
        public ResponseLoginValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("El token no puede estar vacío.")
                .MaximumLength(500).WithMessage("El token no puede exceder los 500 caracteres.");
            RuleFor(x => x.ExpirationAtUtc)
                .GreaterThan(DateTime.UtcNow).WithMessage("La fecha de expiración debe ser una fecha futura.");
        }
    }
}
