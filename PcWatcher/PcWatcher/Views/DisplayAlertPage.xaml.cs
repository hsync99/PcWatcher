using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PcWatcher.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPage : PopupPage
    {
        public DisplayAlertPage()
        {
            InitializeComponent();
        }
        private async Task CloseP()
        {
            await Task.Delay(5000);
            await App.Current.MainPage.Navigation.RemovePopupPageAsync(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = CloseP();
        }
    }
}