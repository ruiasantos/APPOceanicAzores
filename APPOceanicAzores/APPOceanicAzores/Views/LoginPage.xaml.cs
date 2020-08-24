using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using APPOceanicAzores.ViewModels;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPOceanicAzores.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {        
        private string users;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        public void Signup_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Signup());
        }

        public void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                //conexao com MySQL
                MySQLCon db = new MySQLCon();

                //carrega lista de strings com dados dos produtos
                int result = db.CarregaUsers(EntryUser.Text, EntryPassword.Text);


                this.DisplayAlert("Alert", "Código da mensagem\n\n"+Convert.ToString(result), "OK", "Cancel");
                if (result==0)
                {
                    App.Current.MainPage = new NavigationPage(new ItemsPage());
                }
                

            }
            catch (Exception ex)
            {
                //Toast.MakeText(this, "Erro : " + ex.Message, ToastLength.Short).Show();
                
                this.DisplayAlert("Error", "Failed User Name or Password", "OK");
            }

            //App.Current.MainPage = new NavigationPage(new ItemsPage());
          
        }
    }
}