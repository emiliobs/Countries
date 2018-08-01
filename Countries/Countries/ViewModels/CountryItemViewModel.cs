namespace Countries.ViewModels
{
    using Countries.Views;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CountryItemViewModel : Countries
    {
        #region Commands
        public ICommand SelectCountryCommand { get => new RelayCommand(SelectCountry); }
        #endregion

        #region Methods

        private async void SelectCountry()
        {
            //con el this paso toda la clase que viene en constructor des de el origen:
            MainViewModel.GetInstance().Country = new CountryViewModel(this);
            //await Application.Current.MainPage.Navigation.PushAsync(new CountryView());
            await Application.Current.MainPage.Navigation.PushAsync(new CountryTabbedPage());

        }

        #endregion
    }
}
