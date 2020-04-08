using Necessitudo.Services;
using Necessitudo.ViewModels.Onbaording;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.Onboarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPasswordPage : ContentPage
    {
        private SetPasswordPageViewModel _setPasswordPageViewModel;
        public static BindableProperty PinProperty = BindableProperty.Create("Pin", typeof(string), typeof(SetPasswordPage), defaultBindingMode: BindingMode.OneWayToSource);
        public string Pin
        {
            get
            {
                return (string)GetValue(PinProperty);
            }
            set
            {
                SetValue(PinProperty, value);
            }
        }
        public SetPasswordPage(SetPasswordPageViewModel setPasswordPageViewModel)
        {
            DependencyService.Get<IStatusBar>().HideStatusBar();
            InitializeComponent();
            BindingContext = _setPasswordPageViewModel = setPasswordPageViewModel;
            Pin = string.Empty;         
            Pin1.TextChanged += Pin1_TextChanged;
            Pin2.TextChanged += Pin2_TextChanged;
            Pin3.TextChanged += Pin3_TextChanged;
            Pin4.TextChanged += Pin4_TextChanged;
            Pin5.TextChanged += Pin5_TextChanged;
        }

        private void Pin5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin5.Text.Length > 0)
                Pin5.Unfocus();
            else
                Pin4.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text + Pin5.Text;
            _setPasswordPageViewModel.OTP = Pin;
        }

        private void Pin4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin4.Text.Length > 0)
                Pin5.Focus();
            else
                Pin3.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text + Pin5.Text;
            _setPasswordPageViewModel.OTP = Pin;
        }

        private void Pin3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin3.Text.Length > 0)
                Pin4.Focus();
            else
                Pin2.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text + Pin5.Text;
            _setPasswordPageViewModel.OTP = Pin;
        }

        private void Pin2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin2.Text.Length > 0)
                Pin3.Focus();
            else
                Pin1.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text + Pin5.Text;
            _setPasswordPageViewModel.OTP = Pin;
        }

        private void Pin1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pin1.Text.Length > 0)
                Pin2.Focus();
            Pin = Pin1.Text + Pin2.Text + Pin3.Text + Pin4.Text + Pin5.Text;
            _setPasswordPageViewModel.OTP = Pin;
        }



        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}