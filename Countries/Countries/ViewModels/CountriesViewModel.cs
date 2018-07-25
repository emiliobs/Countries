﻿namespace Countries.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Countries.Models;
    using Countries.Services;
    using Xamarin.Forms;

    public class CountriesViewModel:BaseViewModel
    {
        #region Services

        private ApiService apiService;

        #endregion

        #region Atributes

        private ObservableCollection<Countries> countries;

        #endregion

        #region Properties

        public ObservableCollection<Countries> Countries
        {
            get => countries;
            set
            {
                if (countries != value)
                {
                    countries = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Contructors

        public CountriesViewModel()
        {
            apiService = new ApiService();

            this.LoadCountries();
        }
        #endregion


        #region Methods

        private async void LoadCountries()
        {
            //aqui ikro mikro si hay conecction con internet:
            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                //aqui hago un back de la vista:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var apisecurity = Application.Current.Resources["APICountries"].ToString();

            var response = await this.apiService.GetList<Countries>(apisecurity,"/rest","/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,"Accept");

                //aqui hago un back de la vista:
                await Application.Current.MainPage.Navigation.PopAsync();

                return;
            }

            var listCountries = (List<Countries>)response.Result;

            this.Countries = new ObservableCollection<Countries>(listCountries);

        }

        #endregion

       
    }
}
