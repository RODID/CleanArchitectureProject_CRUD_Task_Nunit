using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, List<Author>>
    {
        private readonly FakeDatabase _fakseDatabase;

        public AddAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakseDatabase = fakeDatabase; ;
        }

        public Task<List<Author>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            _fakseDatabase.AllAuthorsFromDB.Add(request.NewAuthor);
            return Task.FromResult(_fakseDatabase.AllAuthorsFromDB);
        }
    }
}
