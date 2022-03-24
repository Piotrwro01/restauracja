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
            Klient wyswietklienta = new Klient();
            Console.WriteLine("Dodaj klienta: ");
            wyswietklienta.NowyKlient(Console.ReadLine());
            wyswietklienta.wypiszKlientow();


        }
    }
}
