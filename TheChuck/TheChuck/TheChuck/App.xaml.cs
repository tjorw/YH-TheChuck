using System;
using TheChuck.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheChuck
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterServices();

            MainPage = new NavigationPage(new MainPage());

        }

        private static void RegisterServices()
        {
            DependencyService.Register<ApiService>();
            DependencyService.Register<NavigationService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
