using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Ideal.Classes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ideal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            carregarLista();
        }

        private async void carregarLista()
        {
            var client = new HttpClient();
            string url = "http://senhaaqui.azurewebsites.net/dis/trending.php";
            var uri = new Uri(url);
            var response = await client.GetStringAsync(uri);
            dynamic jsonObject = JsonObject.Parse(response.ToString());
            IdeiaFactory factory = new IdeiaFactory(jsonObject.GetNamedArray("ideia", new JsonArray()));
            Trends.ItemsSource = factory.Items;
        }

        private void List_Click(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(VerIdeia), e.ClickedItem);
        }
    }
}
