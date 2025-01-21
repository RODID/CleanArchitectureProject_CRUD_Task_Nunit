using FluentValidation;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(x => x.Dto.Id)
                .NotEmpty().WithMessage("Book ID is required.");

            RuleFor(x => x.Dto.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(3, 100).WithMessage("Title must be between 3 and 100 characters.");

            RuleFor(x => x.Dto.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
