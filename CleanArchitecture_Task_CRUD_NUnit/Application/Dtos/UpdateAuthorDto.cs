
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UpdateAuthorDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name connot excede 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bio is required.")]
        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio {  get; set; }
    }
}
