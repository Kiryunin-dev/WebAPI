using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;

namespace TestWebApi.Configure
{
    /// <summary>
    /// ConfigureSwaggerOptions
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// ConfigureSwaggerOptions
        /// </summary>
        /// <param name="_provider"></param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider _provider)
        {
            provider = _provider;
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(desc.GroupName, CreateApiInfo(desc));
            }
        }

        private OpenApiInfo CreateApiInfo(ApiVersionDescription desc)
        {
            return new OpenApiInfo()
            {
                Title = "Test Web API",
                Version = desc.GroupName,
                Contact = new OpenApiContact { Email = "test@gmail.com", Name = "Илья Кирюнин" }
            };
        }
    }
}
