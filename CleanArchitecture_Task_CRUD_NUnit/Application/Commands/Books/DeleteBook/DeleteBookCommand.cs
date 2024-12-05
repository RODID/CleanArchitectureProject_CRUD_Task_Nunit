﻿using MediatR;
using ClassLibrary;
using Domain.CommandOperationResult;


namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<OperationResult<bool>>
    {

        public Guid BookId { get; }

        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
