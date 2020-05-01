using HelpMyStreet.Contracts.ReportService.Response;
using Microsoft.Extensions.Options;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportingService.Service
{
    public class ReportsService : IReportsService
    {
        private readonly IConnectUserService _connectUserService;
        private readonly IConnectCommunicationService _connectCommunicationService;
        private readonly IOptions<ApplicationConfig> _applicationConfig;
        private readonly IConnectRequestService _connectRequestService;

        public ReportsService(IConnectUserService connectUserService, IConnectCommunicationService connectCommunicationService, IOptions<ApplicationConfig> applicationConfig, IConnectRequestService connectRequestService)
        {
            _connectUserService = connectUserService;
            _connectCommunicationService = connectCommunicationService;
            _applicationConfig = applicationConfig;
            _connectRequestService = connectRequestService;
        }
        public void CountReport()
        {
            var userReport = _connectUserService.GetReport().Result;
            var requestReport = _connectRequestService.GetReport().Result;
            
            if(userReport == null && requestReport == null)
            {
                return;
            }

            string subject = $"HelpMyStreet Monitoring {DateTime.Now:yyyy-MM-dd}, {DateTime.Now.AddHours(-2).ToUniversalTime():HH:mm:ss} - {DateTime.Now.ToUniversalTime():HH:mm:ss}";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(StyleTables());
            stringBuilder.AppendLine(GetHtmlTable(userReport.ReportItems));
            stringBuilder.AppendLine("<br>");
            stringBuilder.AppendLine(GetHtmlTable(requestReport.ReportItems));

            _connectCommunicationService.SendEmail(new HelpMyStreet.Contracts.CommunicationService.Request.SendEmailRequest()
            {
                Subject = subject ,
                ToAddress = _applicationConfig.Value.RecipientEmailAddress,
                ToName = _applicationConfig.Value.RecipientName,
                BodyHTML = stringBuilder.ToString(),
                BodyText = stringBuilder.ToString()
            });
        }

        private string StyleTables()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<style>");
            sb.AppendLine("th {background-color: #001489; color: #ffffff; } tr{ background-color: #e8f4fb}");
            sb.AppendLine("</style>");
            return sb.ToString();
        }

        private string GetHtmlTable(List<ReportItem> reportItems)
        {
            if(reportItems == null || reportItems.Count==0)
            {
                return string.Empty;
            }

            var totalsRow = reportItems.First();
 
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
                sb.AppendLine($"<td>{reportItem.Last2Hours} ({GetPercentage(totalsRow.Last2Hours, reportItem.Last2Hours)})</td>");
                sb.AppendLine($"<td>{reportItem.Today} ({GetPercentage(totalsRow.Today, reportItem.Today)})</td>");
                sb.AppendLine($"<td>{reportItem.SinceLaunch} ({GetPercentage(totalsRow.SinceLaunch, reportItem.SinceLaunch)})</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");

            return sb.ToString();
        }
        private string GetPercentage(int total, int value)
        {
            if (total == 0) return "0%";
            double percentage = (((double)value / (double)total) * 100);
            return $"{Math.Round(percentage, 2).ToString()}%";
        }
    }
 
}

