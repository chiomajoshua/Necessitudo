using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {

        }

        #region commands
        public ICommand VerifyPhonePageCommand => new Command(LoginProcedure);

        public ICommand BackButtonPageCommand => new Command(BackToLandingPage);
        #endregion


        public string Email
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Pin
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
              
        private async void BackToLandingPage()
        {
            await PushPageAsync(new LandingPage());
        }
        
        public async void LoginProcedure()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Pin))
            {
                Xamarin.Essentials.Vibration.Vibrate(300);
                StatusDialog.Show(StatusDialogType.Info, "Dating App", "Email Address/Pin is missing", "OK", null);
            }
            else
            if(IsValidEmail(Email))
            {
                Xamarin.Essentials.Vibration.Vibrate(300);
                StatusDialog.Show(StatusDialogType.Info, "Dating App", "Invalid email address format", "OK", null);
            }
            else
            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
            {
                StatusDialog.Show(StatusDialogType.Info, "Dating App", "You currently do not have internet access", "Ok", null);
                return;
            }
            else
            {
                await PushPageAsync(new CentralPage());
            }
        }       
    }
}