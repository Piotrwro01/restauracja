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
        static List<Klient> listaklientow = new List<Klient> { //jakaś uproszczona baza klientów, bez używania baz danych
                   new Klient(1, "Adam", "Kowalski", 1, 0),
                   new Klient(2, "Michał", "Trynkiewicz", 1, 0),
                   new Klient(3, "Daniel", "Nowak", 1, 0) };
        static void weryfikacjaKlienta()
        {
            Console.Clear();
            Console.WriteLine("Podaj swoje id: ");
            int id = int.Parse(Console.ReadLine());
            foreach(Klient obj in listaklientow)
            {
                if (id == obj.id) new KonsolaKlienta(obj, new Menu());
            }
        }
        void wlasciciel()
        {

        }

        static void Main(string[] args)
        {
            Menu dlaKlienta = new Menu();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string s = "██████╗░███████╗░██████╗████████╗░█████╗░██╗░░░██╗██████╗░░█████╗░░█████╗░░░░░░██╗░█████╗░\n██╔══██╗██╔════╝██╔════╝╚══██╔══╝██╔══██╗██║░░░██║██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔══██╗\n██████╔╝█████╗░░╚█████╗░░░░██║░░░███████║██║░░░██║██████╔╝███████║██║░░╚═╝░░░░░██║███████║\n██╔══██╗██╔══╝░░░╚═══██╗░░░██║░░░██╔══██║██║░░░██║██╔══██╗██╔══██║██║░░██╗██╗░░██║██╔══██║\n██║░░██║███████╗██████╔╝░░░██║░░░██║░░██║╚██████╔╝██║░░██║██║░░██║╚█████╔╝╚█████╔╝██║░░██║\n╚═╝░░╚═╝╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░░╚════╝░╚═╝░░╚═╝\n";
            Console.Title = "Restauracja";
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("█▀▀ █▀▀█ 　 █▀▀█ █▀▀█ █▀▀█ █▀▀▀ █▀▀█ █▀▀█ █▀▄▀█ ─▀─ █▀▀ ▀▀█▀▀ █▀▀█ 　 █───█ █──█ █▀▄▀█ █──█ █▀▀ █── ─▀─\n█── █──█ 　 █──█ █▄▄▀ █──█ █─▀█ █▄▄▀ █▄▄█ █─▀─█ ▀█▀ ▀▀█ ──█── █▄▄█ 　 █▄█▄█ █▄▄█ █─▀─█ █▄▄█ ▀▀█ █── ▀█▀\n▀▀▀ ▀▀▀▀ 　 █▀▀▀ ▀─▀▀ ▀▀▀▀ ▀▀▀▀ ▀─▀▀ ▀──▀ ▀───▀ ▀▀▀ ▀▀▀ ──▀── ▀──▀ 　 ─▀─▀─ ▄▄▄█ ▀───▀ ▄▄▄█ ▀▀▀ ▀▀▀ ▀▀▀\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            bool dzialamy = true;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.WriteLine("Identyfikujesz się jako: \n   [k] Klient\n   [w] Właściciel\n");
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.K:
                        weryfikacjaKlienta();
                        Console.Clear();
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Podjąłeś dziwny wybór. Chcesz opóścić program? (wpisz t/n) ");
                        string dec = Console.ReadLine();
                        dzialamy = dec == "t" ? false : true; 
                        break;
                }
            } while (dzialamy);
            
            //KonsolaKlienta konsolka = new KonsolaKlienta();
            //konsolka.przywitanie();
            ////Console.WriteLine("Dodaj potrawę: ");
            ////dlaKlienta.NoweDanie(Console.ReadLine());
            ////dlaKlienta.wypiszMenu();
            //Klient wyswietklienta = new Klient(4,"Adam", "Kowalski", 1, 0);
            ////wyswietklienta.NowyKlient(Console.ReadLine());
            
            //wyswietklienta.stworzListe(listaklientow);
            //wyswietklienta.wypiszKlientow();

            ////Menu dlaKlienta = new Menu();
            //Zamowienie zamownienie = new Zamowienie(dlaKlienta);
            //zamownienie.wybierzPotrawe(dlaKlienta);



        }
    }
}
