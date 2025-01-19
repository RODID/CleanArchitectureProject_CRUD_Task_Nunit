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
            CreateMap<AddBookDto, Book>();
            CreateMap<Book, GetAllBooksDto>();
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
