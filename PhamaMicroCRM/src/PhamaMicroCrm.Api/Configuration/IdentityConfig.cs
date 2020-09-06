﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhamaMicroCrm.Api.Extensions;
using PhamaMicroCrm.Data.Context;
using System.Text;

namespace PhamaMicroCrm.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            // JWT
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // padrão de autenticacao é pra gerar um token
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // validar via token
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //validma se o token recebido foi do meso gerado
                    IssuerSigningKey = new SymmetricSecurityKey(key), // transforma a chave ascii para uma chave criptografada
                    ValidateIssuer = true, // valida o issuer conforme o nome
                    ValidateAudience = true, // em qual audiencia(quais URLS ele é valido, no caso sua aplicacao) o token é valido
                    ValidAudience = appSettings.ExpiresIn, //localhost ou o site/url da sua aplicacao
                    ValidIssuer = appSettings.Issuer //nome da sua aplicacao
                };
            });

            return services;
        }
    }
}
