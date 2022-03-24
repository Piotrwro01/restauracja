using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace restauracja
{
    class  Menu
    {
        public List<Potrawa> glowneMenu { get; set; }
        public Menu()
        {
            glowneMenu = zwrocPodstawoweMenu();
        }

        public List<Potrawa> zwrocPodstawoweMenu() //bazowe menu
        {
            return new List<Potrawa> {
                    new Potrawa ("Gulasz",1, 10),
                    new Potrawa ("Barszcz",2, 6),
                    new Potrawa ("Pierogi",2, 12),
                    new Potrawa ("Sushi",1, 19)
                    };
        }

        public void wybierzPotrawe()
        {
        }

        public List<Potrawa> podajMenu() //NOWE
        {
            return glowneMenu.OrderBy(o => o.rodzaj).ThenBy(o => o.nazwa).ToList(); // NOWE
        }

        public void wypiszMenu()
        {
            List<Potrawa> posortowaneMenu = glowneMenu.OrderBy(o => o.rodzaj).ThenBy(o => o.nazwa).ToList(); //sortuje kategoriami -> alfabetycznie
            int i = 0;
            int zabezpiecznie = 1;
            foreach(Potrawa obj in posortowaneMenu)
            {
                if (posortowaneMenu[i].rodzaj == 1 && zabezpiecznie == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Przystawki");
                    Console.ForegroundColor = ConsoleColor.White;
                    zabezpiecznie++;
                }
                if (posortowaneMenu[i].rodzaj == 2 && zabezpiecznie == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Zupy");
                    Console.ForegroundColor = ConsoleColor.White;
                    zabezpiecznie++;
                }
                if (posortowaneMenu[i].rodzaj == 3 && zabezpiecznie == 3) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Dania główne");
                    Console.ForegroundColor = ConsoleColor.White;
                    zabezpiecznie++;
                }
                if (posortowaneMenu[i].rodzaj == 4 && zabezpiecznie == 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Desery");
                    Console.ForegroundColor = ConsoleColor.White;
                    zabezpiecznie++;
                }
                if (i <= posortowaneMenu.Count())
                {
                    Console.WriteLine($"{posortowaneMenu[i].nazwa,-10} {posortowaneMenu[i].cena} zł");
                }
                i++;
            }
        }
        public void NoweDanie(string dane)
        {
            string[] tablica = dane.Split();
            Regex sprawdzenienazwy = new Regex("^[A-Z]");
            Regex sprawdzerodzaju = new Regex("^[1-4]$");
            Regex sprawdzenieceny = new Regex("^[1-9][0-9]+$");
            if (sprawdzenienazwy.IsMatch(tablica[0]) && sprawdzerodzaju.IsMatch(tablica[1]) && sprawdzenieceny.IsMatch(tablica[2]))
            {
                glowneMenu.Add(new Potrawa(tablica[0], int.Parse(tablica[1]), decimal.Parse(tablica[2])));
                Console.WriteLine("Dodano pozycję do menu");
            }
            else Console.WriteLine("Błędne dane");         
        }

        //public override string ToString()
        //{
        //    przygodujMenu();
        //    return aktualneMenu;
        //}
    }
}
