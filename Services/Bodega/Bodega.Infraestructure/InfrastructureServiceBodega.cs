using Bodega.Application.Repositories;
using Bodega.Infraestructure.Repositories;
using Common.Application.Interfaces;
using Common.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bodega.Infraestructure
{
    public static class InfrastructureServiceBodega
    {
        public static IServiceCollection AddInfraestructureServiceBodega(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<BodegaDbContext>(ops =>
                               ops.UseSqlServer(
                                   configuration.GetConnectionString("ConnectionString"),
                                   x => x.MigrationsHistoryTable("_EFMigrationBodegaHistory", "bodega")
                                   )
                       );

            serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped(typeof(ICategoriaRepository), typeof(CategoriaRepository));
            serviceCollection.AddScoped(typeof(IProveedorRepository), typeof(ProveedorRepository));
            serviceCollection.AddScoped(typeof(ISeccionRepository), typeof(SeccionRepository));

            return serviceCollection;
        }
    }
}