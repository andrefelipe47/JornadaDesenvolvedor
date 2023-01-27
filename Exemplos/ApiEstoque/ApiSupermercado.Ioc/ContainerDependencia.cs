using ApiSupermecado.Repositories.Repositorio;
using ApiSupermecado.Services;
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
            services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();

            //services
            services.AddScoped<ClienteService, ClienteService>();
            services.AddScoped<ProdutoService, ProdutoService>();
            services.AddScoped<UsuarioService, UsuarioService>();
            services.AddScoped<AutorizacaoService, AutorizacaoService>();
        }
    }
}