namespace Countries.ViewModels
{
    using Countries.Helpers;
    using Countries.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public String Title { get; set; }
        public string ViewName { get; set; }
        #endregion

        #region Commands

        public ICommand NavigateCommand { get => new RelayCommand(Navigate); }


        #endregion

        #region Methods

        private void Navigate()
        {
            if (ViewName == "LoginView")
            {
                //aqui limpio los token en persistencia:
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;

                Application.Current.MainPage = new NavigationPage( new LoginView());

                //Con esta navigate pierda la navegacion:
                //Application.Current.MainPage = new LoginView();
            }
        }

        #endregion
    }
}
