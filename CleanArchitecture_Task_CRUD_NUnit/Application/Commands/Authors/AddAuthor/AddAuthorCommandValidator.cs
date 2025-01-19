using FluentValidation;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidator() 
        {
            RuleFor(x => x.NewAuthor.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required");

            RuleFor(x => x.NewAuthor.Age)
                .InclusiveBetween(18, 120).WithMessage("Age must be between 18 and 120.");

            RuleFor(x => x.NewAuthor.Bio)
                .NotEmpty().WithMessage("Bio is required.")
                .MaximumLength(1000).WithMessage("Bio cannot exceed 1000 characters.");

        }
    }
}
