using ANM.Example.API.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ANM.Example.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddHttpContextAccessor()
            .AddSwagger()
            .AddUseCases()
            .AddMediators()
            .AddPresenters()
            .AddEventInfracstruture()
            .AddDomainServices()
            .AddRepositories()
            .AddMongoDbPersistence(Configuration)
            .AddSQLServerPersistence(Configuration);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseUnVersionedSwagger();
            app.UseStaticFiles();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers()
                    //.RequireAuthorization()
                    ;
            });
        }
    }
}
