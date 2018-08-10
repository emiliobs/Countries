namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public CountriesViewModel Countries { get; set; }
        public CountryViewModel Country { get; set; }
        #endregion

        #region Properties

        public TokenResponse Token { get; set; }

        public List<Countries> countriesList { get; set; }


        #endregion

        #region Coonstructors
        public MainViewModel()
        {
            instance = this;

            Login = new LoginViewModel();
        }
        #endregion

        #region Singleton

        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
          if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;

        }

        #endregion
    }
}
