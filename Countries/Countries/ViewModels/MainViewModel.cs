namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login { get; set; }
        #endregion

        #region Coonstructors
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
        #endregion
    }
}
