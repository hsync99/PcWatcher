using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PcWatcher.ViewModels;
namespace PcWatcher.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel vm;
        public AboutPage()
        {
            InitializeComponent();
            vm = (AboutViewModel)BindingContext;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.OnAppearing();
            //ActionExpander.Direction = Xamarin.CommunityToolkit.UI.Views.ExpandDirection.Up;

        }

        private void TimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           if(e.PropertyName== "Time")
            {
                var t = _timePicker.Time;
                var h = t.Hours;
                var m = t.Minutes;
                vm.Hours = h;
                vm.Minutes = m;
            }

        }
    }
}