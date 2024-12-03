using Application.Dtos;
using MediatR;

namespace Application.Queries.Login
{
    public  class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserDTO loginUser) 
        {
            LoginUser = loginUser;
        }

        public UserDTO LoginUser { get; }
    }
}
