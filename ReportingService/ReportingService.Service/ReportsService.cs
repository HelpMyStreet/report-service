using Microsoft.Extensions.Options;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using System;

namespace ReportingService.Service
{
    public class ReportsService : IReportsService
    {
        private readonly IConnectUserService _connectUserService;
        private readonly IConnectCommunicationService _connectCommunicationService;
        private readonly IOptions<ApplicationConfig> _applicationConfig;

        public ReportsService(IConnectUserService connectUserService, IConnectCommunicationService connectCommunicationService, IOptions<ApplicationConfig> applicationConfig)
        {
            _connectUserService = connectUserService;
            _connectCommunicationService = connectCommunicationService;
            _applicationConfig = applicationConfig;
        }
        public void CountReport()
        {
            var result = _connectUserService.GetDistinctChampionUserCount().Result;
            _connectCommunicationService.SendEmail(new HelpMyStreet.Contracts.CommunicationService.Request.SendEmailRequest()
            {
                Subject = "Count " + DateTime.Now.ToString(),
                ToAddress = _applicationConfig.Value.RecipientEmailAddress,
                ToName = _applicationConfig.Value.RecipientName,
                BodyHTML = result.ToString(),
                BodyText = result.ToString()
            });

        }
    }
}
