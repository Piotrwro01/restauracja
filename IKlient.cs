using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restauracja
{
     interface IKlient
    {
        public int id { get; }
        public string imie { get; }
        public string nazwisko { get; }
        public decimal balans { get; }
        public int rabat { get; }
        
    }
}
