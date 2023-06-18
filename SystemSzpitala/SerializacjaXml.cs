using BibliotekaKlas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SystemSzpitala.Models;

namespace SystemSzpitala
{
    public static class SerializacjaXml
    {
        const string nazwaPliku = "data.xml";
        static Type[] typy = new Type[] { typeof(Administrator), typeof(Pielegniarka), typeof(Lekarz) };
        static XmlSerializer xml = new XmlSerializer(typeof(List<Uzytkownik>), typy);

        public static void Serializacja()
        {
            using (Stream fs = new FileStream(nazwaPliku, FileMode.Create, FileAccess.Write))
            {
                xml.Serialize(fs, Uzytkownicy.ListaUzytkownikow);
            }
        }

        public static void Deserializacja()
        {
            List<Uzytkownik> uzytkownicy;

            if (File.Exists(nazwaPliku))
            {
                using (Stream fs = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read))
                {
                    uzytkownicy = (List<Uzytkownik>)xml.Deserialize(fs);
                }
            }
            else
                uzytkownicy = new List<Uzytkownik>() { new Administrator("x", "x", "0000000000", "admin", "12345") };

            Uzytkownicy.ListaUzytkownikow = uzytkownicy;
        }
    }
}
