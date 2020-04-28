using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ReportingService.Core.Interfaces.Services;

namespace ReportingService.AzureFunction
{
    public class GetCounts
    {
        private readonly IReportsService _reportsService;

        public GetCounts(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [FunctionName("GetCounts")]
        public void Run([TimerTrigger("0 0 */2 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                _reportsService.CountReport();
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch(Exception ex)
            {
                log.LogError("Unhandled error in GetCounts", ex);
            }

        }
    }
}
