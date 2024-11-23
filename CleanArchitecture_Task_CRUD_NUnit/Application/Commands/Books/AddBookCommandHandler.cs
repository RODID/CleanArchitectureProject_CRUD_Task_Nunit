using MediatR;
using ClassLibrary;
using AutoMapper;
using Application.Interfaces;

namespace Application.Commands.Books
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, List<Book>>
    {
        private readonly List<Book> _books;

        public AddBookCommandHandler(List<Book> books)
        {
            _books = books;
        }

        public Task<List<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            _books.Add(request.NewBook);
            return Task.FromResult(_books);
        }
    }
}
