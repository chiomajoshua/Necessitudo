using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Explore
{
    public class SocialMediaConnectPageViewModel : BaseViewModel
    {
        public SocialMediaConnectPageViewModel()
        {
            OnLoadDataCommand = new Command(async () => await LoadData());
        }
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
    }
}