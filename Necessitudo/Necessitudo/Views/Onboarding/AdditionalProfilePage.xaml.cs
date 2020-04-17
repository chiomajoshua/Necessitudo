using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.Onboarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionalProfilePage : ContentPage
    {
        public AdditionalProfilePage()
        {
            InitializeComponent();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}