using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
