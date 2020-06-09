using Microsoft.Extensions.DependencyInjection;
using PhamaMicroCrm.Data.Context;

namespace PhamaMicroCrm.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PhamaMicroCrmContext>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            //services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
