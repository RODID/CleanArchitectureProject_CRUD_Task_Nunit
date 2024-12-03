using Domain;
using Domain.CommandOperationResult;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, OperationResult<List<Author>>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public AddAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase; ;
        }

        public Task<OperationResult<List<Author>>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_fakeDatabase.AllAuthorsFromDB.Exists(a => a.Name == request.NewAuthor.Name))
                {
                    return Task.FromResult(OperationResult<List<Author>>.Failure("Author already exists, Failed to add auhtor"));
                }

                _fakeDatabase.AllAuthorsFromDB.Add(request.NewAuthor);

                return Task.FromResult(OperationResult <List<Author>>.Success(_fakeDatabase.AllAuthorsFromDB, "Author added successfuly"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<List<Author>>.Failure(ex.Message, "An error occured while adding the author."));
            }

        }
    }
}
