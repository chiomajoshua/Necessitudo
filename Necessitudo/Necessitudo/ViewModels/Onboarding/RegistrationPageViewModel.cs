using Necessitudo.Models;
using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        public RegistrationPageViewModel()
        {
            ListAges = PickerService.GetAges().OrderBy(c => c.Value).ToList();
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

        public string Profession
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Phone
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public DateTime DateOfBirth
        {
            get => GetValue<DateTime>();
            set => SetValue(value);
        }

        public DateTime MaxDob => DateTime.Now.AddYears(-18);

        public DateTime MinDob => DateTime.Now.AddYears(-50);


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
            if (!string.IsNullOrEmpty(LastName))
                if (!string.IsNullOrEmpty(FirstName))
                    if (!string.IsNullOrEmpty(Gender))
                        if (!string.IsNullOrEmpty(Email))                        
                            if(IsValidEmail(Email)) await PushPageAsync(new AdditionalProfilePage());
                            else StatusDialog.Show(StatusDialogType.Info, "Information", "Invalid email address format", "OK", null);
                        else StatusDialog.Show(StatusDialogType.Info, "Information", "Email address missing", "OK", null);
                    else StatusDialog.Show(StatusDialogType.Info, "Information", "No gender selected", "OK", null);
                else StatusDialog.Show(StatusDialogType.Info, "Information", "Firstname missing", "OK", null);
            else StatusDialog.Show(StatusDialogType.Info, "Information", "Lastname missing", "OK", null);
        }
        private async void CompleteRegistration()
        {
            await PushPageAsync(new SetPasswordPage(new SetPasswordPageViewModel()));
        }

        private async void LookingForPage()
        {          
              await PushPageAsync(new LookingForPage());;
        }

      
    }
}
