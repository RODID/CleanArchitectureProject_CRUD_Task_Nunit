using Application.Dtos;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Login
{
    public  class LoginUserQuery : IRequest <OperationResult<string>>
    {
        public LoginUserQuery(UserDTO loginUser) 
        {
            LoginUser = loginUser;
        }

        public UserDTO LoginUser { get; }
    }
}
