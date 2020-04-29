using HelpMyStreet.Contracts.ReportService.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Core.Interfaces.Services
{
    public interface IConnectUserService
    {
        Task<GetReportResponse> GetReport();
    }
}
