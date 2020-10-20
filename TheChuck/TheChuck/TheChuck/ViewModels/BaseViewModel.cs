using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TheChuck.Services;
using Xamarin.Forms;

namespace TheChuck.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IApiService ApiService { get; set; }
        public INavigationService NavigationService { get; set; }

        public BaseViewModel()
        {
            try
            {
                ApiService = DependencyService.Get<IApiService>();
                NavigationService = DependencyService.Get<INavigationService>();
            }
            catch
            {

            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { 
                if(SetProperty(ref isBusy, value))
                {
                    OnPropertyChanged(nameof(IsIdle));
                    RaiseAllCommandChanged();
                }

            }
        }
        public bool IsIdle
        {
            get { return !isBusy; }
        }



        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaiseAllCommandChanged()
        {

        }
    }

}
