using System;
using System.Collections.Generic;
using System.Text;

namespace OkulYonetimUygulamasi_G019
{
    class Adres
    {
        public string Sehir;
        public string Semt;
        public string Mahalle;
        
        public Adres(string sehir, string semt, string mahalle)
        {
            this.Sehir = sehir;
            this.Semt = semt;
            this.Mahalle = mahalle;
        }
    }
}
