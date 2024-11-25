using Application.Commands.Books;
using Application.Queries.Books;
using ClassLibrary;
using MediatR;
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
                return books;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("{bookId}")]
        //public async Task<ActionResult<Book>> GetBookById(int bookId)
        //{
        //    var query = new GetBookByIdQuery(bookId);
        //    var book = await _mediator.Send(query);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(book);
        //}

        [HttpPost]
        public async void Post([FromBody] Book bookToAdd)
        {
            await _mediator.Send(new AddBookCommand(bookToAdd));
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<Book>> UpdateBook(int bookId, [FromBody]  UpdateBookCommand updateBookCommand)
        {
            if (bookId != updateBookCommand.BookId)
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

        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            await _mediator.Send(new DeleteBookCommand(bookId));
            return NoContent();
        }
    }
}
