using Microsoft.Extensions.DependencyInjection;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Business.Notifications;
using PhamaMicroCrm.Business.Services;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Data.Repository;

namespace PhamaMicroCrm.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PhamaMicroCrmContext>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUnitRepository, CompanyUnitRepository>();
            //services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            //services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyUnitService, CompanyUnitService>();

            return services;
        }
    }
}
