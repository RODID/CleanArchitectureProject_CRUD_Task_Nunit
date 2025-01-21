using Application.Commands.Authors.AddAuthor;
using Application.Commands.Authors.DeleteAuthor;
using Application.Commands.Authors.UpdateAuthor;
using Application.Commands.Books.UpdateBook;
using Application.Dtos;
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
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IMediator mediator, ILogger<AuthorController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            _logger.LogInformation("Fetching all Authors at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
            try
            {
                var operationResult = await _mediator.Send(new GetAllAuthorsQuery());
                _logger.LogInformation("Successfully retrieved all Authors");
                return Ok(operationResult.Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Author at {time}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommand addAuthorCommand)
        {
            _logger.LogInformation("Attempting to add a new author with name: {AuthorName}", addAuthorCommand.NewAuthor);

            try
            {
                var operationResult = await _mediator.Send(addAuthorCommand);

                if (!operationResult.IsSuccess)
                {
                    _logger.LogWarning("Failed to add author: {AuthorName}, Reason: {Reason}", addAuthorCommand.NewAuthor, operationResult.Message);
                    return StatusCode(500, operationResult.Message);
                }

                _logger.LogInformation("Successfully added author: {NewAuthor}", operationResult.Data);
                return CreatedAtAction(nameof(GetAllAuthors), new { id = operationResult.Data.Id }, operationResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the author: {AuthorName}", addAuthorCommand.NewAuthor);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Author>> UpdateAuthor(Guid id, [FromBody] UpdateAuthorDto dto)
        {
            _logger.LogInformation("Updating Book with ID: {id}", id);

            try
            {
                if (id != dto.Id)
                {
                    _logger.LogWarning("ID mismatch: URL ID {id} does not match body ID {bookId}", id, dto.Id);
                    return BadRequest("The book ID in the URL and the body do not match.");
                }

                var updateAuthorCommand = new UpdateAuthorCommand(dto);

                var operationResult = await _mediator.Send(updateAuthorCommand);

                if (operationResult.IsSuccess)
                {
                    _logger.LogInformation("Successfully updated Author with ID: {id}", id);
                    return Ok(operationResult.Data);
                }

                _logger.LogWarning("Failed to update Author with ID {id}: {errorMessage}", id, operationResult.ErrorMessage);
                return BadRequest(operationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Auhtor with ID: {id}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var command = new DeleteAuthorCommand(id);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}

