﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Business.Notifications;
using PhamaMicroCrm.Business.Services;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Data.Repository;

namespace PhamaMicroCrm.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PhamaMicroCrmContext>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUnitRepository, CompanyUnitRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyUnitService, CompanyUnitService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<INoteService, NoteService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
