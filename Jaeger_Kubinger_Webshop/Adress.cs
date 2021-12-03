using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Adress
    {
        string _Street;
        int _Number;
        string _City;
        int _ZipCode;


        public Adress(string Street, int Number, int ZipCode, string City)
        {
            _Street = Street;
            _Number = Number;
            _City = City;
            if (ZipCode < 10000) _ZipCode = ZipCode;
        }
        public bool Umzug(string NewStreet, int NewNumber, string NewCity, int NewZipCode)
        {
            _Street = NewStreet;
            _Number = NewNumber;
            _City = NewCity;
            if (NewZipCode < 10000)
            {
                _ZipCode = NewZipCode;
                return true;
            }
            else return false;


        }
        public override string ToString()
        {
            return $" {_Street} {_Number} \n {_ZipCode} {_City}";
        }
    }
}
