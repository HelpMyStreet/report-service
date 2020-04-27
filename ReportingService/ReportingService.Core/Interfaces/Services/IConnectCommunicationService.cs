using HelpMyStreet.Contracts.CommunicationService.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.Core.Interfaces.Services
{
    public interface IConnectCommunicationService
    {
        Task<bool> SendEmail(SendEmailRequest request);
    }
}
