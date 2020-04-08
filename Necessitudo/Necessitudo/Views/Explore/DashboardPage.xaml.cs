using Necessitudo.Models;
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
    public partial class DashboardPage : TabbedPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }

        private void ManageTapped(object sender, EventArgs e)
        {
            var bindingContext = (sender as Button).BindingContext;
            var item = (People)bindingContext;
            suggestedVM.SelectedPerson = new People();
            suggestedVM.SelectedPerson = item;
            suggestedVM.ViewProfilePageCommand.Execute(null);
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}