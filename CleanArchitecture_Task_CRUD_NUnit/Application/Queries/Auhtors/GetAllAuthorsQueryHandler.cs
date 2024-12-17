using Application.Interface.RepositoryInterface;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<Author>>>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var authors = await _authorRepository.GetAllAuthorAsync();
                if (authors == null || authors.Count == 0)
                {
                    return OperationResult<List<Author>>.Failure("No author found!");
                }
                return OperationResult<List<Author>>.Success(authors);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Author>>.Failure("An error occured, try again!");
            }
        }
    }
}
