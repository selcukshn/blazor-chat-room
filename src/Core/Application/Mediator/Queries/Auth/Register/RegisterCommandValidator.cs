using FluentValidation;

namespace Application.Mediator.Queries.Auth.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(e => e.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200)
            .EmailAddress();

            RuleFor(e => e.Username)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(200);

            RuleFor(e => e.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(100)
            .Equal(e => e.RePassword);

            RuleFor(e => e.RePassword)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(100);
        }
    }
}