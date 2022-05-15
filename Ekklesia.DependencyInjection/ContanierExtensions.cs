using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Ekklesia.Entities.Settings;
using Ekklesia.Entities.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekklesia.DependencyInjection
{
    public static class ContanierExtensions
    {
        public static IServiceCollection RegisterSettings(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<DataBaseSettings>(Configuration.GetSection(nameof(DataBaseSettings)));
            return services;
        }

        public static IServiceCollection RegisterApplicationContext(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationContext>();
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberBusiness, MemberBusiness>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            services.AddScoped<IOccasionRepository, OccasionRepository>();
            services.AddScoped<IOccasionBusiness, OccasionBusiness>();

            return services;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddSingleton<MemberValidation>();
            services.AddSingleton<TransactionValidation>();
            services.AddSingleton<OccasionValidation>();

            return services;
        }


    }
}
