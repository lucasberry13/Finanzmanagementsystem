using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzmanagementsystem.Models
{
    public class Monatsbericht
    {
        public string Monat { get; set; } = "";
        public decimal Einnahmen { get; set; }
        public decimal Ausgaben { get; set; }
        public decimal Saldo => Einnahmen - Ausgaben;
    }
}
