using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, List<Author>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public DeleteAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<Author>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToRemove = _fakeDatabase.AllAuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);
            if (authorToRemove != null)
            {
                _fakeDatabase.AllAuthorsFromDB.Remove(authorToRemove);
            }
            return Task.FromResult(_fakeDatabase.AllAuthorsFromDB);
        }
    }
}
