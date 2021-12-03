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
         //test only comment
        
        //testöadsjf

         

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
