using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;
using Finanzmanagementsystem.Models;

namespace Finanzmanagementsystem.ViewModels
{
    public class BerichteViewModel
    {
        public ObservableCollection<Monatsbericht> Monatsberichte { get; set; }

        public BerichteViewModel(IEnumerable<Transaktion> transaktionen)
        {
            Monatsberichte = new ObservableCollection<Monatsbericht>(
                transaktionen
                    .GroupBy(t => new { t.Datum.Year, t.Datum.Month })
                    .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                    .Select(g =>
                    {
                        string monatName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month);
                        decimal einnahmen = g.Where(t => t.Typ == "Einnahme").Sum(t => t.Betrag);
                        decimal ausgaben = g.Where(t => t.Typ == "Ausgabe").Sum(t => Math.Abs(t.Betrag));
                        return new Monatsbericht
                        {
                            Monat = monatName,
                            Einnahmen = einnahmen,
                            Ausgaben = ausgaben
                        };
                    })
            );
        }
    }
}
