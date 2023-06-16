using FluentValidation;

namespace Application.Mediator.Queries.Auth.Login
{
    public class LoginValidator : AbstractValidator<LoginQuery>
    {
        public LoginValidator()
        {
            RuleFor(e => e.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200)
            .EmailAddress();

            RuleFor(e => e.Password)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);
        }
    }
}