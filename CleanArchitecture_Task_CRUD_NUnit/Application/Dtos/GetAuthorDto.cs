using Application.Mappings;
using AutoMapper;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class GetAuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, GetAuthorDto>();
        }
    }
}
