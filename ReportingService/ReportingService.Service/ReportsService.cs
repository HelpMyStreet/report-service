using ReportingService.Core.Interfaces.Services;
using System;

namespace ReportingService.Service
{
    public class ReportsService : IReportsService
    {
        private readonly IConnectUserService _connectUserService;
        private readonly IConnectCommunicationService _connectCommunicationService;

        public ReportsService(IConnectUserService connectUserService, IConnectCommunicationService connectCommunicationService)
        {
            _connectUserService = connectUserService;
            _connectCommunicationService = connectCommunicationService;
        }
        public void CountReport()
        {
            var result = _connectUserService.GetDistinctChampionUserCount().Result;
            _connectCommunicationService.SendEmail(new HelpMyStreet.Contracts.CommunicationService.Request.SendEmailRequest()
            {
                Subject = "Count " + DateTime.Now.ToString(),
                ToAddress = "jawwad@factor-50.co.uk",
                ToName = "Jawwad Mukhtar",
                BodyHTML = result.ToString(),
                BodyText = result.ToString()
            });

        }
    }
}
