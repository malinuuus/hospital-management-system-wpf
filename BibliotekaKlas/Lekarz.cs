using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotekaKlas
{
    public class Lekarz : Pracownik
    {
        [XmlIgnore]
        public Specjalnosc Specjalnosc { get; set; }
        public string SpecjalnoscString
        {
            get { return Specjalnosc.ToString(); }
            set { Specjalnosc = (Specjalnosc)Enum.Parse(typeof(Specjalnosc), value); }
        }
        public string NumerPWZ { get; set; }

        public Lekarz(string imie, string nazwisko, string pesel, string nazwaUzytkownika, string haslo, Specjalnosc specjalnosc, string numerPWZ) : base(imie, nazwisko, pesel, nazwaUzytkownika, haslo)
        {
            Specjalnosc = specjalnosc;
            NumerPWZ = numerPWZ;
        }

        public Lekarz() { }
    }
}
