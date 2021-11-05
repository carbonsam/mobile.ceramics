using System;
using Books1.Shared.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms.Xaml;

namespace Books1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage
    {
        private readonly BookRepositoryViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();

            var vm = DependencyContainer.DependencyServiceProvider.GetRequiredService<BookRepositoryViewModel>();

            BindingContext = viewModel = vm;
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            viewModel.GetAuthorWorks();
        }
    }
}
