using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void Login(string FilePath)
        {
            
            bool LoggedIn = false;
             while (LoggedIn == false)
            {
                switch (InputToInt("----------------\n   Login-Page \n---------------- \n[1] Login \n[2] Register ", 2))
                {
                    case 1: //log in with existing data
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            string Username = InputToString("Username:");
                            string Password = InputToString("Password");
                            while (sr.EndOfStream == false)
                            {
                                string Line = sr.ReadLine();
                                string[] LineData = Line.Split(';');

                                if (LineData[0] == Username && LineData[6] == Password) 
                                {
                                    LoggedIn = true;
                                    int Number;
                                    int ZipCode;
                                    DateTime Birthday;
                                    DateTime.TryParse(LineData[1], out Birthday);
                                    int.TryParse(LineData[5], out ZipCode);
                                    int.TryParse(LineData[3], out Number);
                                    User =  new User(LineData[0], Birthday, new Adress(LineData[2], Number, ZipCode, LineData[4]), LineData[6]);
                                }
                                
                            }
                        }
                        break;
                    case 2: //generate new data
                        User = new User(InputToString("Username:"), InputToDate("Geburtstag:"),
                        new Adress(InputToString("Straße:"), InputToInt("Hausnummer:", 10000), InputToInt("PLZ:", 10000),
                        InputToString("Ort:")), InputToString("Passwort:"));
                        //User = new User("kubinger", DateTime.Now, new Adress("Musterstraße", 1, 1020, "Wien"), "password");

                        using (StreamWriter sw = new StreamWriter(FilePath, true))
                        {

                            sw.WriteLine($"{User.Username};{User.Birthday};{User.Adress.Street};" +
                                $"{User.Adress.Number};{User.Adress.City};{User.Adress.ZipCode};{User.Password}");
                        }
                        LoggedIn = true;
                        break;
                }
            }
            

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
                        switch (InputToInt("[1] Username ändern\n[2] Adresse ändern", 2))
                        {
                            case 1:
                                User.Username = InputToString("Neuer Username:");
                                
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
                        Cart.FinishOrder();
                        Console.WriteLine("Vielen Dank für ihre Bestellung. Kommen sie gerne wieder.");
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
