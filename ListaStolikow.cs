using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class ListaStolikow
    {
        public List<Stolik> listastolikow { get; set; }
        public ListaStolikow()
        {
            listastolikow = zwrocListeStolikow();
        }

        public List<Stolik> zwrocListeStolikow()
        {
            return new List<Stolik> {
                   new Stolik (1, 2, 20, 1),
                   new Stolik (2, 2, 20, 1),
                   new Stolik (3, 4, 40, 0),
                   new Stolik (8, 1, 60, 0),
                   };
        }
        public void wypiszStoliki()
        {
            listastolikow = listastolikow.OrderBy(x => x.id).ToList();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Lista stolików:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Stolik item in listastolikow)
            {
                Console.WriteLine(item);
            }
        }
        public void NowyStolik(string dane)
        {
            string[] tablica = dane.Split();
            Regex sprawdzenieid = new Regex("^[0-9]+");
            Regex sprawdzeniemiejsc = new Regex("^[1-9]+");
            Regex sprawdzeniecena = new Regex("^[1-9][0-9]+$");
            Regex sprawdzeniestatus = new Regex("^[0-1]{1}$");
            if (sprawdzenieid.IsMatch(tablica[0]) && sprawdzeniemiejsc.IsMatch(tablica[1]) && sprawdzeniecena.IsMatch(tablica[2]) && sprawdzeniestatus.IsMatch(tablica[3]))
            {
                listastolikow.Add(new Stolik(int.Parse(tablica[0]), int.Parse(tablica[1]), int.Parse(tablica[2]), int.Parse(tablica[3])));
                Console.WriteLine("Dodano stolik");
            }
            else Console.WriteLine("Błędne dane");
        }

        public void zmienStatusStolika(Stolik dozmiany)
        {
           if(dozmiany.status == 0)
            {
                dozmiany.status = 1;
            }
                
        }
    }
}
