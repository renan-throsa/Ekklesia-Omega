using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Ekklesia.Entities.Settings;
using Ekklesia.Entities.Validations;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Ekklesia.DependencyInjection
{
    public static class ContanierExtensions
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
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

            services.AddCors(options =>
            {
                if (env.IsDevelopment())
                {
                    options.AddPolicy(env.EnvironmentName, builder =>
                    {
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                        builder.AllowAnyOrigin();                       
                    });
                }
                if (env.IsProduction())
                {
                    var appSettingsSection = configuration.GetSection("AppSettings");
                    var appSettings = appSettingsSection.Get<AppSettings>();
                    options.AddPolicy(env.EnvironmentName, builder =>
                    {
                        builder.AllowAnyMethod();
                        builder.WithHeaders(HeaderNames.ContentType, "application/json");
                        builder.WithOrigins(appSettings.Audience);
                        builder.AllowCredentials();
                    });
                }
            });
            return services;
        }

        public static IServiceCollection AddWebApiDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                //options.OperationFilter<SwaggerDefaultValues>();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ekklésia Api",
                    Description = "Documentação da api de gerenciamento de uma pequena Igreja",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Rosa",
                        Email = "renan.throsa@gmail.com",
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        System.Array.Empty<string>()
                    }
                });

            });

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var DataBaseSettingsSection = configuration.GetSection(nameof(DataBaseSettings));
            var dataBaseSettings = DataBaseSettingsSection.Get<DataBaseSettings>();
            services.Configure<DataBaseSettings>(DataBaseSettingsSection);

            services.AddSingleton<ApplicationContext>();
            services.AddHealthChecks().AddMongoDb(mongodbConnectionString: dataBaseSettings.ConnectionString, name: dataBaseSettings.NoSqlDataBase);


            services.AddSingleton<MemberValidation>();
            services.AddSingleton<TransactionValidation>();
            services.AddSingleton<OccasionValidation>();
            services.AddSingleton<SignInValidation>();
            services.AddSingleton<SignUpValidation>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberBusiness, MemberBusiness>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            services.AddScoped<IOccasionRepository, OccasionRepository>();
            services.AddScoped<IOccasionBusiness, OccasionBusiness>();

            services.AddScoped<IAccountBusiness, AccountBusiness>();

            return services;
        }

        public static IServiceCollection AddIdentityConficuration(this IServiceCollection services, IConfiguration configuration)
        {
            var identitySettingsSection = configuration.GetSection(nameof(IdentitySettings));
            var dataBaseSettings = identitySettingsSection.Get<IdentitySettings>();

            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(dataBaseSettings.ConnectionString);
            });

            services.AddHealthChecks().AddSqlServer(connectionString: dataBaseSettings.ConnectionString, name: dataBaseSettings.SqlDataBase);
            services.AddHealthChecksUI().AddSqlServerStorage(dataBaseSettings.ConnectionString);

            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    //options.SignIn.RequireConfirmedEmail = true;
                    options.User.AllowedUserNameCharacters = null;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();


            var appSettingsSection = configuration.GetSection(nameof(AppSettings));
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer
                };
            });

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

        public static IApplicationBuilder UseHealthChecksConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/api/hc-ui";
                    options.ResourcesPath = "/api/hc-ui-resources";

                    options.UseRelativeApiPath = false;
                    options.UseRelativeResourcesPath = false;
                    options.UseRelativeWebhookPath = false;
                });

            });           
            return app;
        }
    }
}
