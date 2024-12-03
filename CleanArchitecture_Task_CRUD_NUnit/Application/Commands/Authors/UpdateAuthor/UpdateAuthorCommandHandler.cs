using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = _fakeDatabase.AllAuthorsFromDB.FirstOrDefault(a => a.Id == request.AuthorId);

            if (authorToUpdate == null)
            {
                throw new KeyNotFoundException($"Author with ID {request.AuthorId}, wasn't found.");
            }

            authorToUpdate.Name = request.NewName;

            return Task.FromResult(authorToUpdate);
        }
    }
}
