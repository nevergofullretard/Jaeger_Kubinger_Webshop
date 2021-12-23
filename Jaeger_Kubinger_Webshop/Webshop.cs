using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class Webshop
    {
 
        public User User { get;  private set; }
        public Lager Lager { get; private set; }

        public Cart Cart { get; private set; }
        

        public Webshop (Lager lager)
        {
            Lager = lager;
        }

        public void Login()
        {

            //Console.WriteLine("Bitte hier registrieren: \n ------------------------------");
            //new User(InputToString("Vorname:"), InputToString("Nachname:"), InputToDate("Geburtstag:"),
            //   new Adress(InputToString("Straße:"), InputToInt("Hausnummer:", 10000), InputToInt("PLZ:", 10000), InputToString("Ort:")))
            User = new User("Max", "Kubinger", DateTime.Now, new Adress("Musterstraße", 1, 1020, "Wien"));
            //Console.WriteLine($"-------------------------\nHallo {User.Name}! Viel Spaß beim Shoppen!\n--------------------------\n{Shop.ToString()}");
            //test234
        }


        public void RunShop()
        {
            Cart = new Cart();
            bool ContinueShopping = true;
            while (ContinueShopping)
            {
                switch (InputToInt("----------------\n   Hauptmenü \n---------------- \n[1] Nutzerdaten ändern \n[2] Produkt zum Warenkorb hinzufügen " +
                   "\n[3] Warenkorb anzeigen \n[4] Produkt aus Warenkorb löschen " +
                   "\n[5] Shop anzeigen \n[6] Bestellung abschließen \n[7] Shop verlassen", 7))
                {

                    case 1: // Nutzerdaten ändern: könnten alle möglichen Inputs sein, wir machen nur name und adresse
                        Console.WriteLine($"Dein jetziges Benutzerprofil: \n{User.ToString()}");
                        switch (InputToInt("[1] Name und Nachname ändern\n[2] Adresse ändern", 2))
                        {
                            case 1:
                                User.Name = InputToString("Neuer Vorname:");
                                User.Surname = InputToString("Neuer Nachname");
                                break;
                            case 2:
                                User.Adress = new Adress(InputToString("Neue Straße:"), InputToInt("Neue Hausnummer", 1000), InputToInt("Neue PLZ", 10000), InputToString("Neuer Ort:"));
                                break;
                        }
                        Console.WriteLine($"\n-------------------------------\nDein Benutzerprofil mit den neuen Daten: \n{User.ToString()}");
                        break;
                    case 2: //Produkt zum Warenkorb hinzufügen
                            //Cart.AddToCart(Product, Anzahl)
                        Console.WriteLine("Gib die ArtikelNummer des gewünschten Produkts ein um dieses in den Warenkorb zulegen.");
                        string input =Console.ReadLine();
                        Product pro = Lager.getProduct(int.Parse(input));
                        if(pro == null)
                        {
                            Console.WriteLine("Ungültige Artikelnummer");
                        }
                        else
                        {
                            Console.WriteLine(pro.Name);
                            Cart.AddToCart(pro);
                        }
                        break;
                    case 3: //Warenkorb anzeigen
                        Cart.showItems(Lager);
                            //Cart.ToString()
                        break;
                    case 4: //Produkt aus Warenkorb löschen
                            //Cart.DeleteProduct(Product, Anzahl)
                        Cart.DeleteCart();
                        break;
                    case 5: //Shop/Produkte anzeigen
                        Console.WriteLine(Lager.ToString());
                        break;
                    case 6: //Bestellung abschließen
                            //Cart.CompleteOrder()
                        break;
                    case 7:
                        ContinueShopping = false;
                        break;

                }
            }
        }

        static int InputToInt(string Message, int MaximumInt)
        {
            int OutputInt = 0;
            
            do
            {
                Console.WriteLine(Message);
            } while (!int.TryParse(Console.ReadLine(), out OutputInt) || OutputInt < 1 || OutputInt > MaximumInt);
            return OutputInt;
        }
        static string InputToString(string Message)
        {
            Console.WriteLine(Message);
            return Console.ReadLine();
        }
        static DateTime InputToDate(string Message)
        {
            DateTime Date;
            do
            {
                Console.WriteLine(Message);
            } while (!DateTime.TryParse(Console.ReadLine(), out Date));
            return Date;
        }
    }
}
