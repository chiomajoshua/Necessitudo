using Necessitudo.Models;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class LandingPageViewModel : BaseViewModel
    {
        public LandingPageViewModel()
        {
            Items = new List<SliderItem> {
                new SliderItem{ Title = "Meet Someone New", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImagePath = "walkThroughImageOne.png" },
                new SliderItem{ Title = "Verified Profiles", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImagePath = "walkThroughImageTwo.png" },
                new SliderItem{ Title = "Grow In Love", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", ImagePath = "walkThroughImageThree.png" }
            };
        }


        public List<Models.SliderItem> Items
        {
            get;
            set;
        }

        #region Commands
        public ICommand LoginPageCommand => new Command(GoToLoginPage);

        public ICommand RegistrationPageCommand => new Command(RegistrationPage);

        #endregion


        private async void GoToLoginPage()
        {
            await PushPageAsync(new LoginPageView());
        }

        private async void RegistrationPage()
        {
            await PushPageAsync(new RegistrationPage());
        }
        
    }
}
