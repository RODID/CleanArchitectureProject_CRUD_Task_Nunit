using Domain;
using Domain.CommandOperationResult;
using MediatR;


namespace Application.Queries.Users
{
    public class GetAllUserQuery : IRequest<OperationResult<List<User>>>
    {

    }
}
