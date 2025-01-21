using Application.Dtos;
using Application.Interface.RepositoryInterface;
using AutoMapper;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, OperationResult<UpdateAuthorDto>>
    {
        private readonly IGenericRepository<Author, Guid> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IGenericRepository<Author, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<UpdateAuthorDto>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAuthor = await _repository.GetByIdAsync(request.Dto.Id);
                if (existingAuthor == null)
                {
                    return OperationResult<UpdateAuthorDto>.Failure("Auhtor not found.");
                }

                existingAuthor.Name = request.Dto.Name;
                existingAuthor.Bio = request.Dto.Bio;

                var updatedAuthor = await _repository.UpdateAsync(existingAuthor);

                if (updatedAuthor == null)
                {
                    return OperationResult<UpdateAuthorDto>.Failure("Failed to update Author.");
                }

                var updatedDto = _mapper.Map<UpdateAuthorDto>(updatedAuthor);
                return OperationResult<UpdateAuthorDto>.Success(updatedDto);
            }
            catch (Exception ex)
            {
                return OperationResult<UpdateAuthorDto>.Failure($"An error occurred: {ex.Message}");
            }
        }
    }
}
