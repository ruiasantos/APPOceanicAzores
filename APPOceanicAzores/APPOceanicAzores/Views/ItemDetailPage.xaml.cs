using System.ComponentModel;
using Xamarin.Forms;
using APPOceanicAzores.ViewModels;

namespace APPOceanicAzores.Views
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