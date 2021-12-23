using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jaeger_Kubinger_Webshop
{
    class Lager
    {
        Product[] _Products;

        public Product[] Products { get; set; }

        public Lager() { }
        
        public Lager(Product[] Products)
        {
            _Products = Products;
        }

        public Product getProduct(int article)
        {
            foreach (Product p in _Products)
            {
                if(p.ArtikelNummer == article)
                {
                    return p;
                }
            }
            return null;
        }
        
        //testöadsjf346

         

        public override string ToString()
        {
            string OutPutString = "Artikel im Webshop: \n";
            foreach (var item in _Products)
            {
                OutPutString += item.ToString() + "\n";
            }
            return OutPutString;
        }

        public static Product[] LoadProducts(string FilePath)
        {

            List<Product> Produkte = new List<Product>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                sr.ReadLine(); //header line
                while (sr.EndOfStream == false)
                {
                    string Line = sr.ReadLine();
                    string[] LineData = Line.Split(';');
                    double Preis;
                    int Artikelnr;
                    ushort Anzahl;
                    double.TryParse(LineData[2], out Preis);
                    int.TryParse(LineData[0], out Artikelnr);
                    ushort.TryParse(LineData[3], out Anzahl);

                    Product Product = new Product(LineData[1], Preis, Artikelnr, Anzahl);
                    Produkte.Add(Product);
                }
            }

            return Produkte.ToArray();
        }
    }
}
