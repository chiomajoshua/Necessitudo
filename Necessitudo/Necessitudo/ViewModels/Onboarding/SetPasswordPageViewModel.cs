using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class SetPasswordPageViewModel : BaseViewModel
    {
        public SetPasswordPageViewModel()
        {

        }
        public string OTP
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public ICommand FinalizeRegistrationCommand => new Command(CheckLogin);

        public async void CheckLogin()
        {
            if(OTP.Length < 5)
            {
                StatusDialog.Show(StatusDialogType.Info, "Dating App", "PIN less than Six(6) digits", "OK", null);
            }
            else
            {
                await PushPageAsync(new OnboardingCompletePage());
            }
        }
    }
}
