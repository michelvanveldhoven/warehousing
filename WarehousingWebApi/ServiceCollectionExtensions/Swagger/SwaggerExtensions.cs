using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousingWebApi.ServiceCollectionExtensions
{
    public static class SwaggerExtensions
    {
        private const string versionId = "v1";
        private static string swaggerEndpoint = $"/swagger/{versionId}/swagger.json";

        public static IServiceCollection AddSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(versionId, new OpenApiInfo
                {
                    Title = "WareHousing - Web HTTP API",
                    Version = "v1"
                });

                //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.ApiKey,
                //    Name = "Authorization",
                //    Scheme = "Bearer",
                //    In = ParameterLocation.Header,
                //    Description = "JWT Authorization header. Example: \"Bearer {token}\""
                //});

                //options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        public static IApplicationBuilder UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            return app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerEndpoint, "WareHousing - Web HTTP API");
                //c.RoutePrefix = string.Empty;
            });
        }
    }
}
