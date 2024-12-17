using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, OperationResult<bool>>
    {
        private readonly IAuthorRepository _authorRepository;
        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<bool>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return OperationResult<bool>.Failure("Author Name Is Innvalid");
                }

                var existingAuthors = await _authorRepository.GetAllAuthorAsync();
                if (existingAuthors.Any(a => a.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    return OperationResult<bool>.Failure("Duplicate author detected.");
                }

                var newAuthor = new Author(Guid.NewGuid(), request.Name);
                await _authorRepository.AddAuthorAsync(newAuthor);

                return OperationResult<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure("An error occurred: ", ex.Message);
            }
        }
    }
}
