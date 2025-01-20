using MediatR;
using Domain;
using Domain.CommandOperationResult;
using Application.Interface.RepositoryInterface;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Users
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, OperationResult<User>>
    {
        private readonly IGenericRepository<User, Guid> _userRepository;
        private readonly ILogger<AddNewUserCommandHandler> _logger;

        public AddNewUserCommandHandler(IGenericRepository<User, Guid> userRepository, ILogger<AddNewUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<OperationResult<User>> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return OperationResult<User>.Failure("Invalid user data.");
                }

                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email
                };

                var addedUser = await _userRepository.AddAsync(newUser);

                return OperationResult<User>.Success(addedUser, "User Successfully added.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the user.");
                var innerExceptionMessage = ex.InnerException?.Message ?? "No inner exception available.";
                return OperationResult<User>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
