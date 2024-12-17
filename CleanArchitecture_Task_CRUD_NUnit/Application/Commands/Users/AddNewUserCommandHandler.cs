using MediatR;
using Domain;
using Domain.CommandOperationResult;
using Application.Interface.RepositoryInterface;

namespace Application.Commands.Users
{
    internal sealed class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, OperationResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public AddNewUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                    Password = request.Password
                };

                var addedUser = await _userRepository.AddUserAsync(newUser);

                return OperationResult<User>.Success(addedUser, "User Successfully added.");

            }
            catch (Exception ex)
            {
                return OperationResult<User>.Failure($"An error occured: {ex.Message}");
            }
           
        }
    }
}
