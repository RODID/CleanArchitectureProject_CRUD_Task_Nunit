using NUnit.Framework;
using ClassLibrary;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Database;
using Application.Commands.Books.AddBook;
using Test_CRUD.AuthorCQRS_Test;

namespace Test_CRUD.BookCQRS_Test
{
    public class AddBookCommandHandlerTest
    {

        private FakeDatabase _fakeDatabase;

        [SetUp]
        public void SetUp() 
        {
            _fakeDatabase = new FakeDatabase();
        } 
        [Test]
        [TestCase(1, "Author", "Book Title")]
        public async Task AddBookCommandHandler_ShouldAddBook_WhenValidDataProvided(int id, string author, string bookName)
        {
            //ARRANGE
            var bookToAdd = new Book(id, author, bookName);
            var addBookCommand = new AddBookCommand(bookToAdd);

            var handler = new AddBookCommandHandler(_fakeDatabase);
            //ACT
            var result = await handler.Handle(addBookCommand, CancellationToken.None);

            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);  // Check if the book was added
            Assert.AreEqual(id, result[0].Id);
            Assert.AreEqual(bookName, result[0].Title);
            Assert.AreEqual(author, result[0].Description);
        }

        [Test]
        public async Task CreateBook_ShouldNotAddBook_WheneSameBookExists()
        {
            var existingBook = new Book (1, "Author", "Book Title");
            _fakeDatabase.AllBooksFromDB.Add(existingBook);
            //Arrange
            var bookShouldNotAdd = new Book(1, "Author", "Title");
            var command = new AddBookCommand(bookShouldNotAdd);

            var handler = new AddBookCommandHandler(_fakeDatabase);
            
            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.AreEqual(1, _fakeDatabase.AllBooksFromDB.Count);
            Assert.AreEqual(existingBook, _fakeDatabase.AllBooksFromDB[0]);
            Assert.True(result.Contains(existingBook));
        }
    }
}
