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

        static void Main(string[] args)
        {
            string LagerFilePath = @"..\..\files\Lager.csv";
            string UserFilePath = @"..\..\files\User.csv";

            Console.WriteLine("\nWillkommen im Webshop JÄGINGER! Feel free to choose! \n");

            Lager Lager = new Lager(Lager.LoadProducts(LagerFilePath)); //static method to load products into lager

            Webshop Shop = new Webshop(Lager); //generate new webshop with lager from csv

            Shop.Login(UserFilePath); //log in user with data from user csv

            Shop.RunShop(); //all shop commands when user is logged in

            Lager.SaveProducts(LagerFilePath); //add changes from lager to csv
        }
    }
}
