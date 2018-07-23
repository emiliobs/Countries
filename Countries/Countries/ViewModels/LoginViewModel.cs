namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

    public class LoginViewModel
    {

        #region Atributes

        string email;
        string password;
        bool isRunning;
        bool isRemembered;
        bool isEnabled;

        #endregion

        #region Properties

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsRunning
        {
            get;
            set;
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }

        #endregion

        #region Contructors

        public LoginViewModel()
        {
            IsRemembered = true;
            IsEnabled = true;
        }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        #endregion
    }
}
