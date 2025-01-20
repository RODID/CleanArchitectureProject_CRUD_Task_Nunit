using Application.Interface.RepositoryInterface;
using Application.Queries.Login.Helpers;
using MediatR;
using Domain;
using Domain.CommandOperationResult;

namespace Application.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OperationResult<string>>
    {
        private readonly IGenericRepository<User, Guid> _userRepository;
        private readonly TokenHelper _tokenHelper;

        public LoginUserQueryHandler(IGenericRepository<User, Guid> userRepository, TokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<OperationResult<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(user =>
                user.UserName == request.LoginUser.UserName &&
                user.Password == request.LoginUser.Password);

            if (user == null)
            {
                return OperationResult<string>.Failure("Invalid username or passwrod");
            }

            string token = _tokenHelper.GenerateJwtToken(user);

            return OperationResult<string>.Success(token, "Login successful");
        }
    }
}   
