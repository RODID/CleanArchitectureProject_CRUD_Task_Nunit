using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Authors
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public string AuthorName { get; }

        public DeleteAuthorCommand(string authorName) 
        {
            AuthorName = authorName; 
        }


    }
}
