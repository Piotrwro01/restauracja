using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace restauracja
{
    class KonsolaKlienta
    {
        Klient uzytkownik { get; set; }
        Menu menu { get; set; }
        Zamowienie zamowienieUzytkownika;

      
        public KonsolaKlienta(Klient uzytkownik, Menu menu, ListaStolikow listaStolikow)
        {
            this.uzytkownik = uzytkownik;
            this.menu = menu;
            this.zamowienieUzytkownika = new Zamowienie(menu);
            
            
            Console.Clear();
            Console.WriteLine($"Witaj {uzytkownik.imie}, miło nam znowu Cię gościć. \nCo chciałbyś dzisiaj zrobić?");
            
            bool dzialamy = true;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Write($"   [r] Zarezerwować stolik\n   [z] Złożyć zamówienie");
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.R:
                        Rezerwacja rezerwowanko = new Rezerwacja(listaStolikow);
                        Console.WriteLine("\nPodaj liczbę miejsc przy stoliku:");                      
                        Regex sprawdzeniedanych = new Regex("^[1-6]$");
                        string dosprawdzenia = Console.ReadLine();
                        if (sprawdzeniedanych.IsMatch(dosprawdzenia))
                        {
                            rezerwowanko.dobraniestolika(int.Parse(dosprawdzenia));
                            Console.WriteLine("Czy chcesz podjąć jeszcze jakieś działania jako klient? (T/N)");
                            keyInfo = Console.ReadKey();
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.T:
                                    Console.WriteLine();
                                    continue;

                                case ConsoleKey.N:
                                    Console.WriteLine();
                                    Console.Clear();
                                    break;
                            }
                        }
                        else 
                        Console.ForegroundColor = ConsoleColor.Yellow; // TODO:pozwala od razu jeszcze raz wpisać liczbe miejsc
                        Console.WriteLine("Nie posiadamy stolika z taką ilością miejsc.");                       
                        Console.ForegroundColor = ConsoleColor.White;
                        

                        break;

                    case ConsoleKey.Z:
                        //Console.Clear();
                        Console.WriteLine("Już przyjmujemy Twoje zamówienie.\n");
                        decimal kwota = zamowienieUzytkownika.wybierzPotrawe(menu);
                        uzytkownik.balans -= kwota;
                        Console.WriteLine($"{uzytkownik.imie}, kwota do zapłaty wynosi {uzytkownik.balans}");
                        break;

             
                        
                    default:
                        Console.Clear();
                        Console.Write("Podjąłeś dziwny wybór. Chcesz opóścić program? (wpisz t/n) ");
                        string dec = Console.ReadLine();
                        dzialamy = dec == "t" ? false : true;
                        break;
                }
            } while (dzialamy);            
        }

    }
}
