using Domain;
using MediatR;

namespace Application.Queries.Auhtors
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {

    }
}
