using Countries.Helpers;
using Countries.ViewModels;
using Countries.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Countries
{
	public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator { get; internal set; } 
        #endregion

        #region Contructors
        public App()
        {
            InitializeComponent();

            #if true
            LiveReload.Init();
            #endif

            //Aqui pregunto si hay token
            if (string.IsNullOrEmpty(Settings.Token))
            {

                MainPage = new NavigationPage(new LoginView());
                // MainPage = new MasterDetailView();
            }
            else
            {
                //aqui si ya tengo el token en persistencia los envio a la pagina masterdetailview
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Countries = new CountriesViewModel();
                MainPage = new MasterDetailView();
            }

        } 
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
