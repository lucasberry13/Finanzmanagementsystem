using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzmanagementsystem.Models
{
    public class BudgetEintrag : INotifyPropertyChanged
    {
        private string _kategorie = "";
        public string Kategorie
        {
            get => _kategorie;
            set
            {
                _kategorie = value;
                OnPropertyChanged(nameof(Kategorie));
                KategorieGeaendert?.Invoke(this, EventArgs.Empty);
            }
        }

        private decimal _betrag;
        public decimal Betrag
        {
            get => _betrag;
            set
            {
                _betrag = value;
                OnPropertyChanged(nameof(Betrag));
                OnPropertyChanged(nameof(Verfuegbar));
                OnPropertyChanged(nameof(AnteilAmBudgetGesamt));
            }
        }

        private decimal _ausgaben;
        public decimal Ausgaben
        {
            get => _ausgaben;
            set
            {
                _ausgaben = value;
                OnPropertyChanged(nameof(Ausgaben));
                OnPropertyChanged(nameof(Verfuegbar));
                OnPropertyChanged(nameof(Durchschnitt));
            }
        }

        public decimal Verfuegbar => Betrag - Ausgaben;

        private int _anzahlTransaktionen;
        public int AnzahlTransaktionen
        {
            get => _anzahlTransaktionen;
            set
            {
                _anzahlTransaktionen = value;
                OnPropertyChanged(nameof(AnzahlTransaktionen));
                OnPropertyChanged(nameof(Durchschnitt));
            }
        }

        public decimal Durchschnitt => AnzahlTransaktionen > 0 ? Ausgaben / AnzahlTransaktionen : 0;

        private decimal _anteilAmBudgetGesamt;
        public decimal AnteilAmBudgetGesamt
        {
            get => _anteilAmBudgetGesamt;
            set
            {
                _anteilAmBudgetGesamt = value;
                OnPropertyChanged(nameof(AnteilAmBudgetGesamt));
            }
        }

        public event EventHandler? KategorieGeaendert;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
