using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProEventos.Persistence.Contexts;

namespace ProEventos.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<ProEventosContext>(
             context => context.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }

    }
}
