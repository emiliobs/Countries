namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Countries.Helpers;
    using Countries.Models;
    using Countries.Services;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class CountriesViewModel:BaseViewModel
    {
        #region Services

        private ApiService apiService;

        #endregion

        #region Atributes

        private ObservableCollection<CountryItemViewModel> listCountries;
        private bool isRefreshing;
        private string filter;
        //private List<Countries> countriesList;         

        #endregion

        #region Properties

        public string Filter
        {
            get => filter;
            set
            {
                if (filter != value)
                {
                    filter = value;
                    Search();
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CountryItemViewModel> ListCountries
        {
            get => listCountries;
            set
            {
                if (listCountries != value)
                {
                    listCountries = value;
                    OnPropertyChanged();
                    
                }
            }
        }

        #endregion

        #region Contructors

        public CountriesViewModel()
        {
            apiService = new ApiService();

            LoadCountries();
        }
        #endregion

        #region Commands

        public ICommand RefreshCommand { get => new RelayCommand(LoadCountries); }
        public ICommand SearchCommand { get => new RelayCommand(Search); }
        

        #endregion

        #region Methods

      
        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                //ListCountries = new ObservableCollection<Countries>(countriesList);
                ListCountries = new ObservableCollection<CountryItemViewModel>(
                             this.ToCountryItemViewModel());
            }
            else
            {
                //ListCountries = new ObservableCollection<Countries>(
                //    countriesList.Where(c => c.Name.ToLower().Contains(Filter.ToLower()) ||
                //                             c.Capital.ToLower().Contains(Filter.ToLower())));
                ListCountries = new ObservableCollection<CountryItemViewModel>(
                    ToCountryItemViewModel().Where(c => c.Name.ToLower().Contains(Filter.ToLower()) ||
                                             c.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }


        private async void LoadCountries()
        {
            IsRefreshing = true;
            //aqu miro si hay conecction con internet:
            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                //aqui hago un back de la vista:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var apisecurity = Application.Current.Resources["APICountries"].ToString();
            var prefix = Application.Current.Resources["Prefix"].ToString();
            var controller = Application.Current.Resources["Controller"].ToString();

            var response = await this.apiService.GetList<Countries>(apisecurity,prefix,controller);

            if (!response.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert(Languages.Error,response.Message,Languages.Accept);

                //aqui hago un back de la vista:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

             MainViewModel.GetInstance().countriesList =  (List<Countries>)response.Result;
            //ListCountries = new ObservableCollection<Countries>(countriesList);
            ListCountries = new ObservableCollection<CountryItemViewModel>(
                             this.ToCountryItemViewModel());

            IsRefreshing = false;

        }

        private IEnumerable<CountryItemViewModel> ToCountryItemViewModel()
        {
            return MainViewModel.GetInstance().countriesList.Select(c => new CountryItemViewModel
            {
               
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes =c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies =c.Currencies,
                Demonym =c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones =c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations,
                

            });
        }





        #endregion


    }
}
