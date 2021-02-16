using FilmsCatalog.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsCatalog.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlContext(this IServiceCollection services)
        {
            services.AddScoped<IFilmRepository, FilmRepository>();

            return services;
        }
    }
}
