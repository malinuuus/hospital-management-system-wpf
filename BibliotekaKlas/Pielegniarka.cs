using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Pielegniarka : Pracownik
    {
        public Pielegniarka(string imie, string nazwisko, string pesel, string nazwaUzytkownika, string haslo) : base(imie, nazwisko, pesel, nazwaUzytkownika, haslo)
        {
        }

        public Pielegniarka() { }
    }
}
