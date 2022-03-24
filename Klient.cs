using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class Klient : IKlient
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public decimal balans { get; set; } //TODO: dodawanie balansu automatycznie
        public int rabat { get; set; }//TODO: wpisanie rabatu takiego jaki chcemy dac klientowi

        public Klient(int id, string imie, string nazwisko, decimal balans, int rabat)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.balans = balans;
            this.rabat = rabat;
        }

        public List<Klient> listaklientow { get; set; }
        public void przypiszid(List<Klient> listaklientow)
        {
            for (int i = 0; i < listaklientow.Count; i++)
            {
                listaklientow[i].id = i;
            }

        }
        public Klient()
        {
            listaklientow = zwrocListeKlientow();
        }
        public List<Klient> zwrocListeKlientow()
        {
            return new List<Klient> {
                   new Klient (przypiszid(listaklientow[0].id),"Adam", "Kowalski", 1, 0),
                   new Klient (3,"Michał", "Trynkiewicz", 1, 0),
                   new Klient (2,"Daniel", "Nowak", 1, 0),
                   };
        }

        public void NowyKlient(string daneklienta)
        {
            string[] tablica = daneklienta.Split();
            //Regex sprawdzenieid = new Regex("^[0-9]+");// dodawanie id automatycznie
            Regex sprawdzenieimie = new Regex("^[A-Z]");
            Regex sprawdzenienazwisko = new Regex("^[A-Z]");
            Regex sprawdzenierabat = new Regex("^[0-1]{1}$");
            if (sprawdzenieimie.IsMatch(tablica[1]) && sprawdzenienazwisko.IsMatch(tablica[2]) && sprawdzenierabat.IsMatch(tablica[4]))
            {
                listaklientow.Add(new Klient(int.Parse(tablica[0]), tablica[1], tablica[2], decimal.Parse(tablica[3]), int.Parse(tablica[4])));
                Console.WriteLine("Dodano klienta");
            }
            else Console.WriteLine("Błędne dane");
        }

        public void wypiszKlientow()
        {
            listaklientow = listaklientow.OrderBy(x => x.id).ToList();
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
            return ($"ID:{id,-5} Imie: {imie,-10} Nazwisko: {nazwisko,-15} Balans: {balans,-5}");
        }
    }
}
