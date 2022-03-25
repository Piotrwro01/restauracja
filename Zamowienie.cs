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

        private void usunPotraweZZamowienia(Potrawa doUsuniecia)
        {
            aktualneZamowienie.Remove(doUsuniecia);
        }
        private void dodajPotraweZZamowienia(Potrawa doUsuniecia)
        {
            aktualneZamowienie.Add(doUsuniecia);
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
            List<Potrawa> czysta = new List<Potrawa>();
            int y = 0;
            foreach (Potrawa potrawa in aktualneZamowienie)
            {
                if(y != 0 && czysta.Contains(potrawa)) //czy element nie jest pierwszy i czy są takie same
                {
                    y++;
                    czysta.Add(potrawa);
                    continue; // jeżeli elementy są takie same, skipnij foreach
                }
                else
                {
                    int podlicz = aktualneZamowienie.Count(p => p.nazwa == potrawa.nazwa); // liczba obiektów o tej nazwie w liście zamówienie
                    Console.WriteLine($"{potrawa.nazwa,-14} {potrawa.cena} zł x {podlicz}");
                }
                czysta.Add(potrawa);
                y++;
            }
            lacznaCena = 0; //czyści wartość po poprzednim wypisaniu
            foreach (Potrawa potrawa in aktualneZamowienie) lacznaCena += potrawa.podajCene(); //sumuje cene zamówienia

            Console.WriteLine($"{"Do zapłaty:",-14} {lacznaCena.ToString("0.00")} zł");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - -");
        }

        public string wyborKliena(string decyzja)// sprawdzanie + -, sprawdzanie potrawy, sprawdzanie czy wystąpiła, wypisywanie ile razy, sprowadzanie wszystkiego do wielkich liter, podsumowywanie
        {
            if (decyzja == "koniec") return "Dziękujemy za zamówienie";
            string[] tablicaDecyzji = decyzja.Split();
            if (tablicaDecyzji.Length == 2)
            {
                decyzja += " PUSTKA";
            }
            tablicaDecyzji = decyzja.Split();
            if (tablicaDecyzji.Length == 1) return naZolto("Zapomniałeś określić, czy chcesz dodać potrawę czy usunąć z listy, lub nie dałeś spacji po + lub -");
            var wybranaPotrawa = aktualneMenu.FirstOrDefault(o => o.nazwa.ToUpper() == tablicaDecyzji[1].ToUpper());
            if(wybranaPotrawa != null)
            {
                int liczba;
                if(tablicaDecyzji[2] == "PUSTKA") liczba = 1; //sprawdza czy było puste miejsce
                else if (int.TryParse(tablicaDecyzji[2], out liczba)) liczba = int.Parse(tablicaDecyzji[2]);
                else liczba = 1;
                for (int i = 0; i< liczba; i++)
                {
                    if (tablicaDecyzji[0] == "+") // dodaj potrawe do aktualne zamówienie
                    {
                        dodajPotraweZZamowienia(wybranaPotrawa);
                        //return naZielono($"Dodano potrawę {wybranaPotrawa.nazwa}");
                    }
                    else if (tablicaDecyzji[0] == "-") // usuń potrawe z aktualne zamówienie
                    {
                        usunPotraweZZamowienia(wybranaPotrawa);
                        //return naCzerwono($"Usunięto potrawę {wybranaPotrawa.nazwa}");
                    }
                    else
                    {
                        return naZolto("Błędnie okreśłiłeś operację");
                        //continue;
                    }
                }
                if (tablicaDecyzji[0] == "+") return naZielono($"Dodano potrawę {wybranaPotrawa.nazwa}");
                else if (tablicaDecyzji[0] == "-") return naCzerwono($"Usunięto potrawę {wybranaPotrawa.nazwa}");
            }
            else return naZolto($"Błędnie wybrałeś potrawę, nie posiadamy potrawy: {tablicaDecyzji[1]}"); // wypisuje potrawe klienta
            return "Coś poszło nie tak";
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
