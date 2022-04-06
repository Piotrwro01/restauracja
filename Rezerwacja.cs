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

        //ListaStolikow stoliki = new ListaStolikow();
        ConsoleKeyInfo keyInfo;

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
        } //rezerwacja -> zmien status -> aktualnarezerwacja
        public void zwrocAktualnarezerwacje()
        {
            Console.WriteLine(aktualnarezerwacja);
        }

        public Stolik dobraniestolika(int ilemiejsc)
        {
            foreach (Stolik st in aktualnarezerwacja) //id 2 msc 2
            {
                if (st.iloscmiejsc == ilemiejsc && st.status == 0)
                {
                    Console.WriteLine($"Proponujemy stolik numer: {st.id}");
                    potwierdzenirezerwacji(st);
                    return st;
                }

                else if (st.iloscmiejsc == ilemiejsc && st.status != 0) //nie ma takiego wolnego 
                {
                    ilemiejsc += 1; //jeżeli nie ma x miejsc, to sprawdz x+1 
                   
                    foreach(Stolik oJedenWiecej in aktualnarezerwacja)
                    {
                        if (oJedenWiecej.iloscmiejsc == ilemiejsc && oJedenWiecej.status == 0) //id 2 msc 2 
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Wszystkie nasze stoliki na tą ilość osób są aktualnie zarezerowane, poponujemy stolik: {oJedenWiecej.id}, na ilośc miejsc {oJedenWiecej.iloscmiejsc}");
                            Console.ForegroundColor = ConsoleColor.White;
                            potwierdzenirezerwacji(oJedenWiecej);
                            return oJedenWiecej;
                        }
                    }
                                        
                }
                else
                {
                    //dostepne stoliki sa tylko mniejsze
                }
            }         
            return null;
        }
        private void potwierdzenirezerwacji(Stolik st)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Czy chcesz zarezerować zaproponowany stolik? (T/N)");
            Console.ForegroundColor = ConsoleColor.White;
            keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.T:
                    zmienStatusStolika(st); //TODO: ulepszyc zeby ten status zostawał
                    wypiszStoliczki();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nZarezerwowałeś stolik numer:{st.id}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ConsoleKey.N:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nDobrze");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void zmienStatusStolika(Stolik dozmiany)
        {
            //int pozycja = 0; //lista od zera
            //foreach (Stolik st in aktualnarezerwacja)
            //{
            //    pozycja++;
            //if (s dozmiany)
            //{
            //        aktualnarezerwacja[pozycja].status = 1;
            //    }

            //dozmiany.status = 1;
            ////}

        }
    }
}
