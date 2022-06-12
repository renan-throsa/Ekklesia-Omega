using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Ekklesia.Entities.Settings;
using Ekklesia.Entities.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Ekklesia.DependencyInjection
{
    public static class ContanierExtensions
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IServiceCollection AddWebApiDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {                
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ekklésia Api",
                    Description = "Documentação da api de gerenciamento de uma pequena Igreja",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Rosa",
                        Email = "renannojosa@gmail.com",
                    }
                });
                //options.OperationFilter<SwaggerDefaultValues>();
            });

            return services;
        }

        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<DataBaseSettings>(Configuration.GetSection(nameof(DataBaseSettings)));
            return services;
        }

        public static IServiceCollection AddApplicationContext(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationContext>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberBusiness, MemberBusiness>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            services.AddScoped<IOccasionRepository, OccasionRepository>();
            services.AddScoped<IOccasionBusiness, OccasionBusiness>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<MemberValidation>();
            services.AddSingleton<TransactionValidation>();
            services.AddSingleton<OccasionValidation>();

            return services;
        }

        public static IApplicationBuilder UseSuaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(-1);
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(url: $"/swagger/{description.GroupName}/swagger.json", name: "Ekklésia Api v1");
                }

            });
            return app;
        }

    }
}
