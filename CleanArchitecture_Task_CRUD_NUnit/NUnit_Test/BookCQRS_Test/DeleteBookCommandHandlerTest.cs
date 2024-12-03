using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Database;
using Test_CRUD.AuthorCQRS_Test;
using Application.Commands.Books.DeleteBook;

namespace Test_CRUD.BookCQRS_Test
{
    public class DeleteBookCommandHandlerTest
    {
        private FakeDatabase _fakeDatabase;

        [SetUp]
        public void SetUp() 
        {
            _fakeDatabase = new FakeDatabase();
        }

        [Test]
        public async Task DeleteBookCommandHandler_ShouldRemoveBook_WhenBookExists()
        {
            var bookToDelete = new Book(1, "Author", "Book Title");
            _fakeDatabase.AllBooksFromDB.Add(bookToDelete);

            var command = new DeleteBookCommand(1);
            var handler = new DeleteBookCommandHandler(_fakeDatabase);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
            Assert.AreEqual(0, _fakeDatabase.AllBooksFromDB.Count);
        }

        [Test]
        public async Task DeleteBookCommandHandler_ShouldReturnFalse_WhenBookDoseNotExist()
        {
            var command = new DeleteBookCommand(99);
            var handler = new DeleteBookCommandHandler(_fakeDatabase);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
            Assert.AreEqual(0, _fakeDatabase.AllBooksFromDB.Count);
        }
    }
}
