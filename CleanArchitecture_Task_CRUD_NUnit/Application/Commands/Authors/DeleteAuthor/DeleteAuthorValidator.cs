using FluentValidation;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator() 
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("ID must not be empty.")
                .Must(id => id != Guid.Empty).WithMessage("ID must be a valid GUID.");

        }
    }
}
