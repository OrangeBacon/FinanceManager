using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

namespace FinanceManager {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        ObservableCollection<string> listItems = new ObservableCollection<string>();
        int CurrentSelection = 0;

        public MainPage() {
            this.InitializeComponent();
            Pages.ItemsSource = listItems;

            listItems.Add("Home");
            listItems.Add("Card1 Statement");
            listItems.Add("Card2 Statement");
            listItems.Add("Food Budget");

            Pages.SelectedItem = listItems[0];
        }

        private void Pages_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            foreach (object item in e.AddedItems) {
                string selection = item as string;
                if (selection != null) {
                    CurrentSelection = listItems.IndexOf(selection);
                }
            }
            updateMain();
        }

        private void updateMain() {
            if(CurrentSelection <= 0) {
                Main.Navigate(typeof(Home));
            } else {
                Main.Navigate(typeof(Statement));
            }
        }
    }
}
