using System;
using System.Collections.Generic;
using System.Text;

namespace LAB4
{
    public class SlikovniOglas : Oglas
    {
        private string slika;
        public SlikovniOglas(string naslov, string opis, string autor, string slika)
        :base(naslov, opis, autor)
        {
            if (!slika.EndsWith(".png"))
                throw new Exception(
                    "URL videa mora završavati s .png");
            this.slika = slika;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"Slika: {slika}";
        }
    }
}
