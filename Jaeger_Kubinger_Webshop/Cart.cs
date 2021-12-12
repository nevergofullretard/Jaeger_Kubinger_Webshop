using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Cart
    {
        public List<int> Produkte = new List<int>();

        public string Name { get; set; }
        public int Preis { get; set; }
        public int ArtikelNummer { get { return ArtikelNummer; } set { ArtikelNummer = value; } }
        public Cart()
        {

        }
        
       
        public void AddToCart(Product p)
        {
            if (!Produkte.Contains(p.ArtikelNummer))
            {
                Console.WriteLine("Gib bitte die Anzahl an Spielzeugsets die du in den Warenkorb legen willst an.");
                int AnzahlProdukte = Convert.ToInt32(Console.ReadLine());
                for(int i=0; i<AnzahlProdukte; i++)
                {
                    Produkte.Add(p.ArtikelNummer);
                }
                
                
            }
        }

        public void showItems(Lager l)
        {
            foreach (int i in Produkte)
            {
                Product p = l.getProduct(i);
                Console.Write("Name: " + p.Name + " Preis: " + p.Preis + " ArtNummer: " + p.ArtikelNummer+"\n");
            }
        }
        public void DeleteCart()
        {
            Produkte = new List<int>();
        }
    }
}
