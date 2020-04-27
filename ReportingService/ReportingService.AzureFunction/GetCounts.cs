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
            var result = _reportsService.GetDistinctChampionUserCount();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation(result.ToString());
        }
    }
}
