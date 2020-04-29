using HelpMyStreet.Contracts.ReportService.Response;
using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Contracts.Shared;
using Newtonsoft.Json;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Core.Utils;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.RequestService
{
    public class ConnectRequestService : IConnectRequestService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ConnectRequestService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<GetReportResponse> GetReport()
        {
            GetReportResponse result = null;
            string path = $"/api/GetReport";
            string absolutePath = $"{path}";

            using (HttpResponseMessage response = await _httpClientWrapper.GetAsync(HttpClientConfigName.RequestService, absolutePath, CancellationToken.None).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var requestResponse = JsonConvert.DeserializeObject<ResponseWrapper<GetReportResponse, RequestServiceErrorCode>>(content);
                if (requestResponse.HasContent && requestResponse.IsSuccessful)
                {
                    result = requestResponse.Content;
                }
            }

            return result;
        }
    }
}
