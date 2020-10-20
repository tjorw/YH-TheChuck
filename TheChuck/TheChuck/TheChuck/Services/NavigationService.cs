using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TheChuck.Services
{
    public class NavigationService : INavigationService
    {
        private Page MainPage => Application.Current.MainPage;

        public async Task GoBack()
        {
            await MainPage.Navigation.PopAsync();
        }

        public async Task GoToCategory(string category)
        {
            await MainPage.Navigation.PushAsync(new CategoryPage(category));
        }

        public async Task GoToSearch()
        {
            await MainPage.Navigation.PushAsync(new SearchPage());
        }
    }
}
