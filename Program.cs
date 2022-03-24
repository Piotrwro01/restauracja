using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Restauracja";
            KonsolaKlienta konsolaKlienta = new KonsolaKlienta();
            konsolaKlienta.przywitanie();
            Menu dlaKlienta = new Menu();
            List<Potrawa> aktualneZamowienie = dlaKlienta.podajMenu();
            dlaKlienta.wypiszMenu();
            Zamowienie zamownienie = new Zamowienie(dlaKlienta);
            //zamownienie.wypiszAktualneZamowienie(aktualneZamowienie);
            zamownienie.wybierzPotrawe(dlaKlienta);

        }
    }
}
