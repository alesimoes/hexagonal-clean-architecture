using ANM.Example.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;

namespace ANM.Example.API.DependencyInjection
{
    public static class SwaggerExtensions
    {
        private static string GetXmlCommentsFilePath()
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = $"{typeof(Startup).GetTypeInfo().Assembly.GetName().Name}.xml";
            return Path.Combine(basePath, fileName);
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.IncludeXmlComments(GetXmlCommentsFilePath());
                });


            return services;
        }


        public static IApplicationBuilder UseUnVersionedSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "ANM API");
            });


            return app;
        }
    }
}
