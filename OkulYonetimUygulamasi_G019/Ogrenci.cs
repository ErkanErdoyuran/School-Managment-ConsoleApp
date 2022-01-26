using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace OkulYonetimUygulamasi_G019
{
    class Ogrenci
    {
        public int No;
        public string Ad;
        public string Soyad;
        public DateTime DogumTarihi;
        public CINSIYET Cinsiyet;
        public SUBE Sube;
        public Adres Adres;
        public List<DersNotu> Notlar = new List<DersNotu>();
        public double Ortalama
        {
            get
            {
                if(Notlar.Count>0)
                {
                    return Notlar.Average(a => a.Not);
                }
                else
                {
                    return 0;
                }
            }
        }
        public string Aciklama;
        public List<string> Kitaplar = new List<string>();
        public Ogrenci(int no, string ad, string soyAd, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            this.No = no;
            this.Ad = ad;
            this.Soyad = soyAd;
            this.DogumTarihi = dogumTarihi;
            this.Cinsiyet = cinsiyet;
            this.Sube = sube;
        }
    }

    public enum SUBE
    {
        Empty,
        A,
        B,
        C
    }

    public enum CINSIYET
    {
        Empty,
        Kiz,
        Erkek
    }
    public enum Dersler
    {
        Fen, Matematik, Sosyal, Turkce
    }

}
