using Application.Interface.RepositoryInterface;
using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<OperationResult<List<Book>>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (books == null)
                {
                    return OperationResult<List<Book>>.Failure("No books found with the specified ID.");
                }
                return OperationResult<List<Book>>.Success(new List<Book> { books});
            }
            catch (Exception ex)
            {
                return OperationResult<List<Book>>.Failure("An error occured!");
            }
        }
    }
}
