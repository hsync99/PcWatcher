using PcWatcher.Services;
using PcWatcher.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PcWatcher
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<RestClient>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
