using System.Text;
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

namespace Finanzmanagementsystem;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Startseite_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel mainVM)
        {
            MainFrame.Navigate(new StartseitePage(mainVM));
        }
    }

    private void Berichte_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel mainVM)
        {
            MainFrame.Navigate(new BerichtePage(mainVM.Transaktionen));
        }
    }

    private void Budgets_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel mainVM)
        {
            MainFrame.Navigate(new BudgetsPage(mainVM.Budgets, mainVM.Transaktionen));
        }
    }


}