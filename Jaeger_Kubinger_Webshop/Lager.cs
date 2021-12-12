using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Lager
    {
        Product[] _Products;

        public Product[] Products { get; set; }
        
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
    }
}
