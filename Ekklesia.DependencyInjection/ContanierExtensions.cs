using Ekkleisa.Repository.Contract.IRepositories;
using Ekkleisa.Repository.Implementation.Context;
using Ekkleisa.Repository.Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ekklesia.DependencyInjection
{
    public static class ContanierExtensions
    {
        public static IServiceCollection RegisterApplicationContext(this IServiceCollection service)
        {
            service.AddScoped<ApplicationContext>();
            return service;
        }

        public static IServiceCollection RegisterDependencies(this IServiceCollection service)
        {
            service.AddScoped<IMemberRepository, MemberRepository>();
            return service;
        }
    }
}
