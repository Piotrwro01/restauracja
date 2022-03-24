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
        static void Main(string[] args)
        {
            Console.Title = "Restauracja";
            Menu dlaKlienta = new Menu();
            //Console.WriteLine("Dodaj potrawę: ");
            //dlaKlienta.NoweDanie(Console.ReadLine());
            //dlaKlienta.wypiszMenu();
            Klient wyswietklienta = new Klient(4,"Adam", "Kowalski", 1, 0);
            //wyswietklienta.NowyKlient(Console.ReadLine());
            List<Klient> listaklientow = new List<Klient> {
                   new Klient(1, "Adam", "Kowalski", 1, 0),
                   new Klient(2, "Michał", "Trynkiewicz", 1, 0),
                   new Klient(3, "Daniel", "Nowak", 1, 0) };
            wyswietklienta.stworzListe(listaklientow);
            wyswietklienta.wypiszKlientow();

            //Menu dlaKlienta = new Menu();
            Zamowienie zamownienie = new Zamowienie(dlaKlienta);
            zamownienie.wybierzPotrawe(dlaKlienta);


        }
    }
}
