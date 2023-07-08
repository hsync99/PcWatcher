using PcWatcher.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PcWatcher.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}