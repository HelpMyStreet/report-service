using ReportingService.Core.Interfaces.Services;
using System;

namespace ReportingService.Service
{
    public class ReportsService : IReportsService
    {
        private readonly IConnectUserService _connectUserService;

        public ReportsService(IConnectUserService connectUserService)
        {
            _connectUserService = connectUserService; 
        }
        public int GetDistinctChampionUserCount()
        {
            return _connectUserService.GetDistinctChampionUserCount().Result;
        }
    }
}
