using System;
using System.Collections.Generic;
using System.Text;

namespace OkulYonetimUygulamasi_G019
{
    class AracGerecler
    {
        public static string IlkHarfBuyut(string veri)
        {
            if (veri.Length > 0)
            {
                veri = veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
            }
            return veri;
        }
    }
}
