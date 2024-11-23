namespace Domain
{
    public class Author
    {
        public Author(string authorName, int authorAge)
        {
            AuthorName = authorName;
            AuthorAge = authorAge;
        }

        public string AuthorName { get; set; }
        public int AuthorAge { get; set; }
        

    }
}
