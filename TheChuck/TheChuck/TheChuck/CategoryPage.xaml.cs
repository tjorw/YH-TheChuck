using System;
using System.Collections.Generic;
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
    public partial class CategoryPage : ContentPage
    {

        CategoryPageViewModel viewModel;

        public CategoryPage(string category)
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryPageViewModel(category);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(viewModel.Joke == null)
            {
                await viewModel.LoadNew();
            }
        }

    }
}