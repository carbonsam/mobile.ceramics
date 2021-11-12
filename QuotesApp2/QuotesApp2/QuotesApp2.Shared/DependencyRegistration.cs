using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using QuotesApp2.Shared.Services;

namespace QuotesApp2.Shared
{
    public static class DependencyRegistration
    {
        public static void InitializeServices(IServiceCollection services)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://quotes.rest/")
            };

            services.AddSingleton(httpClient);
            services.AddSingleton<IQuotesApiClient, QuotesApiClient>();
        }
    }
}
