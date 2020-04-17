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

        public string About
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Gender
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Title
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string LastName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Profession
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string IEnjoy
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string FirstName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Email
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string DateOfBirth
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
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

        public string FullName => FirstName + " " + LastName;
        public ICommand EditProfilePageCommand => new Command(EditProfilePage);

        public async void EditProfilePage()
        {
            await PushPageAsync(new EditProfilePage());
        }

        public void SetProfileInfo()
        {
            LastName = "Chioma";
            FirstName = "Joshua";
            About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah";
            DateOfBirth = string.Format("{0:MMMM dd, yyyy}", Convert.ToDateTime("25-04-1919"));
            Profession = "Information Technology Services";
            IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing";
            Email = "chiomajoshua@gmail.com";
            Title = "Mr";
            Gender = "Male";
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