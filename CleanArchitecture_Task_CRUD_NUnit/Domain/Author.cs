namespace Domain
{
    public class Author
    {
        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; } 
        public string Name { get; set; }

        

    }
}
