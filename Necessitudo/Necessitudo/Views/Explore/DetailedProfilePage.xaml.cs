using Necessitudo.Services;
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
    public partial class DetailedProfilePage : ContentPage
    {
        public DetailedProfilePage()
        {
            InitializeComponent();
            DependencyService.Get<IStatusBar>().ShowStatusBar();
            SetStars();
            SocialMediaImages();
        }
        public void SetStars()
        {
            switch (profilePageVM.SocialMediaConnection)
            {
                case 5:
                    starOne.Source = "starBlack.png";
                    starTwo.Source = "starBlack.png";
                    starThree.Source = "starBlack.png";
                    starFour.Source = "starBlack.png";
                    starFive.Source = "starBlack.png";
                    break;
                case 4:
                    starOne.Source = "starBlack.png";
                    starTwo.Source = "starBlack.png";
                    starThree.Source = "starBlack.png";
                    starFour.Source = "starBlack.png";
                    starFive.Source = "starTransparent.png";
                    break;
                case 3:
                    starOne.Source = "starBlack.png";
                    starTwo.Source = "starBlack.png";
                    starThree.Source = "starBlack.png";
                    starFour.Source = "starTransparent.png";
                    starFive.Source = "starTransparent.png";
                    break;
                case 2:
                    starOne.Source = "starBlack.png";
                    starTwo.Source = "starBlack.png";
                    starThree.Source = "starTransparent.png";
                    starFour.Source = "starTransparent.png";
                    starFive.Source = "starTransparent.png";
                    break;
                default:
                    starOne.Source = "starBlack.png";
                    starTwo.Source = "starTransparent.png";
                    starThree.Source = "starTransparent.png";
                    starFour.Source = "starTransparent.png";
                    starFive.Source = "starTransparent.png";
                    break;
            }
        }
        public void SocialMediaImages()
        {
            if (profilePageVM.FacebookLink) facebook.Source = "facebookColored.png";
            else facebook.Source = "facebookWhite.png";

            if (profilePageVM.InstagramLink) instagram.Source = "instagramColored.png";
            else instagram.Source = "instagramWhite.png";

            if (profilePageVM.LinkedInLink) linkedin.Source = "linkedInColored.png";
            else linkedin.Source = "linkedInWhite.png";
        }
    }
}