using HelpMyStreet.Contracts.ReportService.Response;
using Newtonsoft.Json;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Core.Utils;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.VerificationService
{
    public class ConnectVerificationService : IConnectVerificationService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ConnectVerificationService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<GetReportResponse> GetReport()
        {
            GetReportResponse result;
            string path = $"/api/GetReport";
            string absolutePath = $"{path}";

            using (HttpResponseMessage response = await _httpClientWrapper.GetAsync(HttpClientConfigName.VerificationService, absolutePath, CancellationToken.None).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                content = "{\"reportItems\":" + content + "}";


                result = JsonConvert.DeserializeObject<GetReportResponse>(content);
            }

            return result;
        }
    }
}
