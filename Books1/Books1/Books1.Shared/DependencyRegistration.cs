using Books1.Shared.Models;
using Books1.Shared.Services;
using Books1.Shared.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Books1.Shared
{
    public static class DependencyRegistration
    {
        public static void AddServices(this IServiceCollection dependencies)
        {
            dependencies.AddSingleton<IOpenLibraryApiClient, OpenLibraryApiClient>();
        }

        public static void AddModels(this IServiceCollection dependencies)
        {
            dependencies.AddSingleton<IBookRepository, BookRepository>();
        }
        
        public static void AddViewModels(this IServiceCollection dependencies)
        {
            dependencies.AddTransient<BookRepositoryViewModel>();
        }
    }
}
