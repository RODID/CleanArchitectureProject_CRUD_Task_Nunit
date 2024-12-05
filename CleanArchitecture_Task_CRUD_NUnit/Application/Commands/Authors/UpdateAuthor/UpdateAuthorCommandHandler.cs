using Domain;
using Domain.CommandOperationResult;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, OperationResult<Author>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<OperationResult<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = _fakeDatabase.AllAuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);

            if (authorToUpdate == null)
            {
                return Task.FromResult(OperationResult<Author>.Failure(
                    $"Author with ID {request.AuthorId} wasn't found.",
                    "Update operation failed"
                ));
            }
            authorToUpdate.Name = request.NewName;

            return Task.FromResult(OperationResult<Author>.Success(
                authorToUpdate,
                "Author updated successfully"
            ));
        }
    }
}
