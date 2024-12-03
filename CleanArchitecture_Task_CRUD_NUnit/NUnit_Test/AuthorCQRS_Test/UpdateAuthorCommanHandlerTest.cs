using Application;
using Application.Commands.Authors;
using NUnit.Framework;
using Domain;
using Infrastructure.Database;
using Application.Commands.Authors.UpdateAuthor;

namespace Test_CRUD.AuthorCQRS_Test
{
    [TestFixture]
    public class UpdateAuthorCommanHandlerTest
    {
        private FakeDatabase _fakeDatabase;
        private UpdateAuthorCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
            _handler = new UpdateAuthorCommandHandler(_fakeDatabase);
        }

        [Test]
        public async Task UpdateAuthorCommandHandler_ShouldUpdateAuthor_WheneValidInformationIsGiven()
        {
            var existingAuthor = new Author(1, "Rodi");
            _fakeDatabase.AllAuthorsFromDB.Add(existingAuthor);

            var command = new UpdateAuthorCommand(1,"Updated Rodi");

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result, "Result Should not be null.");
            Assert.AreEqual("Updated Rodi", result.Name, "Author's name should be updated!");
            Assert.AreEqual(1, result.Id, "Author's ID should remain same!");

            Assert.AreEqual(1, _fakeDatabase.AllAuthorsFromDB.Count, "Database should still contain only one author.");
            var updatedAuthor = _fakeDatabase.AllAuthorsFromDB.First();
            Assert.AreEqual("Updated Rodi", updatedAuthor.Name, "Database should have the updated author's name.");
            Assert.AreEqual(1, updatedAuthor.Id, "Database should have the same author ID.");
        }

        [Test]
        public async Task UpdateAuthorCommandHandler_ShouldNotUpdate_WhenAuthorDoesNotExist()
        {
            var command = new UpdateAuthorCommand(99, "Nonexistent Author");

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNull(result, "Result should be null when the author does not exist.");
            Assert.AreEqual(0, _fakeDatabase.AllAuthorsFromDB.Count, "Database should remain unchanged.");
        }
    }
}
