using Necessitudo.Controls;
using Necessitudo.Helpers;
using Necessitudo.Models;
using Necessitudo.Services;
using Necessitudo.Views.Onboarding;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Necessitudo
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();         

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            Essentials = new Essentials();
            if (Status == CustomerStatus.Completed)
            {
                MainPage = new ImageNavigationPage(new LoginPageView());
                Essentials.BackButtonVisibility = "false";
            }
            else
            {
                MainPage = new ImageNavigationPage(new LandingPage());
            }           
        }
       

        public Essentials Essentials { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public CustomerStatus Status
        {
            get => (CustomerStatus)Xamarin.Essentials.Preferences.Get("status", (int)CustomerStatus.Started);
            set => Xamarin.Essentials.Preferences.Set("status", (int)value);
        }       
    }
}
