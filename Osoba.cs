using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
    class Osoba
    {
        public static int id = 1;
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public decimal balans { get; set; } //TODO: dodawanie balansu automatycznie
        public int rabat { get; set; }

        public Osoba(string imie, string nazwisko, decimal balans, int rabat)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.balans = balans;
            this.rabat = rabat;
        }

        public override string ToString()
        {
            return ($"ID:{id++,-5} Imie: {imie,-10} Nazwisko: {nazwisko,-15} Balans: {balans,-5} Rabat: {rabat}%");
        }
    }
}
