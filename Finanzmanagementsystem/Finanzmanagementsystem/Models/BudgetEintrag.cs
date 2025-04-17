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
        
        private decimal _betrag;
        public decimal Betrag
        {
            get => _betrag;
            set
            {
                _betrag = value;
                OnPropertyChanged(nameof(Betrag));
                OnPropertyChanged(nameof(Verfuegbar));
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
            }
        }

       

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

        public event EventHandler? KategorieGeaendert;


        public decimal Verfuegbar => Betrag - Ausgaben;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    }
}
