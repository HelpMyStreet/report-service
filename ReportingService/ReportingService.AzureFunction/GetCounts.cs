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
        public void Run([TimerTrigger("00:01:00")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"GetCounts started at: {DateTime.Now}");
                _reportsService.CountReport();
                log.LogInformation($"GetCounts completed at: {DateTime.Now}");
            }
            catch(Exception ex)
            {
                log.LogError("Unhandled error in GetCounts ", ex.ToString());
            }

        }
    }
}
