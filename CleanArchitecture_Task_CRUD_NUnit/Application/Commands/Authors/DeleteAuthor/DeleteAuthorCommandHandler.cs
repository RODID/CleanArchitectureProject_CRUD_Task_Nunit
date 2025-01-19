using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author, Guid> _repository;
        public DeleteAuthorCommandHandler(IGenericRepository<Author, Guid> repository) 
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToRemove = await _repository.DeleteAsync(request.AuthorId);
                if (!authorToRemove)
                {
                    return OperationResult<bool>.Failure("Author not found", "Failed to delete author");
                }
                return OperationResult<bool>.Success(true);

            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex.Message, "An error occured when removing author!");
            }
        }
    }
}
