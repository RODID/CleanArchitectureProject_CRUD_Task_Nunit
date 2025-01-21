using FluentValidation;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Dto.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .Length(3, 100).WithMessage("Title must be between 3 and 100 characters.");
;
            RuleFor(x => x.Dto.Bio)
                .NotEmpty().WithMessage("Author Bio is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Dto.Id)
                .NotEmpty().WithMessage("Author ID is required.");
        }
    }
}
