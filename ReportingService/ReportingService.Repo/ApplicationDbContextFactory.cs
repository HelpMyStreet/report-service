using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ReportingService.Core.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReportingService.Repo
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // get connection string from AddressService.AzureFunction" project to avoid duplication
            string azureFunctionDirectory = Directory.GetCurrentDirectory().Replace("ReportingService.Repo", "ReportingService.AzureFunction");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(azureFunctionDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionStringSettings = configuration.GetSection("ConnectionStrings");
            var connectionStrings = new ConnectionStrings();
            connectionStringSettings.Bind(connectionStrings);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionStrings.ReportingService);
            optionsBuilder.EnableSensitiveDataLogging();

            Console.WriteLine($"Using following connection string for Entity Framework: {connectionStrings.ReportingService}");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
