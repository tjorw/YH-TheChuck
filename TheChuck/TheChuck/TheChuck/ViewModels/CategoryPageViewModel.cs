using System.Threading.Tasks;
using System.Windows.Input;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public class CategoryPageViewModel : BaseViewModel
    {
        private readonly string category;

        public ICommand LoadNewCommand { get; }

        public CategoryPageViewModel(string category)
        {
            this.category = category;
            this.Title = category.ToUpper();

            LoadNewCommand = new Command(async () => await LoadNew(), () => !IsBusy);
        }

        Joke joke = null;
        public Joke Joke
        {
            get { return joke; }
            set { SetProperty(ref joke, value); }
        }

        public async Task LoadNew()
        {
            Joke = await ApiService.GetRandomByCategory(category);

        }

        protected override void RaiseAllCommandChanged()
        {
            base.RaiseAllCommandChanged();
            ((Command)LoadNewCommand).ChangeCanExecute();
        }

    }
}
