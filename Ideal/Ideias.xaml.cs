using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
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
    public sealed partial class Ideias : Page
    {
        public Ideias()
        {
            this.InitializeComponent();
        }

        private void IdeiaList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var atual = IdeiaList.SelectedItem;
            Frame.Navigate(typeof (TemplateIdeia));
        }

        // Gera dinamicamente uma lista de ideias presentes na DB
        /*private void geraLista(Array ideias)
        {
            foreach (var ideia in ideias)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Name = ideia[nome];

                StackPanel stckV = new StackPanel();
                stckV.Orientation = Orientation.Vertical;

                StackPanel stckH = new StackPanel();
                stckH.Orientation = Orientation.Horizontal;

                TextBlock titulo = new TextBlock();
                titulo.Text = ideia[titulo];

                TextBlock autor = new TextBlock();
                autor.Text = ideia[autor];

                TextBlock hora = new TextBlock();
                hora.Text = ideia[hora];
                hora.FontStyle = FontStyle.Italic;

                stckV.Children.Add(stckH);
                IdeiaList.Items.Add(stckV);
            }
        }*/
    }
}
