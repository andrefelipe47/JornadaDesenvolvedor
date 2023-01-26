using ApiSuperMercado.Repositories.Repositorio;
using ApiSuperMercado.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSupermercado.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<ClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<ProdutoRepositorio, ProdutoRepositorio>();

            //services
            services.AddScoped<ClienteService, ClienteService>();
            services.AddScoped<ProdutoService, ProdutoService>();
        }
    }
}