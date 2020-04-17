using Acr.UserDialogs;
using Necessitudo.Models;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Helpers;
using Necessitudo.Services.ViewModels;
using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        public RegistrationPageViewModel()
        {
            ListAges = PickerService.GetAges().OrderBy(c => c.Value).ToList();
            ConfirmationText = $" Hi {AppInstance.Essentials.UserProfile.FirstName}, Kudos for completing your registration. You can start meeting people now....";
        }
        
        public DateTime MaxDob => DateTime.Now.AddYears(-18);

        public DateTime MinDob => DateTime.Now.AddYears(-50);

        public string ConfirmationText
        {
            get => GetValue<string>();
            set => SetValue(value);
        }


        #region ProfessionPickerItem
        public List<string> ListProfessions
        {
            get;
            set;
        }

        private string _selectedProfession;
        public string SelectedProfession
        {
            get
            {
                return _selectedProfession;
            }
            set
            {
                SetProperty(ref _selectedProfession, value);
            }
        }

        private string _professionText;
        public string ProfessionText
        {
            get
            {
                return _professionText;
            }
            set
            {
                SetProperty(ref _professionText, value);
            }
        }

        #endregion

        #region AgePickerItem

        public List<Age> ListAges
        {
            get;
            set;
        }

        private Age _selectedAge;
        public Age SelectedAge
        {
            get
            {
                return _selectedAge;
            }
            set
            {
                SetProperty(ref _selectedAge, value);
                AgeText = _selectedAge.Value;
            }
        }
        private string _ageText;
        public string AgeText
        {
            get
            {
                return _ageText;
            }
            set
            {
                SetProperty(ref _ageText, value);
            }
        }
        #endregion

        public ICommand ProcessRegistrationCommand => new Command(ProcessRegistration);
        public ICommand LookingForPageCommand => new Command(LookingForPage);
        public ICommand ProcessFinalRegistrationCommand => new Command(CompleteRegistration);
        public ICommand BackButtonPageCommand => new Command(BackToLandingPage);
        public ICommand BackToRegistrationPageCommand => new Command(BackToRegistrationPage);
        public ICommand DashboardPageCommand => new Command(DashboardPage);

        private async void BackToLandingPage()
        {
            await PushPageAsync(new LandingPage());
        }

        private async void BackToRegistrationPage()
        {
            await PushPageAsync(new RegistrationPage());
        }

        private async void DashboardPage()
        {
            AppInstance.MainPage.Navigation.InsertPageBefore(new CentralPage(), AppInstance.MainPage.Navigation.NavigationStack.First());
            await AppInstance.MainPage.Navigation.PopToRootAsync();
        }

        private async void ProcessRegistration()
        {
            if (!await ValidateFields())
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Please Fill All Fields", "OK", null);
                return;
            }
            else
            if (!IsValidEmail(AppInstance.Essentials.UserProfile.Email))
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Invalid email address format", "OK", null);
                return;
            }
            else if (AppInstance.Essentials.UserProfile.DateofBirth == default)
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Please select date of birth.", "Ok", null);
                return;
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Validating Email...");
                await Task.Delay(3000);
                var vm = DIFactory.Resolve<SecurityViewModel>();
                var selectModel = new SelectUserViewModel
                {
                    Email = AppInstance.Essentials.UserProfile.Email
                };
                var result = await vm.ValidateEmail(selectModel);
                UserDialogs.Instance.HideLoading();
                if(result.ResponseObject == true)
                {
                    StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Email address already exists", "OK", null);
                    return;
                }
                else
                {
                    await AppInstance.Essentials.SaveUserProfileAsync();
                    await PushPageAsync(new AdditionalProfilePage());
                }                
            }
            
        }
        private async void CompleteRegistration()
        {
            if (!await ValidateLookingForPageFields())
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Please Fill All Fields", "OK", null);
                return;
            }
            else
            {
                await AppInstance.Essentials.SaveUserProfileAsync();
                await PushPageAsync(new SetPasswordPage(new SetPasswordPageViewModel()));
            }
        }

        private async void LookingForPage()
        {
            if (!await ValidateAdditionalProfilePageFields())
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Please Fill All Fields", "OK", null);
                return;
            }
            else
            {
                await AppInstance.Essentials.SaveUserProfileAsync();
                await PushPageAsync(new LookingForPage());
            }         
        }

        private async Task<bool> ValidateFields()
        {
            var userProfile = AppInstance.Essentials.UserProfile;
            if(!(!string.IsNullOrEmpty(userProfile.LastName) && !string.IsNullOrEmpty(userProfile.FirstName) && !string.IsNullOrEmpty(userProfile.Email) && !string.IsNullOrEmpty(userProfile.Gender) && !string.IsNullOrEmpty(userProfile.PhoneNumber) && !string.IsNullOrEmpty(userProfile.PhoneNumber)))
            {
                return false;
            }
            userProfile.DateofBirth = userProfile.DateofBirthSelected.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Replace("/", "-");
            return true;
        }

        private async Task<bool> ValidateAdditionalProfilePageFields()
        {
            var userProfile = AppInstance.Essentials.UserProfile;
            if (!(!string.IsNullOrEmpty(userProfile.Profession) && !string.IsNullOrEmpty(userProfile.Hobbies)))
            {
                return false;
            }
            return true;
        }

        private async Task<bool> ValidateLookingForPageFields()
        {
            var userProfile = AppInstance.Essentials.UserProfile;
            if (!(!string.IsNullOrEmpty(userProfile.AgeRange) && !string.IsNullOrEmpty(userProfile.DealMakers) && !string.IsNullOrEmpty(userProfile.DealBreakers)))
            {
                return false;
            }
            return true;
        }
    }
}