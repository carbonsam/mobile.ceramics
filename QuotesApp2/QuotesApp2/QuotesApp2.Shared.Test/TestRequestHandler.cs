using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace QuotesApp2.Shared.Test
{
    public class TestRequestHandler : HttpMessageHandler
    {
        public Func<HttpRequestMessage, HttpResponseMessage> SendBehavior { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.SendBehavior(request));
        }
    }
}
