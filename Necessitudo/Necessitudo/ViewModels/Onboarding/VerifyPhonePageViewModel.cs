using Necessitudo.Views.Explore;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class VerifyPhonePageViewModel : BaseViewModel
    {
        public VerifyPhonePageViewModel()
        {

        }

        #region commands
        public ICommand VerifyPhonePageCommand => new Command(ResendOTP);
        public ICommand CompleteLoginCommand => new Command(CompleteLogin);
        public ICommand LoginPageCommand => new Command(BackToLoginPage);
        #endregion

        public string PinOne
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string PinTwo
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string PinThree
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string PinFour
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string OTP => PinOne + PinTwo + PinThree + PinFour;

        private async void ResendOTP()
        {
            //await PushPageAsync(new VerifyPhonePage());
        }

        private async void BackToLoginPage()
        {
            await PushPageAsync(new LandingPage());
        }

        public async void CompleteLogin()
        {           
            if(OTP.Length == 4)
            {
                AppInstance.MainPage.Navigation.InsertPageBefore(new CentralPage(), AppInstance.MainPage.Navigation.NavigationStack.First());
                await AppInstance.MainPage.Navigation.PopToRootAsync();
            }
        }
    }
}
