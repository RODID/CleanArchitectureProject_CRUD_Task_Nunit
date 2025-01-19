using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<GetAuthorDto>>>
    {
        private readonly IGenericRepository<Author, int> _repository;
        private readonly IMapper _mapper;
        public GetAllAuthorsQueryHandler(IGenericRepository<Author, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<GetAuthorDto>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return OperationResult<List<GetAuthorDto>>.Failure("Request cannot be null.");
            }

            try
            {
                var allAuthorsFromDatabase = await _repository.GetAllAsync();

                if (allAuthorsFromDatabase == null || !allAuthorsFromDatabase.Any())
                {
                    return OperationResult<List<GetAuthorDto>>.Failure("No authors found in the database.");
                }

                var mappedAuthorsFromDatabase = _mapper.Map<List<GetAuthorDto>>(allAuthorsFromDatabase);

                return OperationResult<List<GetAuthorDto>>.Success(mappedAuthorsFromDatabase);
            }
            catch (Exception ex)
            {
                return OperationResult<List<GetAuthorDto>>.Failure("An error occurred while retrieving authors: " + ex.Message);
            }
        }
    }
}
