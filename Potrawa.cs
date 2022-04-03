using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class Potrawa : ICena
    {
        public string nazwa { get; }
        public int rodzaj { get; set; }

        public decimal cena { get; }

        public Potrawa(string n, int r, decimal c)
        {
            this.nazwa = n;
            this.rodzaj = r;
            this.cena = c;
        }

        public override string ToString()
        {
            return ($"{nazwa} za {cena} zł");
        }

        public decimal podajCene() => cena;
    }
}
