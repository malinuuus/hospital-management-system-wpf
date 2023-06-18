using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public abstract class Uzytkownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Haslo { get; set; }
        public string Posada
        {
            get
            {
                // posada jako typ z małej litery z polskimi literami
                Type type = this.GetType();
                if (type == typeof(Pielegniarka))
                    return "pielęgniarka";

                else
                    return type.Name.ToLower();
            }
        }

        public Uzytkownik(string imie, string nazwisko, string pesel, string nazwaUzytkownika, string haslo)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            NazwaUzytkownika = nazwaUzytkownika;
            Haslo = haslo;
        }

        public Uzytkownik() { }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
