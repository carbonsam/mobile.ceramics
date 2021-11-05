using System;
using Books1.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Books1
{
    public static class DependencyContainer
    {
        public static IServiceProvider DependencyServiceProvider { get; private set; }

        public static void InitializeServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddModels();
            services.AddViewModels();

            DependencyServiceProvider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true
            });
        }
    }
}
