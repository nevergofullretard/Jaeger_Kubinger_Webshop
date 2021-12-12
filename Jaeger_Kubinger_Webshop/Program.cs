using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWillkommen im Webshop JÄGINGER! Feel free to choose! \n");

            Lager Lager = new Lager(new Product[] { new Product("Playmobil", 15, 1), new Product("Lego", 20, 2) });
            Product p1 = new Product("Playmobil", 15, 1);
            Product p2 = new Product("Lego", 20, 2);
            Webshop Shop = new Webshop(Lager);
            Shop.Login();
            Shop.RunShop();

        }
    }
}
