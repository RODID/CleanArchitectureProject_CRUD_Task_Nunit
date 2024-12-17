using MediatR;
using ClassLibrary;
using Domain.CommandOperationResult;
using Application.Interface.RepositoryInterface;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OperationResult<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Title))
                {
                    return OperationResult<Book>.Failure("Book title is required.");
                }

                var newBook = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                };
                var addedBook = await _bookRepository.AddBookAsync(newBook);

                return OperationResult<Book>.Success(addedBook, "Book added Successfully!");
            }
            catch (Exception ex)
            {
                return OperationResult<Book>.Failure($"An error occurred while adding the book: ", ex.Message);
            }
        }
    }
}
