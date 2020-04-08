using Necessitudo.Services;
using Necessitudo.ViewModels.Onbaording;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.Explore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private SuggestedPageViewModel _suggestedPageViewModel;
        public ProfilePage(SuggestedPageViewModel suggestedPageViewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            DependencyService.Get<IStatusBar>().HideStatusBar();
            InitializeComponent();
            BindingContext = _suggestedPageViewModel = suggestedPageViewModel;
            backFrame.BackgroundColor = new Color(0, 0, 0, 0.5);
            backFrame.Padding = new Thickness(6, 5, 6, 5);
            backStack.BackgroundColor = new Color(0, 0, 0, 0.5);
            backStack.Padding = new Thickness(6, 5, 6, 5);
            SetStars();
        }

        public void SetStars()
        {
            switch (_suggestedPageViewModel.SelectedPerson.SocialMediaConnection)
            {
                case 5:
                    starOne.Source = "filledStar.png";
                    starTwo.Source = "filledStar.png";
                    starThree.Source = "filledStar.png";
                    starFour.Source = "filledStar.png";
                    starFive.Source = "filledStar.png";
                    break;
                case 4:
                    starOne.Source = "filledStar.png";
                    starTwo.Source = "filledStar.png";
                    starThree.Source = "filledStar.png";
                    starFour.Source = "filledStar.png";
                    starFive.Source = "emptyStar.png";
                    break;
                case 3:
                    starOne.Source = "filledStar.png";
                    starTwo.Source = "filledStar.png";
                    starThree.Source = "filledStar.png";
                    starFour.Source = "emptyStar.png";
                    starFive.Source = "emptyStar.png";
                    break;
                case 2:
                    starOne.Source = "filledStar.png";
                    starTwo.Source = "filledStar.png";
                    starThree.Source = "emptyStar.png";
                    starFour.Source = "emptyStar.png";
                    starFive.Source = "emptyStar.png";
                    break;
                default:
                    starOne.Source = "filledStar.png";
                    starTwo.Source = "emptyStar.png";
                    starThree.Source = "emptyStar.png";
                    starFour.Source = "emptyStar.png";
                    starFive.Source = "emptyStar.png";
                    break;
            }
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}