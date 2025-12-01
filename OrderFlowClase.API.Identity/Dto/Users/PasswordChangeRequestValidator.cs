using FluentValidation;

namespace OrderFlowClase.API.Identity.Dto.Users
{
    public class PasswordChangeRequestValidator : AbstractValidator<PasswordChangeRequest>
    {
        public PasswordChangeRequestValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("La contraseña actual no puede estar vacía.")
                .MinimumLength(8).WithMessage("La nueva contraseña debe tener al menos 8 caracteres.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("La nueva contraseña no puede estar vacía.")
                .MinimumLength(8).WithMessage("La nueva contraseña debe tener al menos 8 caracteres.")
                .Matches(@"[!@#$%^&*(),.?""':{}|<>]").WithMessage("La nueva contraseña debe tener al menos un carácter especial.");
        }
    }
}