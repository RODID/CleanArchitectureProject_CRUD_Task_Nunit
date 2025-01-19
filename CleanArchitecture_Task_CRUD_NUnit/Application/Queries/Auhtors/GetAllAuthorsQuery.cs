using Application.Dtos;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAllAuthorsQuery : IRequest<OperationResult<List<GetAuthorDto>>>
    {

    }
}
