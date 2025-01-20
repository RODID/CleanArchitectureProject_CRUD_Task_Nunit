using FluentValidation;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Author name is required.");
        }
    }
}
