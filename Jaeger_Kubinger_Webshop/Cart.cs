using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jaeger_Kubinger_Webshop
{
    class Cart
    {
        public List<Product> Produkte = new List<Product>();

        public string Name { get; set; }
        public int Preis { get; set; }
        public int ArtikelNummer { get { return ArtikelNummer; } set { ArtikelNummer = value; } }
        public Cart()
        {

        }
        
       
        public void AddToCart(Product p)
        {
            if (!Produkte.Contains(p))
            {
                Console.WriteLine("Gib bitte die Anzahl an Spielzeugsets die du in den Warenkorb legen willst an.");
                int AnzahlProdukte = Convert.ToInt32(Console.ReadLine());
                for(int i=0; i<AnzahlProdukte; i++)
                {
                    Produkte.Add(p);
                }
                
                
            }
        }

        public void showItems(Lager l)
        {
            foreach (Product i in Produkte)
            {
                
                Console.Write("Name: " + i.Name + " Preis: " + i.Preis + " ArtNummer: " + i.ArtikelNummer+"\n");
            }
        }
        public void DeleteCart()
        {
            Produkte = new List<Product>();
        }
        public void FinishOrder()
        {
            foreach (var item in Produkte)
            {
                 item.Anzahl = item.Anzahl - 1;
            }
            using (StreamWriter SR = new StreamWriter(@"..\..\files\Bestaetigung.txt", false))
            {
                SR.WriteLine("Ihre Bestellung für folgende Produkte wurde abgeschlossen:");
                foreach (var item in Produkte)
                {
                    SR.WriteLine(item.ToString());
                }
            }
            
            Produkte = new List<Product>();
        }
    }
}
