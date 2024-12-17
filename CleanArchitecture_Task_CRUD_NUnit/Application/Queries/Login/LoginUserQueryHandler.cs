using Application.Interface.RepositoryInterface;
using Application.Queries.Login.Helpers;
using MediatR;

namespace Application.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository  _userRepository;
        private readonly TokenHelper _tokenHelper;
        public LoginUserQueryHandler(IUserRepository userRepository, TokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByCredentialsAsync(request.LoginUser.UserName, request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or passwor");
            }

            string token = "TOKEN TO RETURN";

            return Task.FromResult(token);
        }
    }
}   
