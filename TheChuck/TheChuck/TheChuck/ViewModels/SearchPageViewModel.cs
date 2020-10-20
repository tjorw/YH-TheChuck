using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public ObservableCollection<Joke> Jokes { get; } = new ObservableCollection<Joke>();
        public ICommand SearchCommand { get; }

        public SearchPageViewModel()
        {
            Title = "Search";
            SearchCommand = new Command(async () => await Search(query), () => !IsBusy);
        }

        string query = string.Empty;
        public string Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }

        private async Task Search(string query)
        {
            IsBusy = true;
            
            var jokes = await ApiService.Search(query);

            Jokes.Clear();

            if (jokes != null)
            {
                foreach (var joke in jokes.result)
                {
                    Jokes.Add(joke);
                }
            }

            IsBusy = false;
        }

        protected override void RaiseAllCommandChanged()
        {
            base.RaiseAllCommandChanged();
            ((Command)SearchCommand).ChangeCanExecute();
        }

    }
}
