using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Input;
using Finanzmanagementsystem.Models;
using Finanzmanagementsystem.Services;
using System.ComponentModel;

namespace Finanzmanagementsystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Transaktion> Transaktionen { get; set; } = new();

        public decimal SummeEinnahmen => Transaktionen.Where(t => t.Typ == "Einnahme").Sum(t => t.Betrag);
        public decimal SummeAusgaben => Transaktionen.Where(t => t.Typ == "Ausgabe").Sum(t => Math.Abs(t.Betrag));
        public decimal Gesamtbudget => SummeEinnahmen - SummeAusgaben;

        public ICommand LadeCsvCommand => new RelayCommand(LadeCsv);

        public ObservableCollection<BudgetEintrag> Budgets { get; set; } = new();


        private void LadeCsv()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV Dateien (*.csv)|*.csv"
            };
            if (dialog.ShowDialog() == true)
            {
                var daten = CsvImportService.LadeTransaktionenAusCsv(dialog.FileName);
                Transaktionen.Clear();
                foreach (var t in daten)
                    Transaktionen.Add(t);

                OnPropertyChanged(nameof(SummeEinnahmen));
                OnPropertyChanged(nameof(SummeAusgaben));
                OnPropertyChanged(nameof(Gesamtbudget));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
