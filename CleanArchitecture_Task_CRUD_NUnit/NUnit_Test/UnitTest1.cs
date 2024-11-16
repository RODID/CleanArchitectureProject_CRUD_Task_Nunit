using Application;

namespace Tests_CRUD
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Reset_book before each test, ensure clean state
            typeof(BookMethods).GetField("_book", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, new List<ClassLibrary.Book>());
        }

        [Test]
        [TestCase(1, "Book of Arre", "Arru Sani")]
        public void AddNewBook_ShouldAddBook_WhenValiDataIsProvided(int id, string author, string bookName)
        {
            //ACT
            var result = BookMethods.AddNewBook(id, author, bookName);

            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(bookName, result.BookName);
            Assert.AreEqual(author, result.Author);
        }

        [Test]
        [TestCase(1, "Book of Arre", "Arru Sani")]
        public void AddNewBook_ShouldThrowException_WhenBookWithSameIdExists(int id, string author, string bookName)
        {
            //ACT
            BookMethods.AddNewBook(id, author, bookName);

            //ASSERT
            var ex = Assert.Throws<InvalidOperationException>(() => BookMethods.AddNewBook(id, "different Author", "Different Book Name"));
            Assert.AreEqual("A book with this ID already exists", ex.Message);
        }

        [Test]
        [TestCase(1, "", "Valid Book Name")] // Empty author
        [TestCase(1, "Valid Author", "")]    // Empty book name
        [TestCase(1, "  ", "Valid Book Name")] // Whitespace author
        [TestCase(1, "Valid Author", "   ")]   // Whitespace book name
        public void AddNewBook_ShouldThrowArgumentException_WhenInvalidDataIsProvided(int id, string author, string bookName)
        {
            // ACT & ASSERT
            var ex = Assert.Throws<ArgumentException>(() => BookMethods.AddNewBook(id, author, bookName));
            Assert.AreEqual("BookName and Author are required", ex.Message);
        }

        [Test]
        [TestCase(1, "Author One", "Book One")]
        public void GetBookById_ShouldReturnBook_WhenBookExists(int id, string author, string bookName)
        {
            //ARRANGE
            var book = BookMethods.AddNewBook(id, author, bookName);

            //ACT
            var result = BookMethods.GetBookById(id);

            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(author, result.Author);
            Assert.AreEqual(bookName, result.BookName);
        }
        [Test]
        public void GetBookById_ShouldReturnNull_WhenBookDoseNotExist()
        {
            //ACT
            var result = BookMethods.GetBookById(777);

            //ASSERT
            Assert.IsNull(result);
        }
    }
}