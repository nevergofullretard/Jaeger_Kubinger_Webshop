using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Jaeger_Kubinger_Webshop
{
    internal class Program
    {
        
        static void SaveProducts(String FilePath,  Lager lager)
        {
            using(StreamWriter sw = new StreamWriter(FilePath))
            {

            }
        }
        static void Main(string[] args)
        {
            string RelativeFilePath = @"..\..\files\Lager.csv";
            Lager Lager;

            Lager = new Lager(Lager.LoadProducts(RelativeFilePath));
            
            
            Console.WriteLine("\nWillkommen im Webshop JÄGINGER! Feel free to choose! \n");

            //Lager Lager = new Lager(new Product[] { new Product("Playmobil", 15, 1, 1000), new Product("Lego", 20, 2,10000) });
            Product p1 = new Product("Playmobil", 15, 1,1000);
            Product p2 = new Product("Lego", 20, 2,1000);
            Webshop Shop = new Webshop(Lager);
            User LoggedInUser = Shop.Login();
            Shop.RunShop(LoggedInUser);

        }
    }
}
