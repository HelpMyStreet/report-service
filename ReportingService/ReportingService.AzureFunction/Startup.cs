using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ReportingService.CommunicationService;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Service;
using ReportingService.UserService;

[assembly: FunctionsStartup(typeof(ReportingService.AzureFunction.Startup))]
namespace ReportingService.AzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IReportsService, ReportsService>();
            builder.Services.AddSingleton<IConnectCommunicationService, ConnectCommunicationService>();
            builder.Services.AddSingleton<IConnectUserService, ConnectUserService>();
        }
    }
}