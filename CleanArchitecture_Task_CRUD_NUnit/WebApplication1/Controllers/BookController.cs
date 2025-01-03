using Application.Commands.Books.AddBook;
using Application.Commands.Books.DeleteBook;
using Application.Commands.Books.UpdateBook;
using Application.Dtos;
using Application.Queries.Books;
using ClassLibrary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            try
            {
                var books = await _mediator.Send(new GetAllBooksQuery());
                return Ok (books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] AddBookDTO bookToAdd)
        {
            try
            {
                var command = new AddBookCommand(bookToAdd.Title, bookToAdd.Description);
                var result = await _mediator.Send(command);

                if (!result.IsSuccess)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return CreatedAtAction(nameof(GetAllBooks), new { id = result.Data.Id }, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(Guid id, [FromBody]  UpdateBookCommand updateBookCommand)
        {
            if (id != updateBookCommand.BookId)
            {
                return BadRequest("The book ID in the URL and the body do not match. ");
            }

            try
            {
                var updateBook = await _mediator.Send(updateBookCommand);

                    return Ok(updateBook);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
