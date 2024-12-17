//using Application;
//using NUnit.Framework;
//using Domain;
//using Application.Commands.Authors.AddAuthor;
//using System.Linq;

//namespace Test_CRUD.AuthorCQRS_Test
//{
//    public class AddAuthorCommandHandlerTest
//    {

//        private FakeDatabase _fakeDatabase;
//        private AddAuthorCommandHandler _handler;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeDatabase = new FakeDatabase();
//            _handler = new AddAuthorCommandHandler(_fakeDatabase);
//        }
//        [Test]
//        [TestCase("b74c1f5e-18d3-4657-9a62-2b8f8c5ea6df", "Author Name")]
//        public async Task AddAuthorCommandHandlear_ShouldAddAuthor_WheneValidDataIsProvided(string Id, string Name)
//        {
//            var command = new AddAuthorCommand(Name);

//            var result = await _handler.Handle(command, CancellationToken.None);

//            Assert.AreEqual(4, _fakeDatabase.AllAuthorsFromDB.Count);
//            Assert.IsTrue(_fakeDatabase.AllAuthorsFromDB.Any(a => a.Name == Name));
//            Assert.IsTrue(result.IsSuccess);
//        }


//        [Test]
//        public async Task AddAuthor_ShouldNotAddAuthor_WhenInvalidDataIsProvided()
//        {
//            var existingAuthor = new Author(Guid.NewGuid(), "Arjan1");
//            _fakeDatabase.AllAuthorsFromDB.Add(existingAuthor);

//            var command = new AddAuthorCommand ("Arjan1");

//            var result = await  _handler.Handle(command, CancellationToken.None);

//            Assert.AreEqual(4, _fakeDatabase.AllAuthorsFromDB.Count);
//            Assert.IsFalse(result.IsSuccess);
//            Assert.AreEqual("Duplicate author detected.", result.ErrorMessage);
//        }
//    }
//}
