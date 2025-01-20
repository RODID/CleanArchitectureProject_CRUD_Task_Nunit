using FluentValidation;

namespace Application.Queries.Books
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Id is required")
                .NotNull().WithMessage("Id is required");
        }
    }
}
