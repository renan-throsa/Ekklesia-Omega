using Asp.Versioning.ApiExplorer;
using Ekklesia.Application.Mapping;
using Ekklesia.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ekklesia.Api
{
    public class Startup
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(_configuration);
            services.AddIdentityConficuration(_configuration);
            services.AddControllers(opt=> opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddWebApiConfig(_environment, _configuration);
            services.AddWebApiDoc();
            services.AddAutoMapper(typeof(AutomapperConfig));
            services.AddHealthChecksUI();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(env.EnvironmentName);
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSuaggerConfig(provider);
            app.UseHealthChecksConfig();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
