using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Books1
{
    public partial class App
    {
        public App(IServiceCollection serviceCollection)
        {
            InitializeComponent();

            DependencyContainer.InitializeServices(serviceCollection);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
