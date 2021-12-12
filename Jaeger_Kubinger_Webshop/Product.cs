using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    public class Product
    {
        string _Name;
        int _Preis;
        static ushort _Anzahl = 10000;
        int _ArtikelNummer;

        public string Name { 
            get { return _Name; } 
            set { _Name = value; } 
        }
        public int Preis { 
            get { return _Preis; } 
            set { _Preis = value; } 
        }
        public int ArtikelNummer {
            get { return _ArtikelNummer; } 
            set { _ArtikelNummer = value;}
        }
        public Product(string Name, int Preis, int ArtikelNummer)
        {
            this._Name = Name;
            this._Preis = Preis;
            this._ArtikelNummer = ArtikelNummer;
        }

        public override string ToString()
        {
            return $"{_Name} |  Preis:{_Preis} Euro | Lagerstand: {_Anzahl}| ArtikelNummer: {_ArtikelNummer}";
        }
       
    }

}
