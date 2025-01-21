using Application.Queries.Login.Helpers;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Application.Behavior;
using MediatR;
using Application.Mappings;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<TokenHelper>();

            return services;
        }
    }
}
