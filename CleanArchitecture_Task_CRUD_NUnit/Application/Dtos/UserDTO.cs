using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class UserDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public required string UserName {get; set;}

        [Required]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters.")]
        public required string Password {get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public required string? Email { get; set; }
    }
}
