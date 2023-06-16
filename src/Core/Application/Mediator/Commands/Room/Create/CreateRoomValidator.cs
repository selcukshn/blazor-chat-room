using FluentValidation;

namespace Application.Mediator.Commands.Room.Create
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomValidator()
        {
            RuleFor(e => e.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(60);

            RuleFor(e => e.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200);
        }
    }
}