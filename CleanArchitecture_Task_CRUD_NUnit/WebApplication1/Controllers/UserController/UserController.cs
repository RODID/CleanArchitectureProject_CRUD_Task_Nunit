using Application.Commands.Users;
using Application.Dtos;
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

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("getAllUsers")]
        public async Task <IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUserQuery()));
        }

        [HttpPost]
        [Route("Regiter")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO newUser)
        {
            var command = new AddNewUserCommand(newUser);
            return Ok(await _mediator.Send(command));

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserDTO userWantingToLogin)
        {
            return Ok(await _mediator.Send(new LoginUserQuery(userWantingToLogin)));
        }
    }
}
