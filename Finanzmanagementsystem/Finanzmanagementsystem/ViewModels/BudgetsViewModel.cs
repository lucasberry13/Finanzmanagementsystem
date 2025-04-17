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

            foreach (var eintrag in BudgetUebersicht)
            {
                var summe = transaktionen
                    .Where(t => t.Typ == "Ausgabe" && t.Kategorie == eintrag.Kategorie)
                    .Sum(t => Math.Abs(t.Betrag));
                eintrag.Ausgaben = summe;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

       

    }

}
