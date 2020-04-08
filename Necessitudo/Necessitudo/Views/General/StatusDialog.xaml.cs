using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.General
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatusDialog : PopupPage
    {
        public StatusDialog(StatusDialogType type, string titleVal, string msgVal, string btn1Text, Action btn1Ac, string btn2Text, Action btn2Ac)
        {
            InitializeComponent();
            title.Text = titleVal;
            description.Text = msgVal.Count() > 300 ? "An error occured." : msgVal;

            if (!string.IsNullOrEmpty(btn1Text))
            {
                okButton.Text = btn1Text;
                okButton.Clicked += (a, b) =>
                {
                    Navigation.PopPopupAsync();
                    btn1Ac?.Invoke();
                };
            }
            else okButton.IsVisible = false;


            if (!string.IsNullOrEmpty(btn2Text))
            {
                cancelButton.Text = btn2Text;
                cancelButton.Clicked += (a, b) =>
                {
                    Navigation.PopPopupAsync();
                    btn2Ac?.Invoke();
                };
            }
            else cancelButton.IsVisible = false;


            cancelButton.Text = btn2Text;

            //switch (type)
            //{
            //    case StatusDialogType.Success:
            //        icon.Source = "successIcon.png";
            //        break;
            //    case StatusDialogType.Info:
            //        icon.Source = "informationIcon.png";
            //        break;
            //    case StatusDialogType.Error:
            //        icon.Source = "errorInfo.png";
            //        break;
            //    default:
            //        break;
            //}
        }

        public static void Show(StatusDialogType type, string title, string msg, string btn1Text, Action btn1)
        {
            StatusDialog bd = new StatusDialog(type, title, msg, btn1Text, btn1, null, null);
            App.Current.MainPage.Navigation.PushPopupAsync(bd);
        }

        public static void Show(StatusDialogType type, string title, string msg, string btn1Text, Action btn1, string btn2Text, Action btn2)
        {
            StatusDialog bd = new StatusDialog(type, title, msg, btn1Text, btn1, btn2Text, btn2);
            App.Current.MainPage.Navigation.PushPopupAsync(bd);
        }

        public static void Show(StatusDialogType type, string title, string msg, string btn1Text, Action btn1, string btn2Text, Action btn2, string btn3Text, Action btn3)
        {
            StatusDialog bd = new StatusDialog(type, title, msg, btn1Text, btn1, btn2Text, btn2);
            App.Current.MainPage.Navigation.PushPopupAsync(bd);
        }
    }

    public enum StatusDialogType
    {
        Success, Info, Error
    }
}