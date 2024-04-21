using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Ekklesia.Entities.Settings;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.DependencyInjection
{
    public static class ContanierExtensions
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
        {
            services.AddApiVersioning(options =>            {
               
                options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddCors(options =>
            {                
                if (env.IsProduction())
                {
                    var securitySettingsSection = configuration.GetSection(nameof(SecutitySettings));
                    var appSettings = securitySettingsSection.Get<SecutitySettings>();
                    options.AddPolicy(env.EnvironmentName, builder =>
                    {
                        builder.AllowAnyMethod();
                        builder.WithHeaders(HeaderNames.ContentType, "application/json");
                        builder.WithOrigins(appSettings.Audience);
                        builder.AllowCredentials();
                    });
                }

                options.AddPolicy(env.EnvironmentName, builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                });

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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var DataBaseSettingsSection = configuration.GetSection(nameof(DataBaseSettings));
            var dataBaseSettings = DataBaseSettingsSection.Get<DataBaseSettings>();
            services.Configure<DataBaseSettings>(DataBaseSettingsSection);
            

            var securitySettingsSection = configuration.GetSection(nameof(SecutitySettings));
            var securitySettings = securitySettingsSection.Get<SecutitySettings>();
            services.Configure<SecutitySettings>(securitySettingsSection);
            

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

            var securitySettingsSection = configuration.GetSection(nameof(SecutitySettings));
            var securitySettings = securitySettingsSection.Get<SecutitySettings>();

            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(dataBaseSettings.ConnectionString);
            });

            services.AddHealthChecks().AddSqlServer(connectionString: dataBaseSettings.ConnectionString, name: dataBaseSettings.SqlDataBase);
            services.AddHealthChecksUI().AddSqlServerStorage(dataBaseSettings.ConnectionString);

            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    //options.SignIn.RequireConfirmedEmail = true;
                    options.User.AllowedUserNameCharacters = "aáâbcdeéêfghiíîjklmnoóôpqrstuúûvwxyzAÁÂBCDEÉÊFGHIÍÎJKLMNOÓÔPQRSTUÚÛVWXYZ/ ";
                    options.User.RequireUniqueEmail = true;
                    options.Lockout = new LockoutOptions
                    {
                        AllowedForNewUsers = true,
                        DefaultLockoutTimeSpan = TimeSpan.FromMinutes(securitySettings.DefaultLockoutTime),
                        MaxFailedAccessAttempts = securitySettings.MaxFailedAccessAttempts
                    };
                })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();


            var key = Encoding.ASCII.GetBytes(securitySettings.Secret);
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
                    ValidAudience = securitySettings.Audience,
                    ValidIssuer = securitySettings.Issuer
                };
            });

            return services;

        }

        public static async Task AddMigrationsAsync(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<IdentityContext>())
                {
                    await context.Database.MigrateAsync();
                }
            }
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
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/hc-ui";
                    options.ResourcesPath = "/hc-ui-resources";

                    options.UseRelativeApiPath = false;
                    options.UseRelativeResourcesPath = false;
                    options.UseRelativeWebhookPath = false;
                });

            });
            return app;
        }
    }
}
