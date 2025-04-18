using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finanzmanagementsystem.Models;

namespace Finanzmanagementsystem.ViewModels
{
    public class BudgetsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BudgetEintrag> BudgetUebersicht { get; set; } = new();
        private IEnumerable<Transaktion>? Transaktionen;

        public BudgetsViewModel(ObservableCollection<BudgetEintrag> uebergebeneBudgets)
        {
            BudgetUebersicht = uebergebeneBudgets;

            BudgetUebersicht.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (BudgetEintrag eintrag in e.NewItems)
                    {
                        eintrag.KategorieGeaendert += (s2, e2) =>
                        {
                            if (Transaktionen != null)
                                AktualisiereAusgaben(Transaktionen);
                        };
                    }
                }

                if (Transaktionen != null)
                    AktualisiereAusgaben(Transaktionen);
            };
        }

        public void AktualisiereAusgaben(IEnumerable<Transaktion> transaktionen)
        {


            Transaktionen = transaktionen;

            var aktuellerMonat = DateTime.Now.Month;
            var aktuellesJahr = DateTime.Now.Year;

            

            foreach (var eintrag in BudgetUebersicht)
            {

                //var transaktionenProKategorie = transaktionen
                var gefundene = transaktionen
                    .Where(t => string.Equals(t.Typ?.Trim(), "Ausgabe", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(t.Kategorie?.Trim(), eintrag.Kategorie?.Trim(), StringComparison.OrdinalIgnoreCase)
                        && t.Datum.Month == aktuellerMonat
                        && t.Datum.Year == aktuellesJahr)
                    .ToList();

                

                eintrag.Ausgaben = gefundene.Sum(t => Math.Abs(t.Betrag));
                eintrag.AnzahlTransaktionen = gefundene.Count;

                decimal gesamtAusgaben = BudgetUebersicht.Sum(b => b.Ausgaben);

                foreach (var b in BudgetUebersicht)
                {
                    b.AnteilAmBudgetGesamt = gesamtAusgaben > 0
                        ? b.Ausgaben / gesamtAusgaben * 100
                        : 0;

                    b.OnPropertyChanged(nameof(BudgetEintrag.AnteilAmBudgetGesamt));
                }
                
            }



        }

        public event PropertyChangedEventHandler? PropertyChanged;

       

    }

}
