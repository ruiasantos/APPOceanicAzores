using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPOceanicAzores.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            try
            {
                //conexao com MySQL
                MySQLCon db = new MySQLCon();

                //carrega lista de strings com dados dos produtos
                db.GravaUsers(EntryUserEmail.Text, EntryUserPassword.Text, EntryUserPhoneNumber.Text, EntryUserName.Text);

                var Esperamensagem = this.DisplayAlert("Alert", "User registered correctly, please confirm your email", "OK", "Cancel");

                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
            catch (Exception ex)
            {
                //Toast.MakeText(this, "Erro : " + ex.Message, ToastLength.Short).Show();

                var Esperamensagem = this.DisplayAlert("Error", "Failed registration", "OK");
            }
            //App.Current.MainPage = new NavigationPage(new ItemsPage());
            //Navigation.PushAsync(new LoginPage());
        }
    }
}