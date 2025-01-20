using Application.Commands.Authors.DeleteAuthor;
using Application.Commands.Books.AddBook;
using Application.Commands.Books.DeleteBook;
using Application.Commands.Books.UpdateBook;
using Application.Dtos;
using Application.Queries.Books;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IMediator mediator, ILogger<BookController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<BookController> _logger = logger;

       

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            if (!result.IsSuccess)
            {
                return StatusCode(500, result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody, Required] AddBookDTO bookToAdd)
        {
            _logger.LogInformation("Adding new book with title: {Title}", bookToAdd.Title);

            try
            {
                var operationResult = await _mediator.Send(new AddBookCommand(bookToAdd.Title, bookToAdd.YearPublished, bookToAdd.Description));

                if (!operationResult.IsSuccess)
                {
                    return StatusCode(500, operationResult.Message);
                }

                _logger.LogInformation("Book {Title} added successfully", operationResult.Data.Title);
                return Ok(operationResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the book.");
                return StatusCode(500, "An error occurred while processing your request.");
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
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
