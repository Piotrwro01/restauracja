using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
    class Rezerwacja 
    {
        private List<Stolik> aktualnarezerwacja = new List<Stolik>(); //lokalna lista stolików z naszej bazy [ListaStolikow.cs]

        ListaStolikow stoliki = new ListaStolikow();
        public void wypiszStoliczki()
        {
            aktualnarezerwacja = aktualnarezerwacja.OrderBy(x => x.id).ToList();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Lista stolików:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Stolik item in aktualnarezerwacja)
            {
                Console.WriteLine(item);
            }
        }
        public Rezerwacja(ListaStolikow obecnarezer)
        {
            aktualnarezerwacja = obecnarezer.zwrocListeStolikow();
        }
        public void zwrocAktualnarezerwacje()
        {
            Console.WriteLine(aktualnarezerwacja); 
        }

        public Stolik dobraniestolika(int ilemiejsc)
        {
            foreach (Stolik st in aktualnarezerwacja)
            {
                if (st.status == 0 && st.iloscmiejsc == ilemiejsc)
                {
                    Console.WriteLine($"Zarezerwowano stolik numer: {st.id}");
                    stoliki.zmienStatusStolika(st);
                    return (st);
                }               
            }
            Stolik tymczasowy = aktualnarezerwacja[aktualnarezerwacja.Count - 1];
            Console.WriteLine($"Nie znaleźliśmy żadnego pasującego stolika, poponujemy stolik {tymczasowy.id}");
            return (tymczasowy);
        }

    }
}
