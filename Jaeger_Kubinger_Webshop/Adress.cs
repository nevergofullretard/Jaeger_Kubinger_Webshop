using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Adress
    {
        
        

        public string Street { get; private set;}
        public int Number { get; private set;}
        public string City { get; private set;}
        public int ZipCode { get;  set;}

        public string GetCity()
        {
            return City;
        }

        public Adress(string street, int number, int zipCode, string city)
        {
            Street = street;
            Number = number;
            City = city;
            if (ZipCode < 10000) ZipCode = zipCode;
        }
        public bool Umzug(string NewStreet, int NewNumber, string NewCity, int NewZipCode)
        {
            Street = NewStreet;
            Number = NewNumber;
            City = NewCity;
            if (NewZipCode < 10000)
            {
                ZipCode = NewZipCode;
                return true;
            }
            else return false;


        }
        public override string ToString()
        {
            return $" {Street} {Number} \n {ZipCode} {City}";
        }
    }
}
