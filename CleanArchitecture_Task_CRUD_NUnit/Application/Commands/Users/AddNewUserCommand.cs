using Application.Dtos;
using Domain;
using MediatR;

namespace Application.Commands.Users
{
    public class AddNewUserCommand : IRequest<User>
    {
        public AddNewUserCommand(UserDTO newUser)
        {
            newUser = newUser;
        }
        public UserDTO newUser { get; }
    }
}
