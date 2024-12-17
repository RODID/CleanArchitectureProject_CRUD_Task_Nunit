using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToRemove = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
                if (authorToRemove == null)
                {
                    return OperationResult<bool>.Failure("Author not found", "Failed to delete author");
                }

                await _authorRepository.DeleteAuthorAsync(authorToRemove.Id);

                var allAuthors = await _authorRepository.GetAllAuthorAsync();

                return OperationResult<bool>.Success(true, "Author successfully deleted!");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex.Message, "An error occured when removing author!");
            }
        }
    }
}
