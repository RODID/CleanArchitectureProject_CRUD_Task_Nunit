using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, OperationResult<Author>>
    {
        private readonly IGenericRepository<Author, int> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IGenericRepository<Author, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Author>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _repository.GetByIdAsync(request.AuthorId);
                if (author == null)
                {
                    return OperationResult<Author>.Failure("Author not found.");
                }

                _mapper.Map(request, author); 
                await _repository.UpdateAsync(author);

                return OperationResult<Author>.Success(author);
            }
            catch (Exception ex)
            {
                return OperationResult<Author>.Failure($"Error updating author: {ex.Message}");
            }
        }
    }
}
