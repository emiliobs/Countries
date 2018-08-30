namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Countries.Helpers;
    using Models;

    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        public CountriesViewModel Countries { get; set; }
        public CountryViewModel Country { get; set; }
        public MyProfileView MyProfile { get; set; }
        public StatisticsViewModel Statistics { get; set; }
        #endregion

        #region Properties

        public string Token { get; set; }
        public string TokenType { get; set; }


        //public TokenResponse Token { get; set; }

        public List<Countries> countriesList { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus{ get; set; }


        #endregion

        #region Coonstructors
        public MainViewModel()
        {
            instance = this;

            Login = new LoginViewModel();
            this.LoadMenu();
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

        #endregion Methods

        private void LoadMenu()
        {
            Menus = new ObservableCollection<MenuItemViewModel>();

            Menus.Add(new MenuItemViewModel
            {
               Icon = "ic_settings",
               ViewName = "MyProfileView",
               Title = Languages.MyProfile,
            });

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                ViewName = "StatisticsView",
                Title = Languages.Statics,
            });

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                ViewName = "LoginView",
                Title = Languages.LogOut,
            });
        }

        #region MyRegion

        #endregion
    }
}
