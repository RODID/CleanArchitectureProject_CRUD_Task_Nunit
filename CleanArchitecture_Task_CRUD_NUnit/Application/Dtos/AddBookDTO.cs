using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AddBookDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Year of publication is required.")]
        [Range(1450, int.MaxValue, ErrorMessage = "Year of publication must be after 1450.")]
        public int YearPublished { get; set; }
    }
}
