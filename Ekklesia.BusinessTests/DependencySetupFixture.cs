using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Ekklesia.Entities.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ekklesia.IntegrationTesting
{
    public class DependencySetupFixture
    {
        private readonly ServiceProvider _serviceProvider;

        public DependencySetupFixture()
        {
            var services = new ServiceCollection();


            services.AddOptions<DataBaseSettings>().Configure(x => { x.ConnectionString = "mongodb://localhost:27017"; x.Database = "EKKLESIA_TST"; });

            services.AddSingleton<ApplicationContext>();

            services.AddSingleton<MemberValidation>();
            services.AddSingleton<TransactionValidation>();
            services.AddSingleton<OccasionValidation>();

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberBusiness, MemberBusiness>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            services.AddScoped<IOccasionRepository, OccasionRepository>();
            services.AddScoped<IOccasionBusiness, OccasionBusiness>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            _serviceProvider = services.BuildServiceProvider();
        }

        public T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
