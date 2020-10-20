using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChuck.Services;
using TheChuck.ViewModels;
using Xamarin.Forms;

namespace TheChuck
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(viewModel.Categories.Count==0)
            {
                await viewModel.Load();
            }

        } 


        private async void CategoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var category = e.Item as string;
            await viewModel.GoToCategory(category);
        }
    }
}
