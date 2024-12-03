using Domain;
using Domain.CommandOperationResult;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<List<Author>>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<OperationResult<List<Author>>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToRemove = _fakeDatabase.AllAuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);
                if (authorToRemove == null)
                {
                    return Task.FromResult(OperationResult<List<Author>>.Failure("Auhtor not found", "failed to delete author"));
                }

                _fakeDatabase.AllAuthorsFromDB.Remove(authorToRemove);

                return Task.FromResult(OperationResult<List<Author>>.Success(_fakeDatabase.AllAuthorsFromDB, "Author Successfully removed!"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<List<Author>>.Failure(ex.Message, "An error occurred when removing Author from list!"));
            }
           
        }
    }
}
