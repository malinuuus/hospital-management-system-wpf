using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public abstract class Pracownik : Uzytkownik
    {
        public List<Dyzur> ListaDyzurow { get; set; }

        public Pracownik(string imie, string nazwisko, string pesel, string nazwaUzytkownika, string haslo) : base(imie, nazwisko, pesel, nazwaUzytkownika, haslo)
        {
            ListaDyzurow = new List<Dyzur>();
        }

        public Pracownik() { }

        public bool SprobujDodacDyzur(DateTime nowaData, out string wiadomosc)
        {
            // dyżur tej samej osoby nie może występować 2 razy w 1 dniu (dyżury całodobowe)
            bool czyDwaDyzury = ListaDyzurow.Any(d => d.Data == nowaData);

            if (czyDwaDyzury)
            {
                wiadomosc = "Niedodano dyżuru. Ta osoba już ma przypisany dyżur tego dnia";
                return false;
            }

            // jedna osoba może mieć max. 10 dyżurów w miesiącu
            int ileDyzurow = ListaDyzurow.Where(d => d.Data.Year == nowaData.Year && d.Data.Month == nowaData.Month).Count();
            
            if (ileDyzurow >= 10)
            {
                wiadomosc = "Niedodano dyżuru. Jedna osoba może mieć max. 10 dyżurów w miesiącu!";
                return false;
            }

            // dyżury jednej osoby nie mogą występować dzień po dniu
            bool czyDzienPoDniu = ListaDyzurow.Any(d => nowaData == d.Data.AddDays(-1) || nowaData == d.Data.AddDays(1));

            if (czyDzienPoDniu)
            {
                wiadomosc = "Niedodano dyżuru. Dyżury jednej osoby nie mogą występować dzień po dniu!";
                return false;
            }

            wiadomosc = null;
            ListaDyzurow.Add(new Dyzur(nowaData));
            return true;
        }

        public void WypiszDyzury()
        {
            foreach (var dyzur in ListaDyzurow)
            {
                Console.WriteLine(dyzur);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
