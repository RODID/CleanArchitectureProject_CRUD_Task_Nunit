//using NUnit.Framework;
//using Domain;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Infrastructure.Database;
//using Application.Commands.Books.AddBook;
//using Test_CRUD.AuthorCQRS_Test;

//namespace Test_CRUD.BookCQRS_Test
//{
//    public class AddBookCommandHandlerTest
//    {

//        private FakeDatabase _fakeDatabase;
//        private AddBookCommandHandler _handler;

//        [SetUp]
//        public void SetUp() 
//        {
//            _fakeDatabase = new FakeDatabase();
//            _fakeDatabase.Clear();
//            _handler = new AddBookCommandHandler(_fakeDatabase);
//        } 
//        [Test]
//        [TestCase(1, "Rodi 1", "Journey")]
//        public async Task AddBookCommandHandler_ShouldAddBook_WhenValidDataProvided(int id, string bookName, string description)
//        {
//            _fakeDatabase.Clear();
//            //ARRANGE
//            var bookId =Guid.NewGuid();
//            var bookToAdd = new Book(bookId, bookName, description);
//            var addBookCommand = new AddBookCommand(bookToAdd);

//            //ACT
//            var result = await _handler.Handle(addBookCommand, CancellationToken.None);

//            //ASSERT
//            Assert.IsNotNull(result);
//            Assert.AreEqual(1, result.Count);  // expext one added book
//            Assert.AreEqual(bookId, bookToAdd.Id);
//            Assert.AreEqual(bookName, bookToAdd.Title);
//            Assert.AreEqual(description, bookToAdd.Description);
//        }

//        [Test]
//        public async Task CreateBook_ShouldNotAddBook_WhenSameBookExists()
//        {
//            var bookId = Guid.NewGuid();
//            var existingBook = new Book (bookId, "Book Of Eli", "Description");
//            _fakeDatabase.AllBooksFromDB.Add(existingBook);
//            //Arrange
//            var duplicateBookCommand = new AddBookCommand(existingBook);


//            //Act
//            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
//            {
//                await _handler.Handle(duplicateBookCommand, CancellationToken.None);
//            });
//            //Assert
//            Assert.AreEqual("A book With the same ID already exists!", ex.Message);
//        }
//    }
//}
