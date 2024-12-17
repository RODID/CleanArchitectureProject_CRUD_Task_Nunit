using Application.Interface.RepositoryInterface;
using ClassLibrary;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<OperationResult<List<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _bookRepository.GetAllBookAsync();
                if (books == null || books.Count == 0)
                {
                    return OperationResult<List<Book>>.Failure("No books found!");
                }
                return OperationResult<List<Book>>.Success(books);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Book>>.Failure("An error occured, try again!");
            }
        }
    }
}
