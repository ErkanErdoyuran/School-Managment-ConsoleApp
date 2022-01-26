using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkulYonetimUygulamasi_G019
{
    class Okul
    {

        List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void NotEkle(int no, Dersler ders, int not)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            DersNotu dn = new DersNotu(ders, not);

            o.Notlar.Add(dn);
        }
        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            Ogrenciler.Add(new Ogrenci(no, ad, soyad, dogumTarihi, cinsiyet, sube));
        }
        public string OgrenciBul(int no)
        {
            return Ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + Ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad + "\nÖğrencinin şubesi: " +
                Ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube;
        }
        internal bool OgrenciVarMi(int no)
        {
            bool kontrol = Ogrenciler.Where(a => a.No == no).ToList().Count > 0 ? true : false;
            return kontrol;
        }
        public double OgrenciOrtalamasi(int no)
        {
            return Ogrenciler.Where(a => a.No == no).FirstOrDefault().Ortalama;
        }
        public int NumaraAta()
        {
            return Ogrenciler.Last().No + 1;
        }
        public void OgrenciListele()
        {
            foreach (Ogrenci item in Ogrenciler)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void OgrenciListele(SUBE sube)
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.Sube == sube))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void OgrenciListele(CINSIYET cinsiyet)
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.Cinsiyet == cinsiyet))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void OgrenciListele(DateTime dogumTarihi)
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.DogumTarihi > dogumTarihi))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public double NotOrtalamasi(SUBE sube)
        {
            return Ogrenciler.Where(a => a.Sube == sube).Average(a => a.Ortalama);
        }
        public void NotlariYazdir(int no)
        {
            foreach (Ogrenci item in Ogrenciler)
            {
                for (int i = 0; i < item.Notlar.Count; i++)
                {
                    Console.WriteLine(item.Notlar[i].DersAdi.ToString().PadRight(15) + item.Notlar[i].Not.ToString().PadRight(15));
                }
            }
        }
        public void OkuldakiEnBasarili5Ogrenci()
        {
            foreach (Ogrenci item in Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void OkuldakiEnBasarisiz3Ogrenci()
        {
            foreach (Ogrenci item in Ogrenciler.OrderBy(a => a.Ortalama).Take(3))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void SiniftakiEnBasarili5Ogrenci(SUBE sube)
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.Sube == sube).OrderByDescending(a => a.Ortalama).Take(3))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void SiniftakiEnBasarisiz3Ogrenci(SUBE sube)
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.Sube == sube).OrderBy(a => a.Ortalama).Take(3))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count.ToString().PadRight(15));
            }
        }
        public void AciklamaGir(int no)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            Console.Write("Açıklama: ");
            o.Aciklama = Console.ReadLine();
            Console.WriteLine("Açıklama başarılı bir şekilde eklendi.");
        }
        public void AciklamaGor(int no)
        {
            Console.WriteLine("Acıklama: " + AracGerecler.IlkHarfBuyut(Ogrenciler.Where(a => a.No == no).FirstOrDefault().Aciklama));
        }
        public void KitapEkle(int no, string kitapAdi)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.Kitaplar.Add(kitapAdi);
            Console.WriteLine("Okunan kitap başarılı bir şekilde eklendi.");
        }
        public void KitapListele(int no)
        {
            foreach (string item in Ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar)
            {
                Console.WriteLine(item);
            }
        }
        public void SonKitapGetir(int no)
        {
            if (Ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar.Count > 0)
            {
                Console.WriteLine("Okunan son kitabın adı: " + Ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar.Last());
            }
        }
        public void OgrenciSil(int no)
        {
            Ogrenciler.Remove(Ogrenciler.Where(a => a.No == no).FirstOrDefault());
            Console.WriteLine("Öğrenci Silindi");
        }
        public void IsimGuncelle(int no, string ad)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.Ad = ad;
        }
        public void SoyIsimGuncelle(int no, string soyad)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.Soyad = soyad;
        }
        public void TarihGuncelle(int no, DateTime dogumTarihi)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.DogumTarihi = dogumTarihi;
        }
        public void CinsiyetGuncelle(int no, CINSIYET cinsiyet)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.Cinsiyet = cinsiyet;
        }
        public void SubeGuncelle(int no, SUBE sube)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            o.Sube = sube;
        }
        public void AdresEkle(int no, string il, string ilce, string mahalle)
        {
            Ogrenci o = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            Adres adres = new Adres(il, ilce, mahalle);
            o.Adres = adres;
        }
        public void SemteGoreListele()
        {
            foreach (Ogrenci item in Ogrenciler.Where(a => a.Adres != null).OrderBy(a => a.Adres.Semt))
            {
                Console.WriteLine(item.Sube.ToString().PadRight(15) + item.No.ToString().PadRight(15) + (item.Ad.ToString() + " " + item.Soyad.ToString()).PadRight(25) + item.Adres.Sehir.ToString().PadRight(15) + item.Adres.Semt.ToString().PadRight(15));
            }
        }
    }
}
