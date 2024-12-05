using Application.Commands.Authors;
using Application.Commands.Authors.AddAuthor;
using Application.Commands.Authors.DeleteAuthor;
using Application.Commands.Authors.UpdateAuthor;
using Application.Queries.Auhtors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            try
            {
                var authors = await _mediator.Send(new GetAllAuthorsQuery());
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async void PostAuthor([FromBody] string authorToAdd)
        {
            await _mediator.Send(new AddAuthorCommand(authorToAdd));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> PutAuthor(Guid id, [FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            if (id!= updateAuthorCommand.AuthorId)
            {
                return BadRequest("The Author ID in the URL and the body dosent match.");
            }
            try
            {
                var updateAuthor = await _mediator.Send(updateAuthorCommand);

                return Ok(updateAuthor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
                await _mediator.Send(new DeleteAuthorCommand(id));
                return NoContent();
        }
    }
}
