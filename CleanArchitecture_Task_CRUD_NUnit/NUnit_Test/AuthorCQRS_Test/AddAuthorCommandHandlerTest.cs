using Application;
using NUnit.Framework;
using Domain;
using Application.Commands.Authors.AddAuthor;
using Infrastructure.Database;

namespace Test_CRUD.AuthorCQRS_Test
{
    public class AddAuthorCommandHandlerTest
    {

        private FakeDatabase _fakeDatabase;
        private AddAuthorCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
            _handler = new AddAuthorCommandHandler(_fakeDatabase);
        }
        [Test]
        [TestCase(4, "Author Name")]
        public async Task AddAuthorCommandHandler_ShouldAddAuthor_WheneValidDataIsProvided(int Id, string Name)
        {
            var newAuthor = new Author(Id, Name);
            var command = new AddAuthorCommand(newAuthor);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.Any(a => a.Id == Id && a.Name == Name));
            
        }

        [Test]
        public async Task AddAuthor_ShouldNotAddAuthor_WhenInvalidDataIsProvided()
        {
            var existingAuthor = new Author(1, "Arjan1");
            var authorShouldNotAdd = new Author(1, "Arjan1");

            var command = new AddAuthorCommand(authorShouldNotAdd);

            var result = await  _handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(4, _fakeDatabase.AllAuthorsFromDB.Count);
            Assert.IsTrue(result.Contains(existingAuthor));
            Assert.AreEqual("Rodi", result.First(a => a.Id == 1).Name);
        }
    }
}
