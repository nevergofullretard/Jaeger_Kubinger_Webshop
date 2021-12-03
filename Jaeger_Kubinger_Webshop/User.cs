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
         DateTime _Birthday; //dd.mm.jjjj
        Gender _Sex;
        State _State;
        string _Svn;
        Adress _Adress;

        public string Surname { get; set; } 
        public string Name { get; set; }
        public Gender Sex { get; set; } 
        public State State { get; set; }
        public Adress Adress { get; set; }

        
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

        public User(string name, string surname, DateTime birthday, Adress adress) 
        {
            _Birthday = birthday;
            Name = name;
            Surname = surname;
            Adress = adress;
        }

        public override string ToString()
        {
            return $" Name: {Name}\n Nachname: {Surname} \n Geburtstag:{_Birthday}\n " +
                $"Adresse: {Adress.ToString()}";
        }

        public bool PruefungSvn()
        {
            if (_Birthday.Year > 1900)
            {
                string BirthdayString = _Birthday.ToString("dd") + _Birthday.ToString("MM") + _Birthday.ToString("yy");
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
