using System.Collections.Generic;

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
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
