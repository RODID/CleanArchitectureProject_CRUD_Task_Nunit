using Domain;
using Application;
using Application.Commands.Authors;
using NUnit.Framework.Internal;
using Infrastructure.Database;
using Application.Commands.Authors.DeleteAuthor;

namespace Test_CRUD.AuthorCQRS_Test
{
    public class DeleteAuthorCommandHandlerTest
    {

        private FakeDatabase _fakeDatabase;
        private DeleteAuthorCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _fakeDatabase = new FakeDatabase();
            _handler = new DeleteAuthorCommandHandler(_fakeDatabase);
        }

        [Test]
        public async Task DeleteAuthorCommandHandler_SholdRemoveAuthor_WheneAutorExists()
        {
            var command = new DeleteAuthorCommand(1);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, _fakeDatabase.AllAuthorsFromDB.Count);
            Assert.IsFalse(_fakeDatabase.AllAuthorsFromDB.Any(a => a.Id == 1));

        }
    }
}
