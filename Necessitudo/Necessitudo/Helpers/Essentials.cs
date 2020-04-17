using Necessitudo.Models;
using Necessitudo.Models.RequestModel;
using Necessitudo.Services.Helpers;
using Necessitudo.Services.ViewModels;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Necessitudo.Helpers
{
    public class Essentials
    {
        private readonly string pathToUserFile;

        public Essentials()
        {
            pathToUserFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "user.txt");
            Task.Run(() => LoadUserProfileAsync());
        }

        public UserProfile UserProfile
        {
            get; set;
        }

        public void CleanUpSession()
        {
            if (File.Exists(pathToUserFile)) File.Delete(pathToUserFile);
        }

        private static readonly object locker = new object();
        private void LoadUserProfileAsync()
        {
            lock (locker)
            {
                if (!File.Exists(pathToUserFile)) File.Create(pathToUserFile).Dispose();
                var txt = File.ReadAllText(pathToUserFile);
                if (!string.IsNullOrEmpty(txt))
                {
                    UserProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<UserProfile>(File.ReadAllText(pathToUserFile));
                }
                else UserProfile = new UserProfile();
            }
        }

        private static readonly object _locker = new object();
        public async Task SaveUserProfileAsync()
        {
            try
            {
                lock (_locker)
                {
                    File.WriteAllText(pathToUserFile, Newtonsoft.Json.JsonConvert.SerializeObject(UserProfile));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public string BackButtonVisibility
        {
            get => GetValue("");
            set => SetValue(value);
        }

        public string AuthToken
        {
            get => GetValue("");
            set => SetValue(value);
        }
        

        public async Task<ApiCallResult<T>> GetApiAsync<T, Tvm>(Tvm viewModel, Func<Tvm, Task<T>> call, Func<T, string> respCode, Func<AggregateException, string> handleException, string failedMsg = "Oops an error occured, please try again later")
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) return new ApiCallResult<T> { IsSuccessfull = false, Message = "No Network Access" };

            try
            {
                var result = await call(viewModel);
                if (Utility.HandleResponseCode(respCode(result), out string message))
                {
                    return new ApiCallResult<T> { IsSuccessfull = true, Result = result };
                }
                else
                {
                    return new ApiCallResult<T> { IsSuccessfull = false, Result = result, Message = failedMsg };
                }
            }
            catch (Exception ex)
            {
                var emsg = handleException(new AggregateException(ex));
                emsg = ex.Message + Environment.NewLine + ex.InnerException.Message;
                return new ApiCallResult<T> { IsSuccessfull = false, Message = emsg };
            }
        }

        public async Task<ApiCallResult<bool>> RegisterNewUser()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) return new ApiCallResult<bool> { IsSuccessfull = false, Message = "oooppppsss.. You are disconnected from the internet..." };

            var vm = DIFactory.Resolve<SecurityViewModel>();

            try
            {
                var result = await vm.RegisterAccount(MapRegisterModel(UserProfile));
                if (Utility.HandleResponseCode(result.ResponseCode.ToString(), out string message))
                {
                    return new ApiCallResult<bool> { IsSuccessfull = true, Result = result.ResponseObject };

                }                
                else
                {
                    return new ApiCallResult<bool> { IsSuccessfull = false, Message = result.ResponseMessage };
                }
            }
            catch (Exception ex)
            {
                var emsg = vm.GetNetworkErrorMessage(new AggregateException(ex));


                return new ApiCallResult<bool> { IsSuccessfull = false, Message = emsg };
            }
        }

        private RegisterViewModel MapRegisterModel(UserProfile userProfile)
        {
            return new RegisterViewModel()
            {
               AgeRange = userProfile.AgeRange,
               AboutMe = userProfile.AboutMe,
               DealBreakers = userProfile.DealBreakers,
               DealMakers = userProfile.DealMakers,
               DateofBirth = userProfile.DateofBirth,
               Email = userProfile.Email,
               FirstName = userProfile.FirstName,
               Gender = userProfile.Gender,
               Hobbies = userProfile.Hobbies,
               LastName = userProfile.LastName,
               Password = userProfile.Password,
               PhoneNumber = userProfile.PhoneNumber,
               Profession = userProfile.Profession
            };
        }


        private T GetValue<T>(T defaultVal, [CallerMemberName]string propertyName = null) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Xamarin.Essentials.Preferences.Get(propertyName, Newtonsoft.Json.JsonConvert.SerializeObject(defaultVal)));

        private void SetValue<T>(T val, [CallerMemberName]string propertyName = null) => Xamarin.Essentials.Preferences.Set(propertyName, Newtonsoft.Json.JsonConvert.SerializeObject(val));
    }
}