using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
    class Osoba
    {
        //int id = 1;
        string imie { get; set; }
        string nazwisko { get; set; }
        decimal balans { get; set; } //TODO: dodawanie balansu automatycznie
        int rabat { get; set; }
    }
}
