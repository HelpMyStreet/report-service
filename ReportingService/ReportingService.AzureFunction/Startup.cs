using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using ReportingService.CommunicationService;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Core.Utils;
using ReportingService.Service;
using ReportingService.UserService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

[assembly: FunctionsStartup(typeof(ReportingService.AzureFunction.Startup))]
namespace ReportingService.AzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // We need to get the app directory this way.  Using Environment.CurrentDirectory doesn't work in Azure
            ExecutionContextOptions executioncontextoptions = builder.Services.BuildServiceProvider()
                .GetService<IOptions<ExecutionContextOptions>>().Value;
            string currentDirectory = executioncontextoptions.AppDirectory;

            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot config = configBuilder.Build();

            Dictionary<HttpClientConfigName, ApiConfig> httpClientConfigs = config.GetSection("Apis").Get<Dictionary<HttpClientConfigName, ApiConfig>>();

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .RetryAsync(3);

            IEnumerable<TimeSpan> timeSpans = new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(20)
            };

            foreach (KeyValuePair<HttpClientConfigName, ApiConfig> httpClientConfig in httpClientConfigs)
            {

                builder.Services.AddHttpClient(httpClientConfig.Key.ToString(), c =>
                {
                    c.BaseAddress = new Uri(httpClientConfig.Value.BaseAddress);

                    c.Timeout = httpClientConfig.Value.Timeout ?? new TimeSpan(0, 0, 0, 30);

                    foreach (KeyValuePair<string, string> header in httpClientConfig.Value.Headers)
                    {
                        c.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                    c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

                }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    MaxConnectionsPerServer = httpClientConfig.Value.MaxConnectionsPerServer ?? 15,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                })
                .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(timeSpans));
            }

            IConfigurationSection applicationConfigSettings = config.GetSection("ApplicationConfig");
            builder.Services.Configure<ApplicationConfig>(applicationConfigSettings);

            builder.Services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            builder.Services.AddSingleton<IReportsService, ReportsService>();
            builder.Services.AddSingleton<IConnectCommunicationService, ConnectCommunicationService>();
            builder.Services.AddSingleton<IConnectUserService, ConnectUserService>();
        }
    }
}