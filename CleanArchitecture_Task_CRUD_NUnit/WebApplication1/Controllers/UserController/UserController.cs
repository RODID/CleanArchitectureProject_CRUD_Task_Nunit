using Application.Commands.Users;
using Application.Dtos;
using Application.Interface.RepositoryInterface;
using Application.Queries.Auhtors;
using Application.Queries.Login;
using Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("getAllUsers")]
        public async Task <IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Fetching all users at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));

            try
            {
                var operationResult = await _mediator.Send(new GetAllUserQuery());
                return Ok(operationResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured whule fetching users at time {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO newUser)
        {
            _logger.LogInformation("Attempting to register user: {UserName}", newUser.UserName);

            try
            {
                var operationResult = await _mediator.Send(new AddNewUserCommand(newUser));

                if (!operationResult.IsSuccess)
                {
                    _logger.LogWarning("Failed to register user: {UserName}", newUser.UserName, operationResult.Message);
                    return BadRequest(operationResult.Message);
                }

                _logger.LogInformation("Successfully registered user: {UserName}", newUser.UserName);
                return Ok(operationResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering user: {Username}", newUser.UserName);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserDTO userWantingToLogin)
        {
            _logger.LogInformation("Attempting to log in user: {UserName}", userWantingToLogin.UserName);

            try
            {
                var operationResult = await _mediator.Send(new LoginUserQuery(userWantingToLogin));

                if (!operationResult.IsSuccess)
                {
                    _logger.LogWarning("Failed login attempt for user: {UserName}, Reason: {Reason}", userWantingToLogin.UserName, operationResult.Message);
                    return Unauthorized(operationResult.Message);
                }

                _logger.LogInformation("User {UserName} logged in successfully.", userWantingToLogin.UserName);
                return Ok(operationResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login attempt for user: {UserName}", userWantingToLogin.UserName);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
