using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehousingWebApi.ServiceCollectionExtensions
{
    public static class ApiVersioningExtensions
    {
        public static IServiceCollection AddWebApiVersioning(this IServiceCollection services)
        {
            return
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new QueryStringApiVersionReader();
            });
        }
    }
}
