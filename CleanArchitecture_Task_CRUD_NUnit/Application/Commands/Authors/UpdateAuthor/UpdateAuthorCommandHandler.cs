using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToUpdate = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
                if (authorToUpdate == null)
                {
                    return OperationResult<Author>.Failure(
                        $"Author with ID {request.AuthorId} wasn't found.",
                        "Update operation failed"
                    );
                }

                authorToUpdate.Name = request.NewName;
                var updatedAuthor = await _authorRepository.UpdateAuthorAsync(authorToUpdate.Id, authorToUpdate);

                return OperationResult<Author>.Success(
                    updatedAuthor,
                    "Author updated successfully"
                );
            }
            catch (Exception ex)
            {
                return OperationResult<Author>.Failure($"An error occurred: {ex.Message} - {ex.StackTrace}");
            }
        
        }
    }
}
