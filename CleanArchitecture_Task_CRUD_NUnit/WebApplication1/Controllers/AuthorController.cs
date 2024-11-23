using Application.Commands.Authors;
using Application.Queries.Auhtors;
using Domain;
using MediatR;
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

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var query = new GetAllAuthorsQuery();
            var authors = await _mediator.Send(query);
            return Ok(authors);
        }

        [HttpGet("{authorName}")]
        public async Task<ActionResult<Author>> GetAuthorById(string authorName)
        {
            var query = new GetAuthorByIdQuery(authorName);
            var author = await _mediator.Send(query);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            var command = new AddAuthorCommand(author);
            var addedAuthor = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAuthorById), new { authorName = addedAuthor.AuthorName }, addedAuthor);
        }

        [HttpPut("{authorName}")]
        public async Task<ActionResult> UpdateAuthor(string authorName, [FromBody] Author author)
        {
            if (authorName != author.AuthorName)
            {
                return BadRequest("Author name mismatch.");
            }

            var command = new UpdateAuthorCommand(author);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{authorName}")]
        public async Task<ActionResult> DeleteAuthor(string authorName)
        {
            var command = new DeleteAuthorCommand(authorName);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
