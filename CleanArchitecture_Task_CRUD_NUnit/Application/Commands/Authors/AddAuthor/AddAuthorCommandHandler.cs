using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Castle.Core.Logging;
using Domain;
using Domain.CommandOperationResult;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, OperationResult<GetAuthorDto>>
    {
        private readonly IGenericRepository<Author, int> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddAuthorCommand> _logger;

        public AddAuthorCommandHandler(IGenericRepository<Author, int> repository, IMapper mapper, ILogger<AddAuthorCommand> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<GetAuthorDto>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Processing AddAuthorCommand for {NewAuthor}", request.NewAuthor);

                var authorToCreate = _mapper.Map<Author>(request.NewAuthor);
                _logger.LogInformation("Mapped Author: {@AuthorToCreate}", authorToCreate);

                if (authorToCreate == null)
                {
                    return OperationResult<GetAuthorDto>.Failure("Failed to map the author.");
                }

                var createdAuthor = await _repository.AddAsync(authorToCreate);
                _logger.LogInformation("Created Author: {@CreatedAuthor}", createdAuthor);

                if (createdAuthor == null)
                {
                    return OperationResult<GetAuthorDto>.Failure("Failed to save the author to the database.");
                }

                var mappedAuthor = _mapper.Map<GetAuthorDto>(createdAuthor);
                _logger.LogInformation("Mapped Author DTO: {@MappedAuthor}", mappedAuthor);

                if (mappedAuthor == null)
                {
                    return OperationResult<GetAuthorDto>.Failure("Failed to map the created author.");
                }

                return OperationResult<GetAuthorDto>.Success(mappedAuthor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the author.");
                return OperationResult<GetAuthorDto>.Failure($"An error occurred while adding author: {ex.Message}");
            }
        }
    }
}
