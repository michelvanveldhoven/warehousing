using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WarehousingWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostBuilder, loggingBuilder) => {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddTraceSource(new SourceSwitch(nameof(Program)));

                    loggingBuilder.AddLog4Net();

                })
            ;
    }
}
