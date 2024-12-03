using MediatR;
using Domain;
using Infrastructure.Database;

namespace Application.Commands.Users
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly FakeDatabase _fakeDatabase;
        public AddNewUserCommandHandler(FakeDatabase fakeDatabase) 
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
