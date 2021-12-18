using BD;
using Microsoft.Extensions.DependencyInjection;
using WBL;

namespace WebApp
{
    public static class ContainerExtensions
    {
        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IDetalleService, DetalleService>();
            return services;
        }
    }
}