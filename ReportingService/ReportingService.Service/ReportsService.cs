using HelpMyStreet.Contracts.ReportService.Response;
using Microsoft.Extensions.Options;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
            var result = _connectUserService.GetReport().Result;
            string subject = $"HelpMyStreet Monitoring {DateTime.Now:yyyy-MM-dd}, {DateTime.Now.AddHours(-2).ToUniversalTime():HH:mm:ss} - {DateTime.Now.ToUniversalTime():HH:mm:ss}";

            if(result==null)
            {
                return;
            }
            string body = GetHtmlTable(result.ReportItems);

            _connectCommunicationService.SendEmail(new HelpMyStreet.Contracts.CommunicationService.Request.SendEmailRequest()
            {
                Subject = subject ,
                ToAddress = _applicationConfig.Value.RecipientEmailAddress,
                ToName = _applicationConfig.Value.RecipientName,
                BodyHTML = body,
                BodyText = body
            });
        }

        private string GetHtmlTable(List<ReportItem> reportItems)
        {
            if(reportItems == null || reportItems.Count==0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=1>");
            sb.AppendLine("<tr>");
            sb.AppendLine($"<th>Section</th>");
            sb.AppendLine($"<th>Last 2 Hours</th>");
            sb.AppendLine($"<th>Today</th>");
            sb.AppendLine($"<th>Since Launch</th>");
            sb.AppendLine("</tr>");

            foreach (ReportItem reportItem in reportItems)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{reportItem.Section}</td>");
                sb.AppendLine($"<td>{reportItem.Last2Hours}</td>");
                sb.AppendLine($"<td>{reportItem.Today}</td>");
                sb.AppendLine($"<td>{reportItem.SinceLaunch}</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");

            return sb.ToString();
        }
    }
}
