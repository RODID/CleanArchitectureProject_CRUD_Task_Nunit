using Application.Interface.RepositoryInterface;
using Domain;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUserQuery, OperationResult<List<User>>>
    {
        private readonly IGenericRepository<User, Guid> _userRepository;
        public GetAllUsersQueryHandler(IGenericRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult<List<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                if (users == null || !users.Any())
                {
                    return OperationResult<List<User>>.Failure("No users found!");
                }
                return OperationResult<List<User>>.Success(users.ToList());
            }
            catch (Exception ex)
            {
                return OperationResult<List<User>>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
