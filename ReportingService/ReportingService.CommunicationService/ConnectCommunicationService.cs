using HelpMyStreet.Contracts.CommunicationService.Request;
using HelpMyStreet.Contracts.CommunicationService.Response;
using HelpMyStreet.Contracts.RequestService.Response;
using HelpMyStreet.Contracts.Shared;
using Newtonsoft.Json;
using ReportingService.Core.Configuration;
using ReportingService.Core.Interfaces.Services;
using ReportingService.Core.Utils;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.CommunicationService
{
    public class ConnectCommunicationService : IConnectCommunicationService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ConnectCommunicationService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<bool> SendEmail(SendEmailRequest request)
        {
            string path = $"api/SendEmail";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await _httpClientWrapper.PostAsync(HttpClientConfigName.CommunicationService, path, jsonContent,CancellationToken.None).ConfigureAwait(false))
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var emailSentResponse = JsonConvert.DeserializeObject<ResponseWrapper<SendEmailResponse, RequestServiceErrorCode>>(jsonResponse);
                if (emailSentResponse.HasContent && emailSentResponse.IsSuccessful)
                {
                    return emailSentResponse.Content.Success;
                }
                return false;
            }
        }
    }
}
