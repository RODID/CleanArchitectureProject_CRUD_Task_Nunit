using Application.Interfaces;
using ClassLibrary;
using MediatR;

namespace Application.Commands.Books
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository<Book> _repository;

        public UpdateBookCommandHandler(IBookRepository<Book> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.Update(request.UpdateBook);
            return Task.FromResult(result);
        }
    }
}
