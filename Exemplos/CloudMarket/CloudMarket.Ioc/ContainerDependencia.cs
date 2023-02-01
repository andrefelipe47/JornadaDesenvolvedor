using CloudMarket.Repositories.Repositorio;
using CloudMarket.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CloudMarket.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<ClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<ProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();

            //services
            services.AddScoped<ClienteService, ClienteService>();
            services.AddScoped<ProdutoService, ProdutoService>();
            services.AddScoped<UsuarioService, UsuarioService>();
            services.AddScoped<AutorizacaoService, AutorizacaoService>();
            services.AddScoped<RelatorioService, RelatorioService>();
        }
    }
}