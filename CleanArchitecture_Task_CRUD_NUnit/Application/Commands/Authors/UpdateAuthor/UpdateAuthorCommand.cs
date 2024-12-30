using Domain;
using Domain.CommandOperationResult;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<OperationResult<Author>>
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage ="The NewName field is required.")]
        public string NewName { get; set; }

        public UpdateAuthorCommand(Guid authorId, string newName)
        {
            AuthorId = authorId;
            NewName = newName;
        }

        public UpdateAuthorCommand()
        {

        }
    }
}
