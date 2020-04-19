using Necessitudo.Services;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.Explore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CentralPage : Xamarin.Forms.TabbedPage
    {
        public CentralPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().EnableSwipePaging();
            DependencyService.Get<IStatusBar>().HideStatusBar();
        }
    }
}