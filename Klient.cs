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
        public List<Osoba> listaklientow { get; set; }

        public Klient()
        {
            listaklientow = zwrocListeKlientow();
        }
        public List<Osoba> zwrocListeKlientow()
        {
            return new List<Osoba> {
                   new Osoba ("Adam", "Kowalski", 1, 1),
                   new Osoba ("Michał", "Trynkiewicz", 1, 0),
                   new Osoba ("Daniel", "Nowak", 1, 0),
                   };
        }


        public void NowyKlient(string daneklienta)
        {
            string[] tablica = daneklienta.Split();
            Regex sprawdzenieimie = new Regex("^[A-Z]");
            Regex sprawdzenienazwisko = new Regex("^[A-Z]");
            Regex sprawdzenierabat = new Regex("^[0]?|[1-9]{1}[0-9]{1}");
            if (sprawdzenieimie.IsMatch(tablica[0]) && sprawdzenienazwisko.IsMatch(tablica[1]) && sprawdzenierabat.IsMatch(tablica[2]))
            {
                listaklientow.Add(new Osoba(tablica[0], tablica[1], int.Parse(tablica[2]), int.Parse(tablica[3])));
                Console.WriteLine("Dodano klienta");
            }
            else Console.WriteLine("Błędne dane");
        }
        public void wypiszKlientow()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Lista klientów:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Osoba item in listaklientow)
            {
                Console.WriteLine(item);
            }
        }
    }
}
