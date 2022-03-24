using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
    class Stolik
    {
        public int id { get; set; }
        public int iloscmiejsc { get; set; }
        public int cena { get; set; }
        public int status { get; set; }


        public Stolik(int id, int iloscmiejsc, int cena, int status)
        {
            this.id = id;
            this.iloscmiejsc = iloscmiejsc;
            this.cena = cena;
            this.status = status;
        }
        public object Zmiananazwystatusu(int status)
        {
            if (status == 1)
            {
                return "Zarezerwowany";
            }
            else if (status == 0)
            {
                return "Wolny";
            }
            else return "Błąd";
        }

        public override string ToString()
        {
            return ($"Stolik numer:{id,-10} Ilość miejsc: {iloscmiejsc,-10} Cena stolika: {cena + "zł",-10}Status stolika: {Zmiananazwystatusu(status)}");
        }
    }
}
