using Application.Mappings;
using AutoMapper;
using Domain;
using System.ComponentModel.DataAnnotations;


namespace Application.Dtos
{
    public class AddAuthorDto : IMapFrom<Author>
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
        public int Age { get; set; }

        [StringLength(1000, ErrorMessage = "Bio cannot exceed 1000 characters.")]
        public string Bio { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddAuthorDto, Author>();
        }
    }
}
