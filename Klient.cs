using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class Klient
    {

        public static int id = 1;
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public decimal balans { get; set; } //TODO: dodawanie balansu automatycznie
        public int rabat { get; set; }

        public Klient(string imie, string nazwisko, decimal balans, int rabat)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.balans = balans;
            this.rabat = rabat;
        }

        public List<Klient> listaklientow { get; set; }

        public void NowyKlient(string daneklienta)
        {
            string[] tablica = daneklienta.Split();
            Regex sprawdzenieimie = new Regex("^[A-Z]");
            Regex sprawdzenienazwisko = new Regex("^[A-Z]");
            Regex sprawdzenierabat = new Regex("^[0]?|[1-9]{1}[0-9]{1}");
            if (sprawdzenieimie.IsMatch(tablica[0]) && sprawdzenienazwisko.IsMatch(tablica[1]) && sprawdzenierabat.IsMatch(tablica[2]))
            {
                listaklientow.Add(new Klient(tablica[0], tablica[1], int.Parse(tablica[2]), int.Parse(tablica[3])));
                Console.WriteLine("Dodano klienta");
            }
            else Console.WriteLine("Błędne dane");
        }
        public void wypiszKlientow()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Lista klientów:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Klient item in listaklientow)
            {
                Console.WriteLine(item);
            }
        }

        public override string ToString()
        {
            return ($"ID:{id++,-5} Imie: {imie,-10} Nazwisko: {nazwisko,-15} Balans: {balans,-5} Rabat: {rabat}%");
        }
    }
}
