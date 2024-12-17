using Application.Interface.RepositoryInterface;
using ClassLibrary;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUserQuery, OperationResult<List<User>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult<List<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                if (users == null || users.Count == 0)
                {
                    return OperationResult<List<User>>.Failure("No users found!");
                }
                return OperationResult<List<User>>.Success(users);
            }
            catch (Exception ex)
            {
                return OperationResult<List<User>>.Failure("An error occured, try again!");
            }
        }
    }
}
