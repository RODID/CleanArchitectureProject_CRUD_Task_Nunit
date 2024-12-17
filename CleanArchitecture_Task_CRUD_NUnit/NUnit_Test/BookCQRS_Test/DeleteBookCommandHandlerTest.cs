//using NUnit.Framework;
//using ClassLibrary;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Infrastructure.Database;
//using Test_CRUD.AuthorCQRS_Test;
//using Application.Commands.Books.DeleteBook;

//namespace Test_CRUD.BookCQRS_Test
//{
//    public class DeleteBookCommandHandlerTest
//    {
//        private FakeDatabase _fakeDatabase;
//        private DeleteBookCommandHandler _handler;

//        [SetUp]
//        public void SetUp() 
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new DeleteBookCommandHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task DeleteBookCommandHandler_ShouldRemoveBook_WhenBookExists()
//        {
//            var bookId = Guid.NewGuid();
//            var bookToDelete = new Book(bookId, "Book Title", "Description");
//            _fakeDatabase.AllBooksFromDB.Add(bookToDelete);

//            var command = new DeleteBookCommand(bookId);

//            var result = await _handler.Handle(command, CancellationToken.None);

//            Assert.IsTrue(result.IsSuccess);
//            Assert.AreEqual("Book deleted successfully.", result.Message);
//            Assert.AreEqual(3, _fakeDatabase.AllBooksFromDB.Count);
//        }

//        [Test]
//        public async Task DeleteBookCommandHandler_ShouldReturnFalse_WhenBookDoseNotExist()
//        {
            
//            var nonExistingBookId = Guid.NewGuid();
//            var deleteBookCommand = new DeleteBookCommand(nonExistingBookId);

//            var result = await _handler.Handle(deleteBookCommand, CancellationToken.None);

//            Assert.IsFalse(result.IsSuccess);
//            Assert.AreEqual("Book not found.", result.ErrorMessage);
//            Assert.AreEqual(3, _fakeDatabase.AllBooksFromDB.Count);
//        }
//    }
//}
