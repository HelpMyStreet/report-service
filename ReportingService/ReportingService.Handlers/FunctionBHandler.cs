using ReportingService.Core.Domains.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.Handlers
{
    public class FunctionBHandler : IRequestHandler<FunctionBRequest, FunctionBResponse>
    {
        public Task<FunctionBResponse> Handle(FunctionBRequest request, CancellationToken cancellationToken)
        {
            var response = new FunctionBResponse()
            {
                Status = "Active"
            };
            return Task.FromResult(response);
        }
    }
}
