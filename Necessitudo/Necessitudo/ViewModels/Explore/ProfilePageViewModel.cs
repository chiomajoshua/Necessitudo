using Acr.UserDialogs;
using Necessitudo.Models;
using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Explore
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            OnLoadDataCommand = new Command(async () => await LoadData());
            UserDialogs.Instance.HideLoading();
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
        public ICommand SocialMediaConnectPageCommand => new Command(async () => await PushPageAsync(new SocialMediaConnectPage()));

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
                UserDialogs.Instance.ShowLoading("Logging user out.. Please Wait...");
                await Task.Delay(2000);
                var result = await AppInstance.Essentials.Logout();
                UserDialogs.Instance.HideLoading();
                if (result.IsSuccessfull)
                {
                    AppInstance.MainPage.Navigation.InsertPageBefore(new LoginPageView(), AppInstance.MainPage.Navigation.NavigationStack.First());
                    await AppInstance.MainPage.Navigation.PopToRootAsync();
                }
                else
                {
                    StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Apologies. We cannot clear your session at the moment..Please try again later.", "Ok", null);
                }
               
            },
             "No", null);
        }

        #region FacebookIntegration
        public Command OnLoadDataCommand { get; set; }

        public ICommand OnLoginWithFacebookCommand => new Command(async () => await LoginFacebookAsync());

        IFacebookClient _facebookService = CrossFacebookClient.Current;
        string[] permisions = new string[] { "email", "public_profile", "user_posts" };

        public bool FacebookButton
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        private async Task LoginFacebookAsync()
        {
            try
            {
                FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(permisions);
                switch (response.Status)
                {
                    case FacebookActionStatus.Completed:
                        OnLoadDataCommand.Execute(null);
                        FacebookButton = false;
                        break;
                    case FacebookActionStatus.Canceled:

                        break;
                    case FacebookActionStatus.Unauthorized:
                        await App.Current.MainPage.DisplayAlert("Unauthorized", response.Message, "Ok");
                        break;
                    case FacebookActionStatus.Error:
                        await App.Current.MainPage.DisplayAlert("Error", response.Message, "Ok");
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public async Task LoadData()
        {

            var jsonData = await CrossFacebookClient.Current.RequestUserDataAsync
            (
                  new string[] { "id", "name", "email", "picture", "cover", "friends" }, new string[] { }
            );

            var data = JObject.Parse(jsonData.Data);
            var profile = new
            {
                FullName = data["name"].ToString(),
                Picture = new UriImageSource { Uri = new Uri($"{data["picture"]["data"]["url"]}") },
                Email = data["email"].ToString()
            };

            var facebookProfile = profile;

            // await LoadPosts();
        }
        #endregion
    }
}