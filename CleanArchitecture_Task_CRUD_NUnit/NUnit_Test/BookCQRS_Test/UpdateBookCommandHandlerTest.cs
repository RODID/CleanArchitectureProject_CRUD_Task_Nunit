using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Database;
using Test_CRUD.AuthorCQRS_Test;
using Application.Commands.Books.DeleteBook;
using Application.Commands.Books.UpdateBook;

namespace Test_CRUD.BookCQRS_Test
{
    public class UpdateBookCommandHandlerTest
    {
        private FakeDatabase _fakeDatabase;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
        }

        //Updating Title and description
        public async Task UpdateBookCommandHandler_ShouldUpdateBook_WheneValidInformationIsGiven()
        {
            var existingBook = new Book(1, "Old Book Title", "Old Description");
            _fakeDatabase.AllBooksFromDB.Add(existingBook);

            var command = new UpdateBookCommand(1, "New Book Title", "New Description");
            var handler = new UpdateBookCommandHandler(_fakeDatabase);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("New Book Name", result.Title);
            Assert.AreEqual("New Book Name", result.Description);
            Assert.AreEqual(1, _fakeDatabase.AllBooksFromDB.Count);
            Assert.AreEqual(result, _fakeDatabase.AllBooksFromDB[0]);
        }


        //Updating only Title 
        public async Task UpdateBookCommandHandler_ShouldUpdateOnlyBookName_WheneDescriptionIsUnchanged()
        {
            var existingBook = new Book(1, "Old Book Name", "OriginalDescription");
            _fakeDatabase.AllBooksFromDB.Add(existingBook);

            var command = new UpdateBookCommand(1, "Updated Book Name", existingBook.Description);
            var handler = new UpdateBookCommandHandler(_fakeDatabase);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Book Name", result.Title);
            Assert.AreEqual("Original Description", result.Description);
        }
    }
}
