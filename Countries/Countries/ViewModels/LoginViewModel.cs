namespace Countries.ViewModels
{
    using Countries.Services;
    using Countries.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Services

      private ApiService apiService;

        #endregion

        #region Atributes

        private string email;
        private string password;
        private bool isRunning;
        private bool isRemembered;
        private bool isEnabled;

        

        #endregion

        #region Properties

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRunning
        {
            get => isRunning;
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRemembered
        {
            get => isRemembered;
            set
            {
                if (isRemembered != value)
                {
                    isRemembered = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Contructors

        public LoginViewModel()
        {
            apiService = new ApiService();

            IsRemembered = true;
            IsEnabled = true;

            Email = "barrera_emilio@hotmail.com";
            Password = "Eabs-----55555";
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get => new RelayCommand(Login);
        }   

        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {

                await Application.Current.MainPage.DisplayAlert("Error","You must Enter an Email.","Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error","You must Enter a Password","Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            //if (Email != "barrera_emilio@hotmail.com" || Password != "Eabs123.")
            //{
            //    IsRunning = false;
            //    IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error", 
            //        "E-Mail or Password incorrect", 
            //        "Accept");

            //    password = string.Empty;

            //    return;
            //}   

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRunning = true;
                IsEnabled = false;
                await Application.Current.MainPage.DisplayAlert("Error",connection.Message,"Accept");
                return;

            }
            //var apiSecurity = Application.Current.Resources["ApiProduct"].ToString();
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();

            //aqui genero el token:
            var token = await apiService.GetToken(apiSecurity, Email, Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error",
                                                                "Something was wrong, please try late",
                                                                "Accept");
                return;

            }


            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;   
                await Application.Current.MainPage.DisplayAlert("Error",token.ErrorDescription, "Accept");
                Password = string.Empty;
                return;
            }

            //apuntador del singleton para cuando necesito varios llamados del singleton:
            var mainViewModel = MainViewModel.GetInstance();
            //aqui guarso el token en memoria, para cuando lo necesite:
            mainViewModel.Token = token;
            //aqui referencio el patron singleton:
            mainViewModel.Countries = new CountriesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CountriesView());

            IsRunning = false;
            IsEnabled = true;
            Email = string.Empty;
            Password = string.Empty;

           


        }


        #endregion

       
    }
}
