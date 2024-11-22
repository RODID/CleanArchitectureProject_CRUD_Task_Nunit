using MediatR;
using ClassLibrary;
using AutoMapper;
using Application.Interfaces;

namespace Application.Commands.Books
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper  _mapper;

        public AddBookCommandHandler(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            _repository.Add(book);

            return Task.FromResult(book.Id);       
        }
    }
}
