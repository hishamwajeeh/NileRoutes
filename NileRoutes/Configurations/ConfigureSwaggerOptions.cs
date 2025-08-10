using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NileRoutes.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            var added = new HashSet<string>();

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                if (!added.Add(description.GroupName))
                    continue; // Skip duplicates

                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = "My API",
                    Version = description.ApiVersion.ToString()
                });
            }
        }

    }
}
