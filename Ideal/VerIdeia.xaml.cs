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
using Ideal.Classes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Ideal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VerIdeia : Page
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public int Pontuacao { get; set; }

        public VerIdeia()
        {
            this.InitializeComponent();
        }

        private async void carregarLista()
        {
            var client = new HttpClient();
            string url = "http://senhaaqui.azurewebsites.net/dis/comentarios.php?id=" + this.Id;
            var uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
            dynamic jsonObject = JsonObject.Parse(response.ToString());
            ComentarioFactory factory = new ComentarioFactory(jsonObject.GetNamedArray("comentario", new JsonArray()));
            Comens.ItemsSource = factory.Items;
        }

        private async void Gosto_OnClick(object sender, RoutedEventArgs e)
        {
            BDLocal.Sessao s = (from p in BDLocal.BDSingleton.conn.Table<BDLocal.Sessao>()
                                where p.Id == 1
                                select p).FirstOrDefault();
            
            var client = new HttpClient();
            string url = "http://senhaaqui.azurewebsites.net/dis/gosto.php?u=" + s.Oid + "&i=" + Id;
            var uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Classes.Ideia)
            {
                Classes.Ideia ideia = (Classes.Ideia) e.Parameter;
                this.Id = ideia.Id;
                this.Titulo = ideia.Titulo.ToUpper();
                this.Nome = ideia.Autor.Nome;
                this.Conteudo = ideia.Conteudo;
                this.Pontuacao = ideia.Pontuacao;
            }

            carregarLista();

            base.OnNavigatedTo(e);
        }
    }
}
