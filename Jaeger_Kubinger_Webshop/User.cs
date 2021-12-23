using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger_Kubinger_Webshop
{
    class User
    {
        string _Surname;
        string _Name;
        Gender _Sex;
        State _State;
        string _Svn;
        

        public string Surname { get; set; } 
        public string Name { get; set; }
        public Gender Sex { get; set; } 
        public State State { get; set; }
        public Adress Adress { get; set; }
        public DateTime Birthday { get; private set; }
        public string Password { get; private set; }
        public string Username { get;  set; }

        public DateTime GetBirthday()
        {
            return Birthday;
        }
        public string Svn
        {
            get
            {
                return _Svn;
            }
            set 
            {
                if (PruefungSvn()) _Svn = value;
                else throw new Exception("Sozialversicherungsnummer-Geburtsdatum" +
                        " stimmt nicht mit Geburtsdatum überein");
            }
        }
        public User()
        {
        }
        public User(string username, DateTime birthday, Adress adress, string password) 
        {
            Birthday = birthday;
            Username = username;
            Adress = adress;
            Password = password;
        }

        public override string ToString()
        {
            return $" Username: {Username} \n Geburtstag:{Birthday}\n " +
                $"Adresse: {Adress.ToString()}";
        }

        public bool PruefungSvn()
        {
            if (Birthday.Year > 1900)
            {
                string BirthdayString = Birthday.ToString("dd") + Birthday.ToString("MM") + Birthday.ToString("yy");
                if (_Svn.Length == 10)
                {
                    if (_Svn.EndsWith(BirthdayString)) return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
