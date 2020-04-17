using Necessitudo.Models;
using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Explore
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            Items = new List<SliderItem> {
                new SliderItem{ ImagePath = "testImage.png" },
                new SliderItem{ ImagePath = "walkThroughImageTwo.png" },
                new SliderItem{ ImagePath = "walkThroughImageThree.png" }
            };
            SetProfileInfo();
        }

        public string About { get => $"{ AppInstance.Essentials.UserProfile.AboutMe}"; }
        public string Gender { get => $"{ AppInstance.Essentials.UserProfile.Gender}"; }     

        public string LastName { get => $"{ AppInstance.Essentials.UserProfile.LastName}"; }

        public string Profession { get => $"{ AppInstance.Essentials.UserProfile.Profession}"; }

        public string IEnjoy { get => $"{ AppInstance.Essentials.UserProfile.Hobbies}"; }

        public string FirstName { get => $"{ AppInstance.Essentials.UserProfile.FirstName}"; }

        public string Email { get => $"{ AppInstance.Essentials.UserProfile.Email}"; }

        public string FullName { get => $"{ AppInstance.Essentials.UserProfile.FirstName} {AppInstance.Essentials.UserProfile.LastName}"; }

        public string DateOfBirth { get => $"{ AppInstance.Essentials.UserProfile.DateofBirth.ToShortDateString()} "; }
        public bool InstagramLink
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public bool FacebookLink
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public bool LinkedInLink
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public int SocialMediaConnection 
        { 
            get => GetValue<int>(); 
            set => SetValue(value); 
        }

        public List<SliderItem> Items
        {
            get;
            set;
        }
       
        public ICommand EditProfilePageCommand => new Command(EditProfilePage);

        public async void EditProfilePage()
        {
            await PushPageAsync(new EditProfilePage());
        }

        public void SetProfileInfo()
        {           
            SocialMediaConnection = 3;
            InstagramLink = false;
            FacebookLink = false;
            LinkedInLink = true;
        }

        public ICommand LogoutCommand => new Command(LogoutProcedure);

        public async void LogoutProcedure()
        {
            StatusDialog.Show(StatusDialogType.Success, "Dating App", "You are about to logoff. Please confirm.", "Yes", async () =>
            {
                AppInstance.MainPage.Navigation.InsertPageBefore(new LoginPageView(), AppInstance.MainPage.Navigation.NavigationStack.First());
                await AppInstance.MainPage.Navigation.PopToRootAsync();
            },
             "No", null);
        }
    }
}