using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finanzmanagementsystem.ViewModels;

namespace Finanzmanagementsystem
{
    /// <summary>
    /// Interaktionslogik für StartseitePage.xaml
    /// </summary>
    public partial class StartseitePage : Page
    {
        
        public StartseitePage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Suchen und filtern...")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Suchen und filtern...";
                SearchBox.Foreground = Brushes.Gray;
            }
        }
    }
}
