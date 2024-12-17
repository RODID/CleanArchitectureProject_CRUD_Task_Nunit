using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjectionscs
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            

            services.AddSingleton<RealDatabase>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString);

            });

            return services;

        }
    }
}