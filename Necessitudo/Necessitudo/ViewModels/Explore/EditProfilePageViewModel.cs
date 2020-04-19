using Acr.UserDialogs;
using Necessitudo.Models;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Helpers;
using Necessitudo.Services.ViewModels;
using Necessitudo.Views.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Explore
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        public EditProfilePageViewModel()
        {
            About = AppInstance.Essentials.UserProfile.AboutMe;
            IEnjoy = AppInstance.Essentials.UserProfile.Hobbies;
            DealMakers = AppInstance.Essentials.UserProfile.DealMakers;
            DealBreakers = AppInstance.Essentials.UserProfile.DealBreakers;
            Profession = AppInstance.Essentials.UserProfile.Profession;
            AgeRange = AppInstance.Essentials.UserProfile.AgeRange;
        }

        public string About
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string IEnjoy
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string DealMakers
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string DealBreakers
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Profession
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string AgeRange
        {
            get => GetValue<string>();
            set => SetValue(value);
        }


        public ICommand UpdateProfileCommand => new Command(ProfileUpdate);

        private async void ProfileUpdate()
        {
            if (!await VaildateProfileInformation())
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Please Fill All Fields", "OK", null);
                return;
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Updating Customer Profile.. Please wait..");
                await Task.Delay(4000);
                var vm = DIFactory.Resolve<UserViewModel>();
                var authToken = AppInstance.Essentials.AuthToken;
                var updateModel = new UpdateUserViewModel
                {
                    Email = AppInstance.Essentials.UserProfile.Email,
                    AboutMe = About,
                    AgeRange = AgeRange,
                    DealBreakers = DealBreakers,
                    DealMakers = DealMakers,
                    Hobbies = IEnjoy,
                    Profession = Profession
                };
                var result = await vm.UpdateProfile(updateModel, authToken);
                UserDialogs.Instance.HideLoading();
                if (result.ResponseObject == true)
                {
                    AppInstance.Essentials.UserProfile.AboutMe = About;
                    AppInstance.Essentials.UserProfile.AgeRange = AgeRange;
                    AppInstance.Essentials.UserProfile.DealBreakers = DealBreakers;
                    AppInstance.Essentials.UserProfile.DealMakers = DealMakers;
                    AppInstance.Essentials.UserProfile.Hobbies = IEnjoy;
                    AppInstance.Essentials.UserProfile.Profession = Profession;
                    await AppInstance.Essentials.SaveUserProfileAsync();
                    StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Profile Update Successful", "OK", null);
                    return;
                }
                else
                {
                    StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Could Not Update Your Profile Now. Please ", "OK", null);
                    return;
                }
            }
        }

        private async Task<bool> VaildateProfileInformation()
        {
            if (!(!string.IsNullOrEmpty(About) && !string.IsNullOrEmpty(IEnjoy) && !string.IsNullOrEmpty(DealMakers) && !string.IsNullOrEmpty(DealBreakers)))
            {
                return false;
            }
            return true;
        }
    }
}