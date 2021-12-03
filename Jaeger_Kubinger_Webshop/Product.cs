using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Product
    {
        string _Name;
        int _Preis;
        static ushort _Anzahl = 10000;


        public string Name { get; set; }

      public Product (string Name, int Preis)
        {
            _Name = Name;
            _Preis = Preis;
        }

        public override string ToString()
        {
            return $"{_Name} |  Preis:{_Preis} Euro | Lagerstand: {_Anzahl}";
        }

    }
}
