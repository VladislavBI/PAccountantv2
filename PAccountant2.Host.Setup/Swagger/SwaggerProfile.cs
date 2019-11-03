using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace PAccountant2.Host.Setup.Swagger
{
    public static class SwaggerProfile
    {
        public static void ConfigureSwagger(IServiceCollection services, string assemblyName, string baseDirectoryName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "PAccountant",
                    Description = "Acconting SAAS solution",
                    TermsOfService = "None"
                });

                var xmlFile = $"{assemblyName}.xml";
                var xmlPath = Path.Combine(baseDirectoryName, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
