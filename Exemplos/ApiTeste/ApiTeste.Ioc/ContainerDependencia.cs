using ApiTeste.Repositories.Repositorio;
using ApiTeste.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTeste.Ioc
{
    public class ContainerDependencia
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //repositorios
            services.AddScoped<ClienteRepositorio, ClienteRepositorio>();

            //services
            services.AddScoped<ClienteService, ClienteService>();
        }
    }
}