using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, OperationResult<List<GetAllBooksDto>>>
    {
        private readonly IGenericRepository<Book, int> _repository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IGenericRepository<Book, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<GetAllBooksDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return OperationResult<List<GetAllBooksDto>>.Failure("Request cannot be null.");
            }

            try
            {
                var allbooksFromDatabase = await _repository.GetAllAsync();

                if (allbooksFromDatabase == null || !allbooksFromDatabase.Any())
                {
                    return OperationResult<List<GetAllBooksDto>>.Failure("No authors found in the database.");
                }

                var mappedBooksFromDatabase = _mapper.Map<List<GetAllBooksDto>>(allbooksFromDatabase);

                return OperationResult<List<GetAllBooksDto>>.Success(mappedBooksFromDatabase);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetAllBooksDto>>.Failure("An error occurred while retrieving authors: " + ex.Message);
            }
        }
    }
}
