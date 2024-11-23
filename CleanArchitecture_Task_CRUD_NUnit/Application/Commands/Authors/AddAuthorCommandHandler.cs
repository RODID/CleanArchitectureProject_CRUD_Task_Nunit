using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Authors
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly List<Author> _author;

        public AddAuthorCommandHandler(List<Author> author)
        {
            _author = author;
        }

        public Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            _author.Add(request.NewAuthor);
            return Task.FromResult(request.NewAuthor);
        }
    }
}
