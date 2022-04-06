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
        public int status { get; set; }

        



        public Stolik(int id, int iloscmiejsc, int status)
        {
            this.id = id;
            this.iloscmiejsc = iloscmiejsc;
            this.status = status;
            var date1 = new DateTime(2008, 5, 1, 8, 30, 52);
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
            return ($"Stolik numer:{id,-10} Ilość miejsc: {iloscmiejsc,-10} Status stolika: {Zmiananazwystatusu(status)}");
        }
    }
}
