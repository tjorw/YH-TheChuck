using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheChuck
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        SearchPageViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SearchPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchText.Focus();
        }

    }
}