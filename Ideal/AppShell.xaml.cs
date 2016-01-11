using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Core;
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
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;
        }

        // == return this.frame
        public Frame AppFrame => this.Frame;

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
            // Remover a login page da backstack
            if (AppFrame.BackStack.Count > 0 && AppFrame.BackStack[AppFrame.BackStack.Count - 1].SourcePageType.Name == "LoginPage")
                AppFrame.BackStack.RemoveAt(AppFrame.BackStack.Count - 1);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppFrame.CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
        }

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled && this.AppFrame.CanGoBack)
            {
                e.Handled = true;
                this.AppFrame.GoBack();
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(MainPage));
            }
            else if (IdeiasMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(Ideias));
            }
            else if (CampanhasMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(Campanhas));
            }
            else if (SubscricoesMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(Subscricoes));
            }
            else if (ContaMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(Conta));
            }
            else if (DefinicoesMenu.IsSelected)
            {
                AppFrame.Navigate(typeof(Definicoes));
            }
            Split.IsPaneOpen = false;
        }

        private void NovaIdeia_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NovaIdeia));
        }

        private void NovaCampanha_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NovaCampanha));
        }
    }
}
