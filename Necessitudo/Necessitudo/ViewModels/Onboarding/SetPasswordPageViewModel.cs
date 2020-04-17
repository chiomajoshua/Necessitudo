using Acr.UserDialogs;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "PIN less than Five(5) digits", "OK", null);
            }
            else
            {
                AppInstance.Essentials.UserProfile.Password = OTP;
                await AppInstance.Essentials.SaveUserProfileAsync();
                UserDialogs.Instance.ShowLoading("Creating Profile..Please Wait...");
                await Task.Delay(3000);                
                var result = await AppInstance.Essentials.RegisterNewUser();
                UserDialogs.Instance.HideLoading();
                if (result.IsSuccessfull)
                {                                      
                    await PushPageAsync(new OnboardingCompletePage());
                }
                else
                {
                    StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Apologies. We cannot create your profile at the moment..Please try again later.", "Ok", null);
                }
            }
        }
    }
}
