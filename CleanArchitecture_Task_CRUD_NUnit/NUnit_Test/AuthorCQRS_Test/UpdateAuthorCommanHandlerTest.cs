//using Application;
//using Application.Commands.Authors;
//using NUnit.Framework;
//using Domain;
//using Infrastructure.Database;
//using Application.Commands.Authors.UpdateAuthor;
//using Domain.CommandOperationResult;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Linq;

//namespace Test_CRUD.AuthorCQRS_Test
//{
//    [TestFixture]
//    public class UpdateAuthorCommandHandlerTest
//    {
//        private FakeDatabase _fakeDatabase;
//        private UpdateAuthorCommandHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new UpdateAuthorCommandHandler(_fakeDatabase);
//        }

//        [Test]
//        public async Task UpdateAuthorCommandHandler_ShouldUpdateAuthor_WithExistingAuthor()
//        {
//            // Arrange: Setup a list of authors
//            var authors = new List<Author>
//            {
//                new Author(Guid.NewGuid(), "Arjan1"),
//                new Author(Guid.NewGuid(), "Arjan2"),
//                new Author(Guid.NewGuid(), "Arjan3")
//            };
//            _fakeDatabase.AllAuthorsFromDB.AddRange(authors);

//            // Select an existing author to update
//            var authorToUpdate = authors[1];
//            var updatedName = "Updated Author2";
//            var command = new UpdateAuthorCommand(authorToUpdate.Id, updatedName);

//            // Act: Execute the handler
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert: Validate the results
//            Assert.IsNotNull(result, "Result should not be null.");
//            Assert.IsTrue(result.IsSuccess, "Result should indicate success.");
//            Assert.IsNotNull(result.Data, "Result should contain data.");
//            Assert.AreEqual(updatedName, result.Data.Name, "Author's name should be updated.");
//            Assert.AreEqual(authorToUpdate.Id, result.Data.Id, "Author's ID should remain the same.");

//            // Verify only the updated author's name is changed
//            var updatedAuthor = _fakeDatabase.AllAuthorsFromDB.First(a => a.Id == authorToUpdate.Id);
//            Assert.AreEqual(updatedName, updatedAuthor.Name, "Database should have the updated author's name.");

//            // Ensure other authors are unchanged
//            Assert.AreEqual("Arjan1", _fakeDatabase.AllAuthorsFromDB[0].Name, "First author's name should remain unchanged.");
//            Assert.AreEqual("Arjan3", _fakeDatabase.AllAuthorsFromDB[2].Name, "Third author's name should remain unchanged.");
//        }

//        [Test]
//        public async Task UpdateAuthorCommandHandler_ShouldReturnFailure_WhenAuthorDoesNotExist()
//        {
//            // Arrange
//            var authorId = Guid.NewGuid();
//            var command = new UpdateAuthorCommand(authorId, "Nonexistent Author");

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.IsNotNull(result, "Result should not be null.");
//            Assert.IsFalse(result.IsSuccess, "Result should indicate failure.");
//            Assert.IsNull(result.Data, "Result data should be null for a failed operation.");
//            Assert.AreEqual($"Author with ID {authorId} wasn't found.", result.ErrorMessage, "Error message should match.");
//            Assert.AreEqual(3, _fakeDatabase.AllAuthorsFromDB.Count, "Database should remain unchanged.");
//        }
//    }
//}
