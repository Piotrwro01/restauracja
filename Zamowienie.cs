using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
    class Zamowienie : ICena
    {
        private decimal lacznaCena = 0;
        public decimal cena { get; }
        private List<Potrawa> aktualneZamowienie = new List<Potrawa>(); //pusta lista na dodawanie zamowien
        List<Potrawa> aktualneMenu { get; set; }
        public Zamowienie(Menu obecneMenu)
        {
            aktualneMenu = obecneMenu.podajMenu();
        }
        public decimal podajCene() => lacznaCena;

        private void usunPotraweZZamowienia(Potrawa doUsuniecia, int ileUsunac)
        {
            for(int i = 0; i<ileUsunac; i++) aktualneZamowienie.Remove(doUsuniecia);
        }
        private void dodajPotraweZZamowienia(Potrawa doUsuniecia, int ileDodac)
        {
            for (int i = 0; i < ileDodac; i++) aktualneZamowienie.Add(doUsuniecia);
        }

        private string naZolto(string tekstNaZolto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return tekstNaZolto;
        }
        private string naZielono(string tekstNaZolto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return tekstNaZolto;
        }
        private string naCzerwono(string tekstNaZolto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return tekstNaZolto;
        }
        private string naNiebiesko(string tekstNaZolto)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return tekstNaZolto;
        }


        public void wypiszAktualneZamowienie(List<Potrawa> aktualneZamowienie)
        {
            Console.WriteLine(naNiebiesko("\nTwoje aktualne zamownie: "));
            Console.ForegroundColor = ConsoleColor.White;
            int y = 0;
            List<Potrawa> zamowienie = new List<Potrawa>();
            foreach (Potrawa potrawa in aktualneZamowienie)
            {
                //y != 0 && aktualneZamowienie[y].nazwa == aktualneZamowienie[y-1].nazwa
                if (zamowienie.Contains(potrawa)) //czy element nie jest pierwszy i czy są takie same
                {
                    zamowienie.Add(potrawa);
                    y++;
                    continue; // jeżeli elementy są takie same, skipnij foreach
                }
                else //jeżeli pierwszy po prostu wypisz
                {
                    int podlicz = aktualneZamowienie.Count(p => p.nazwa == potrawa.nazwa); // liczba obiektów o tej nazwie w liście zamówienie
                    Console.WriteLine($"{potrawa.nazwa,-14} {potrawa.cena} zł x {podlicz}");
                }
                y++;
                zamowienie.Add(potrawa);
            }
            lacznaCena = 0; //czyści wartość po poprzednim wypisaniu
            foreach (Potrawa potrawa in aktualneZamowienie) lacznaCena += potrawa.podajCene(); //sumuje cene zamówienia

            Console.WriteLine($"{"Do zapłaty:",-14} {lacznaCena.ToString("0.00")} zł");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - -");
        }

        public string wyborKliena(string decyzja)// sprawdzanie + -, sprawdzanie potrawy, sprawdzanie czy wystąpiła, wypisywanie ile razy, sprowadzanie wszystkiego do wielkich liter, podsumowywanie
        {
            if (decyzja == "koniec") return "koniec";
            string[] tablicaDecyzji = decyzja.Split();
            if (tablicaDecyzji.Length == 1) return naZolto("Zapomniałeś określić, czy chcesz dodać potrawę czy usunąć z listy, lub nie dałeś spacji po + lub -");
            int ile = tablicaDecyzji.Length > 2 ? int.Parse(tablicaDecyzji[2]) : 1; // sprawdza ile uzytkownik chciał dodać
            var wybranaPotrawa = aktualneMenu.FirstOrDefault(o => o.nazwa.ToUpper() == tablicaDecyzji[1].ToUpper());
            if(wybranaPotrawa != null)
            {
                if (tablicaDecyzji[0] == "+") // dodaj potrawe do aktualne zamówienie
                {
                    dodajPotraweZZamowienia(wybranaPotrawa, ile);
                    return naZielono($"Dodano potrawę {wybranaPotrawa.nazwa}");
                }
                else if (tablicaDecyzji[0] == "-") // usuń potrawe z aktualne zamówienie
                {
                    usunPotraweZZamowienia(wybranaPotrawa, ile);
                    return naCzerwono($"Usunięto potrawę {wybranaPotrawa.nazwa}");
                }
                else return naZolto("Błędnie okreśłiłeś operację");
            }
            else return naZolto($"Błędnie wybrałeś potrawę, nie posiadamy potrawy: {tablicaDecyzji[1]}"); // wypisuje potrawe klienta
        }

        public decimal wybierzPotrawe(Menu obecneMenu)
        {
            bool czyKoniec = false;
            do
            {
                //https://stackoverflow.com/questions/58780190/box-drawing-characters-in-batch-scripts-windows-cmd 
                
                obecneMenu.wypiszMenu();
                wypiszAktualneZamowienie(aktualneZamowienie);
                Console.WriteLine("┌──────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Aby dodac lub usunac potrawe do swojego zamowienia,  │");
                Console.WriteLine("│ napisz najpier + albo - po czym nazwe potrawy.       │");
                Console.WriteLine("│ Np. + gulasz doda potrawę Gulasz do zamówienia       │");
                Console.WriteLine("│     - kluski usunie potrawę Kluski z zamówienia      │");
                Console.WriteLine("│ Gdy skończysz, napisz 'zamawiam' po czym potwierdz.  │");
                Console.WriteLine("└──────────────────────────────────────────────────────┘");
                Console.WriteLine("Co podać?");
                string decyz = Console.ReadLine(); // + , - : lista aktualnemenu contens potrwa.nazwa == input
                czyKoniec = true ? decyz == "koniec" : false;
                if (czyKoniec) //podwójne sprawdzenie
                {
                    Console.Write("Na pewno kończymy zamówienie? (t/n): ");
                    String naPewno = Console.ReadLine();
                    if (naPewno == "t") czyKoniec = true;
                    else czyKoniec = false;
                }
                Console.Clear();
                Console.WriteLine(wyborKliena(decyz));
            } while (!czyKoniec);
            //obciążamy balans klienta o lacznaCena(decimal)
            //komunikacja w konsoli klienta
            return lacznaCena;
        }

    }
}
