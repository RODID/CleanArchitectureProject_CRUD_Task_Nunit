using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        public Author(Guid id, string name, int age, string bio)
        {
            Id = id;
            Name = name;
            Age = age;
            Bio = bio;
        }

        public Author() { }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Bio is required.")]
        [StringLength(1000, ErrorMessage = "Bio cannot exceed 1000 characters.")]
        public string Bio { get; set; }
    }
}
