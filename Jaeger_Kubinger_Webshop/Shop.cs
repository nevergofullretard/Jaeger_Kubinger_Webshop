using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Shop
    {
        Product[] _Products;

        public Product[] Products { get; set; }
        
        public Shop(int NumOfProducts)
        {
            _Products = new Product[NumOfProducts];
        }

        public override string ToString()
        {
            string OutPutString = "Artikel im Webshop: \n";
            foreach (var item in Products)
            {
                OutPutString += item.ToString() + "\n";
            }
            return OutPutString;
        }
    }
}
