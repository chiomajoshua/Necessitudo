using Necessitudo.Views.General;
using Necessitudo.Views.Onboarding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// A dictionary of property names, property values. The property name is the
        /// key to find the property value.
        /// </summary>
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();
        #endregion

        

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }



        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {

                throw new ArgumentException("Invalid property name", propertyName);
            }
            _values[propertyName] = value;
            NotifyPropertyChanged(propertyName);
        }

        protected void SetValue<T>(Expression<Func<T>> propertyselector, T value)
        {
            string propertyName = GetPropertyName(propertyselector);
            SetValue<T>(value, propertyName);
        }


        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);
            return GetValue<T>(propertyName);
        }


        /// <summary>
        /// When overriden in a derived view model class, can be used to sort gather search item for the value wild card
        /// </summary>
        /// <param name="value">the data to search your collection ofr</param>
        /// <returns></returns>


        protected T GetValue<T>([CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                value = default(T);
                _values.Add(propertyName, value);
            }
            return (T)value;
        }
        


        public BaseViewModel MainVM
        {
            get;
            set;
        }


        public object Parameter
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = GetPropertyName(propertySelector);
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private string GetPropertyName(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }
            return memberExpression.Member.Name;
        }

        protected bool SetProperty<T>(ref T backfield, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private object GetValue(string propertyName)
        {
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                var propertyDescriptor =
                TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }
                value = propertyDescriptor.GetValue(this);
                _values.Add(propertyName, value);
            }
            return value;
        }



        protected Task PushPageAsync(Page page)
        {
            return App.Current.MainPage.Navigation.PushAsync(page);
        }

        public ICommand SlideCommand => new Command(() => MessagingCenter.Send<BaseViewModel>(this, "slide"));
        protected Task PushModalAsync(Page page)
        {
            return App.Current.MainPage.Navigation.PushModalAsync(page);
        }
        protected Task PopPageAsync() => App.Current.MainPage.Navigation.PopAsync();

        protected Task DisplayMessageAsync(string title, string message, string cancelBtn = "Ok") => App.Current.MainPage.DisplayAlert(title, message, cancelBtn);

        protected Task<bool> DisplayMessageAsync(string title, string message, string positiveBtn, string negativeBtn) => App.Current.MainPage.DisplayAlert(title, message, positiveBtn, negativeBtn);



        public App AppInstance => (App)Application.Current;






    }
}
