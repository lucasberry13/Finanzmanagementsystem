using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzmanagementsystem.Models
{
    public class Transaktion
    {
        public DateTime Datum { get; set; }
        public string Beschreibung { get; set; }
        public decimal Betrag { get; set; }
        public string Kategorie { get; set; }
        public string Typ { get; set; }
    }
}
