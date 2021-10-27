using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;

namespace flytt2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //Host.CreateDefaultBuilder(args)
        //.ConfigureWebHostDefaults(webBuilder =>
        //webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        //{
        //    var settings = config.Build();

        //    config.AddAzureAppConfiguration(options =>
        //    {
        //        options.Connect(settings["ConnectionStrings:FlyttConfig"])
        //                .ConfigureKeyVault(kv =>
        //                {
        //                    kv.SetCredential(new DefaultAzureCredential());
        //                });
        //    });
        //})
        //.UseStartup<Startup>());

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration((context, config) =>
        //        {
        //        var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("AzureKeyVault:AzureKeyVaultUri"));
        //        config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
        //        })
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
