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
            var query = new GetAllBooksQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Book>> GetBookById(int bookId)
        {
            var query = new GetBookByIdQuery(bookId);
            var book = await _mediator.Send(query);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
        {
            var command = new AddBookCommand(book);
            var addedBook = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { bookId = addedBook.BookId }, addedBook);
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult> UpdateBook(int bookId, [FromBody] Book book)
        {
            if (bookId != book.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            var command = new UpdateBookCommand(book);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var command = new DeleteBookCommand(bookId);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
