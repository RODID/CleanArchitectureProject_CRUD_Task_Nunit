using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<GetAllBooksDto>>
    {

        private readonly IGenericRepository<Book, int> _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IGenericRepository<Book, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetAllBooksDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _repository.GetByIdAsync(request.BookId);
                if (book == null)
                {
                    return OperationResult<GetAllBooksDto>.Failure("Book does not exist.");
                }
                var mappedBook = _mapper.Map<GetAllBooksDto>(book);
                return OperationResult<GetAllBooksDto>.Success(mappedBook);
            }
            catch (Exception ex)
            {
                return OperationResult<GetAllBooksDto>.Failure(ex.Message);

            }
        }
    }
}
