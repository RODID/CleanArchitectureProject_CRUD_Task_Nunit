using Application.Commands.Authors.AddAuthor;
using Application.Commands.Authors.DeleteAuthor;
using Application.Commands.Authors.UpdateAuthor;
using Application.Queries.Auhtors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult> PostAuthor([FromBody] string authorToAdd)
        {
            try
            {
                await _mediator.Send(new AddAuthorCommand(authorToAdd));
                return Ok("Author added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> UpdateAuthor(Guid id, [FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            try
            {
                if (id != updateAuthorCommand.AuthorId)
                {
                    return BadRequest("The Author ID in the URL and the body doesn't match.");
                }

                // Log received data
                Console.WriteLine($"Received ID: {id}");
                Console.WriteLine($"Received Body: {JsonConvert.SerializeObject(updateAuthorCommand)}");

                var updateAuthor = await _mediator.Send(updateAuthorCommand);
                return Ok(updateAuthor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAuthorAsync(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteAuthorCommand(id));

                if (result.IsSuccess)
                {
                    return NoContent(); 
                }

                return NotFound(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
