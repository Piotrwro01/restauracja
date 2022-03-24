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
            //Menu dlaKlienta = new Menu();
            //Console.WriteLine("Dodaj potrawę: ");
            //dlaKlienta.NoweDanie(Console.ReadLine());
            //dlaKlienta.wypiszMenu();

            //Klient wyswietlklientow = new Klient();
            //Console.WriteLine("Dodaj klienta: ");
            //wyswietlklientow.NowyKlient(Console.ReadLine());
            //wyswietlklientow.wypiszKlientow();

            ListaStolikow zarzadzaniestolikami = new ListaStolikow();
            Console.WriteLine("Dodaj stolik:");
            zarzadzaniestolikami.NowyStolik(Console.ReadLine());
            zarzadzaniestolikami.wypiszStoliki();
        }
    }
}
