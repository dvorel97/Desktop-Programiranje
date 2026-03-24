
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LAB4
{
    public class Oglas
    {
        protected string naslov;
        protected string opis;
        protected string autor;
        protected DateTime datumObjave;

        public Oglas(string naslov, string opis, string autor)
        {
            this.naslov = naslov;
            this.opis = opis;
            this.autor = autor;
            this.datumObjave = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{naslov} ({datumObjave.Year}.)\n" + $"{ opis }\n";
        }
    }
}
