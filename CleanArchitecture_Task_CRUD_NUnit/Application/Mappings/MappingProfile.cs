using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            ApplyMappingsFromAssembly();
            CreateMap<AddAuthorDto, Author>();
            CreateMap<Author, GetAuthorDto>();
            CreateMap<AddBookDTO, Book>();
            CreateMap<Book, GetAllBooksDto>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<Book, UpdateBookDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Author, UpdateAuthorDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio));
        }

        private void ApplyMappingsFromAssembly()
        {
            var types = typeof(MappingProfile).Assembly.GetTypes();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                    {
                        var instance = Activator.CreateInstance(type);
                        var method = type.GetMethod("Mapping")
                                    ?? @interface.GetMethod("Mapping");
                        method?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }

    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
