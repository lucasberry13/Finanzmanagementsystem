using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Finanzmanagementsystem.Models;
using Finanzmanagementsystem.ViewModels;

namespace Finanzmanagementsystem
{
    /// <summary>
    /// Interaktionslogik für BudgetsPage.xaml
    /// </summary>
    public partial class BudgetsPage : Page
    {
        private readonly BudgetsViewModel _viewModel;

        public BudgetsPage(ObservableCollection<BudgetEintrag> budgets, ObservableCollection<Transaktion> transaktionen)
        {
            InitializeComponent();

            Console.WriteLine("[DEBUG] BudgetsPage gestartet mit " + transaktionen.Count + " Transaktionen.");

            _viewModel = new BudgetsViewModel(budgets);
            _viewModel.AktualisiereAusgaben(transaktionen);

            DataContext = _viewModel;
        }

        public void AktualisiereMitTransaktionen(ObservableCollection<Transaktion> transaktionen)
        {
            _viewModel.AktualisiereAusgaben(transaktionen);
            DataContext = null;
            DataContext = _viewModel;
        }
    }
}
