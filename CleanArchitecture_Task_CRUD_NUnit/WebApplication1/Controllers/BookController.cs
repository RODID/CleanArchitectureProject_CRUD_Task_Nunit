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

            _logger.LogInformation("Fetching all Books at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            try
            {
                var operationResult = await _mediator.Send(new GetAllBooksQuery());
                _logger.LogInformation("Successfully retrived all Books");
                return Ok(operationResult.Data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Books ath {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody, Required] AddBookDTO bookToAdd)
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
        [Authorize]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody]  UpdateBookDto updateBookDto)
        {
            _logger.LogInformation("Updating Book with ID: {id}", id);

            try
            {
                if (id != updateBookDto.Id)
                {
                    _logger.LogWarning("ID mismatch: URL ID {id} does not match body ID {bookId}", id, updateBookDto.Id);
                    return BadRequest("The book ID in the URL and the body do not match.");
                }

                var updateBookCommand = new UpdateBookCommand(updateBookDto);

                var operationResult = await _mediator.Send(updateBookCommand);

                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("Successfully updated Book with ID: {id}", id);
                    return Ok(operationResult.Data);
                }

                _logger.LogWarning("Failed to update Book with ID {id}: {errorMessage}", id, operationResult.ErrorMessage);
                return BadRequest(operationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Book with ID: {id}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
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
