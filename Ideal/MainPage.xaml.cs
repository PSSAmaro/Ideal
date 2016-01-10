using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.SqlClient;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            MyFrame.Navigate(typeof (Homepage));
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(MyFrame.CanGoBack)
                MyFrame.GoBack();
        }

        private void FowardButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(MyFrame.CanGoForward)
                MyFrame.GoForward();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeMenu.IsSelected)
            {
                MyFrame.Navigate(typeof (Homepage));
            }
            else if (IdeiasMenu.IsSelected)
            {
                MyFrame.Navigate(typeof (Ideias));
            }
            else if (SubscricoesMenu.IsSelected)
            {
                MyFrame.Navigate(typeof (Subscricoes));
            }
            else if (ContaMenu.IsSelected)
            {
                MyFrame.Navigate(typeof (Conta));
            }
            else if (DefinicoesMenu.IsSelected)
            {
                MyFrame.Navigate(typeof (Definicoes));
            }
        }
    }
}
