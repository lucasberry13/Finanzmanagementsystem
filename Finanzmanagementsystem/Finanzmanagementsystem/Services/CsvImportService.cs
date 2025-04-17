using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using Finanzmanagementsystem.Models;

namespace Finanzmanagementsystem.Services
{
    public static class CsvImportService
    {
        public static List<Transaktion> LadeTransaktionenAusCsv(string pfad)
        {
            var transaktionen = new List<Transaktion>();
            foreach (var zeile in File.ReadLines(pfad).Skip(1))
            {
                var teile = zeile.Split(';');
                if (teile.Length < 5) continue;

                transaktionen.Add(new Transaktion
                {
                    Datum = DateTime.ParseExact(teile[0], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Beschreibung = teile[1],
                    Betrag = decimal.Parse(teile[2]),
                    Kategorie = teile[3],
                    Typ = teile[4]
                });
            }
            return transaktionen;
        }
    }
}
