//using NUnit.Framework;
//using ClassLibrary;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Infrastructure.Database;
//using Test_CRUD.AuthorCQRS_Test;
//using Application.Commands.Books.DeleteBook;
//using Application.Commands.Books.UpdateBook;

//namespace Test_CRUD.BookCQRS_Test
//{
//    public class UpdateBookCommandHandlerTest
//    {
//        private FakeDatabase _fakeDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//        }

//        //Updating Title and description
//        public async Task UpdateBookCommandHandler_ShouldUpdateBook_WheneValidInformationIsGiven()
//        {
//            var bookId = Guid.NewGuid();
//            var existingBook = new Book(bookId, "Old Book Title", "Old Description");
//            _fakeDatabase.AllBooksFromDB.Add(existingBook);

//            var command = new UpdateBookCommand(bookId, "New Book Title", "New Description");
//            var handler = new UpdateBookCommandHandler(_fakeDatabase);

//            var result = await handler.Handle(command, CancellationToken.None);

//            Assert.IsNotNull(result);
//            Assert.AreEqual("New Book AuthorName", result.Title);
//            Assert.AreEqual("New Book AuthorName", result.Description);
//            Assert.AreEqual(1, _fakeDatabase.AllBooksFromDB.Count);
//            Assert.AreEqual(result, _fakeDatabase.AllBooksFromDB[0]);
//        }


//        //Updating only Title 
//        public async Task UpdateBookCommandHandler_ShouldUpdateOnlyBookName_WheneDescriptionIsUnchanged()
//        {
//            var bookId = Guid.NewGuid();
//            var existingBook = new Book(bookId, "Old Book AuthorName", "OriginalDescription");
//            _fakeDatabase.AllBooksFromDB.Add(existingBook);

//            var command = new UpdateBookCommand(bookId, "Updated Book AuthorName", existingBook.Description);
//            var handler = new UpdateBookCommandHandler(_fakeDatabase);

//            var result = await handler.Handle(command, CancellationToken.None);

//            Assert.IsNotNull(result);
//            Assert.AreEqual("Updated Book AuthorName", result.Title);
//            Assert.AreEqual("Original Description", result.Description);
//        }
//    }
//}
