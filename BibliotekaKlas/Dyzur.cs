using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibliotekaKlas
{
    public class Dyzur
    {
        public DateTime Data { get; set; }

        public Dyzur(DateTime data)
        {
            Data = data;
        }

        public Dyzur() { }

        public override string ToString()
        {
            return $"{Data:dd MMMM yyyy}";
        }
    }
}
