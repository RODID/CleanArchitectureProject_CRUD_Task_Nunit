using MediatR;
using Domain;
using Application.Interface.RepositoryInterface;
using Microsoft.Extensions.Logging;
using Domain.CommandOperationResult;
using Application.Dtos;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, OperationResult<GetAllBooksDto>>
    {
        private readonly IGenericRepository<Book, Guid> _genericRepository;
        private readonly ILogger<AddBookCommandHandler> _logger;
        public AddBookCommandHandler(IGenericRepository<Book, Guid> genericRepository, ILogger<AddBookCommandHandler> logger)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }

        public async Task<OperationResult<GetAllBooksDto>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Book Created: {BookTitle}", request.Title);
                var book = new Book(Guid.NewGuid(), request.Title, request.YearPublished, request.Description);
                var addedBook = await _genericRepository.AddAsync(book);

                var responseDto = new GetAllBooksDto
                {
                    Id = addedBook.Id, 
                    Title = addedBook.Title,
                    Description = addedBook.Description
                };

                return OperationResult<GetAllBooksDto>.Success(responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding book");
                return OperationResult<GetAllBooksDto>.Failure("An error occurred while adding the book.");
            }
        }
    }
}
