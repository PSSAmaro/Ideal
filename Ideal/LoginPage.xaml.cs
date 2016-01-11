using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ideal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            BDLocal.Sessao s = (from p in BDLocal.BDSingleton.conn.Table<BDLocal.Sessao>()
                                where p.Id == 1
                                select p).FirstOrDefault();
            if (s.Login)
                Ligar(s.Email, s.Password);
        }

        private async void Ligar(string email, string password)
        {
            var client = new HttpClient();
            string url = "http://senhaaqui.azurewebsites.net/dis/validar.php?email=" + email + "&password=" + password;
            var uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
            JsonObject jsonObject = JsonObject.Parse(response.ToString());
            if (jsonObject.GetNamedBoolean("valido", false))
            {
                var atualizar = BDLocal.BDSingleton.conn.InsertOrReplace(new BDLocal.Sessao()
                {
                    Id = 1,
                    Nome = jsonObject.GetNamedString("utilizador", "Erro"),
                    Password = password,
                    Email = email,
                    Admin = jsonObject.GetNamedBoolean("admin", false),
                    Login = true
                });
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var atualizar = BDLocal.BDSingleton.conn.InsertOrReplace(new BDLocal.Sessao()
                {
                    Id = 1,
                    Login = false
                });
                this.Frame.Navigate(typeof(LoginForm));
            }
        }
    }
}
