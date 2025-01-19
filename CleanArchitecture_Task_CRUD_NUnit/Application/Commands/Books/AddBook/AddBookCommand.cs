using Application.Dtos;
using Domain;
using Domain.CommandOperationResult;
using MediatR;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommand : IRequest<OperationResult<GetAllBooksDto>>
    {
        public AddBookCommand(string title,int yearPublished, string description)
        {
            Title = title;
            YearPublished = yearPublished;
            Description = description;
        }

        public string Title { get; set; }
        public int YearPublished { get; set; }
        public string Description { get; set; }


    }
}
