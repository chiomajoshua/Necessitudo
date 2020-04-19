using Acr.UserDialogs;
using Necessitudo.Models;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Helpers;
using Necessitudo.Services.ViewModels;
using Necessitudo.Views.Explore;
using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            MethodRun();
        }

        private async void MethodRun()
        {
            BackButtonVisibility = ButtonVisibility(AppInstance.Essentials?.BackButtonVisibility);
            await Task.Run(() => { while (AppInstance.Essentials?.UserProfile == null) ;});
            Email = AppInstance.Essentials?.UserProfile?.Email;
        }

        #region commands
        public ICommand VerifyPhonePageCommand => new Command(LoginProcedure);

        public ICommand BackButtonPageCommand => new Command(BackToLandingPage);
        #endregion

        
        public bool ButtonVisibility(string visibileValue)
        {
            if (visibileValue == "false") return false;
            return true;
        }

        public bool BackButtonVisibility
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public string Email
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Pin
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
              
        private async void BackToLandingPage()
        {
            await PushPageAsync(new LandingPage());
        }

        public async void LoginProcedure()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Pin))
            {                
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Email Address/Pin is missing", "Ok", null);
                return;
            }
            else
            if(!IsValidEmail(Email))
            {               
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Invalid email address format", "Ok", null);
                return;
            }
            else
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "You currently do not have internet access", "Ok", null);
                return;
            }
            else
            {               
                try
                {
                    UserDialogs.Instance.ShowLoading("Signing you in...");
                    await Task.Delay(4000);
                    var vm = DIFactory.Resolve<SecurityViewModel>();
                    var loginModel = new LoginViewModel
                    {
                        Email = Email,
                        Password = Pin
                    };
                    var result = await vm.Login(loginModel);                    

                    if (result.ResponseCode == Convert.ToInt32(ResponseCode.Successful))
                    {
                        if(Email != AppInstance.Essentials?.UserProfile?.Email)
                        {
                            AppInstance.Essentials.AuthToken = result.ResponseObject;
                            UserDialogs.Instance.ShowLoading("Retrieving User Profile... Please Wait...");
                            await Task.Delay(6000);
                            var userVM = DIFactory.Resolve<UserViewModel>();
                            var selectUserView = new SelectUserViewModel
                            {
                                Email = Email
                            };
                            var userProfileResult = await userVM.GetUserProfile(selectUserView, result.ResponseObject);
                           
                            if (userProfileResult.ResponseCode == Convert.ToInt32(ResponseCode.Successful))
                            {                                
                                AppInstance.Essentials.UserProfile = Helpers.Utility.TransformCustomer(userProfileResult.ResponseObject);
                                await AppInstance.Essentials.SaveUserProfileAsync();
                                AppInstance.Status = CustomerStatus.Completed;
                                
                                AppInstance.MainPage.Navigation.InsertPageBefore(new CentralPage(), AppInstance.MainPage.Navigation.NavigationStack.First());
                                await AppInstance.MainPage.Navigation.PopToRootAsync();
                                //UserDialogs.Instance.HideLoading();
                                return;
                            }
                            StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "We Could Not Retireve Your Profile at This Time... Please Try Again...", "Ok", null);
                            return;                           
                        }
                        else
                        {
                            AppInstance.Status = CustomerStatus.Completed;
                            //UserDialogs.Instance.HideLoading();
                            AppInstance.Essentials.AuthToken = result.ResponseObject; AppInstance.MainPage.Navigation.InsertPageBefore(new CentralPage(), AppInstance.MainPage.Navigation.NavigationStack.First());
                            await AppInstance.MainPage.Navigation.PopToRootAsync();
                        }                      
                    }
                    else
                        if(result.ResponseCode == Convert.ToInt32(ResponseCode.User_Not_Found))
                        {                            
                            StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "You are not a registered user.", "Ok", async () =>
                            {
                                await PushPageAsync(new RegistrationPage());
                            });
                        }
                    else
                        if (result.ResponseCode == Convert.ToInt32(ResponseCode.Incorrect_Username_Or_Password))
                        {                          
                            StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "Email/Pin Is Incorrect.", "Ok", null);
                        }
                    else
                    {                       
                        StatusDialog.Show(StatusDialogType.Info, "Necessitudo", "An Error Occured", "Ok", null);
                    }
                }
                catch(Exception ce)
                {

                }                
            }
        }
    }
}