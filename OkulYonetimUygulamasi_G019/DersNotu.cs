using System;
using System.Collections.Generic;
using System.Text;

namespace OkulYonetimUygulamasi_G019
{
    class DersNotu
    {
        public Dersler DersAdi;
        public int Not;

        public DersNotu(Dersler dersAdi, int not)
        {
            this.DersAdi = dersAdi;
            this.Not = not;
        }

    }
}
