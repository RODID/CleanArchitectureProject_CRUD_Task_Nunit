using Domain;
using Domain.CommandOperationResult;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, OperationResult<bool>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public AddAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase; ;
        }

        public Task<OperationResult<bool>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
               if (string.IsNullOrWhiteSpace(request.Name))
               {
                 return Task.FromResult(OperationResult<bool>.Failure("Auhtor name is invalid."));
               }

                if (_fakeDatabase.AllAuthorsFromDB.Any(a => a.Name == request.Name))
                {
                    return Task.FromResult(OperationResult<bool>.Failure("Duplicate author detected."));
                }

               _fakeDatabase.AllAuthorsFromDB.Add(new Author(Guid.NewGuid(), request.Name));

                return Task.FromResult(OperationResult<bool>.Success(true));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<bool>.Failure("An Error Occured"));
            }
        }
    }
}
