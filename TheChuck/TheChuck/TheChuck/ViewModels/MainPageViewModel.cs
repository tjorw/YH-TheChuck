using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>();

        public ICommand LoadCommand { get; }
        public ICommand GoToSearchCommand { get; }
        public ICommand GoToCategoryCommand { get; }

        public MainPageViewModel()
        {
            Title = "The Chuck";
            LoadCommand = new Command(async () => await Load(), () => !IsBusy);
            GoToSearchCommand = new Command(async () => await NavigationService.GoToSearch(), () => !IsBusy);
            GoToCategoryCommand = new Command<string>(async (category) => await NavigationService.GoToCategory(category), (category) => !IsBusy);
        }

        public async Task Load()
        {
            Categories.Clear();

            IsBusy = true;

            var categories = await ApiService.GetCategories();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }

            IsBusy = false;
        }

        public async Task GoToCategory(string category)
        {
            await NavigationService.GoToCategory(category);
        }

        protected override void RaiseAllCommandChanged()
        {
            base.RaiseAllCommandChanged();
            ((Command)LoadCommand).ChangeCanExecute();
            ((Command)GoToSearchCommand).ChangeCanExecute();
            ((Command<string>)GoToCategoryCommand).ChangeCanExecute();
        }
    }
}
