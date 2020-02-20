using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ANM.Example.API.Filters
{
    public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
    {

        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", CreateInfoForApiVersion("v1"));
        }

        private static OpenApiInfo CreateInfoForApiVersion(string description)
        {
            var info = new OpenApiInfo()
            {
                Title = "ANM Example Api",
                Version = description
            };

            return info;
        }
    }
}
