using System;
using System.Collections.Generic;
using System.Globalization;

namespace OkulYonetimUygulamasi_G019
{
    class Program
    {

        static Okul Okulumuz = new Okul();
        //Bu classtan sadece okul classına erişelim,
        //Bu class'ın Ogrenci class'ından haberi olmasın.
        static void Main(string[] args)
        {
            SahteVeriGir();
            Uygulama();
        }
        static void Uygulama()
        {
            Menu();
            string secim;
            while (true)
            {
                secim = SecimAl();
                switch (secim)
                {
                    case "1":
                        OgrenciEkle();
                        break;
                    case "2":
                        NotEkle();
                        break;
                    case "3":
                        OrtalamaGor();
                        break;
                    case "4":
                        AdresGir();
                        break;
                    case "5":
                        TumOgrencileriListele();
                        break;
                    case "6":
                        SubeyeGoreOgrenciListele();
                        break;
                    case "7":
                        NotlariYazdir();
                        break;
                    case "8":
                        SinifinNotOrtalamasi();
                        break;
                    case "9":
                        CinsiyeteGoreOgrencilistele();
                        break;
                    case "10":
                        TariheGoreOgrenciListele();
                        break;
                    case "11":
                        SemtlereGoreListele();
                        break;
                    case "12":
                        OkuldakiEnBasarili5OgrenciListele();
                        break;
                    case "13":
                        OkuldakiEnBasarisiz3OgrenciListele();
                        break;
                    case "14":
                        SiniftakiEnBasarili5OgrenciListele();
                        break;
                    case "15":
                        SiniftakiEnBasarisiz3OgrenciListele();
                        break;
                    case "16":
                        AciklamaGir();
                        break;
                    case "17":
                        AciklamaGor();
                        break;
                    case "18":
                        KitapEkle();
                        break;
                    case "19":
                        KitapListele();
                        break;
                    case "20":
                        SonKitapListele();
                        break;
                    case "21":
                        OgrenciSil();
                        break;
                    case "22":
                        OgrenciGuncelle();
                        break;
                    case "cikis":
                    case "çıkış":
                        Environment.Exit(0);
                        break;
                    case "liste":
                        Menu();
                        break;
                }
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazınız.");
            }
        }
        static void Menu()
        {
            Console.WriteLine("------  Öğrenci Yönetim Sistemi  ------");
            Console.WriteLine("1- Öğrenci Gir");
            Console.WriteLine("2- Not Gir");
            Console.WriteLine("3- Öğrencinin ortalamasını gör");
            Console.WriteLine("4- Öğrencinin adresini gir");
            Console.WriteLine("5- Bütün öğrencileri listele");
            Console.WriteLine("6- Şubeye göre öğrencileri listele");
            Console.WriteLine("7- Öğrencinin notlarını görüntüle");
            Console.WriteLine("8- Sınıfın not ortalamsını gör");
            Console.WriteLine("9- Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("10- Şu tarihten sonra doğan örencileri listele");
            Console.WriteLine("11- Tüm öğrencileri semtlerine göre sıralayarak listele");
            Console.WriteLine("12- Okuldaki en başarılı 5 öğrenciyi listele");
            Console.WriteLine("13- Okuldaki en başarısız 3 öğrenciyi listele");
            Console.WriteLine("14- Sınıftaki en başarılı 5 öğrenciyi listele");
            Console.WriteLine("15- Sınıftaki en başarısız 3 öğrenciyi listele");
            Console.WriteLine("16- Öğrencinin açıklamasını gir");
            Console.WriteLine("17- Öğrencinin açıklamasını gör");
            Console.WriteLine("18- Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("19- Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("20- Öğrencinin okuduğu son kitabı görüntüle");
            Console.WriteLine("21- Öğrenci Sil");
            Console.WriteLine("22- Öğrenci güncelle");

            Console.WriteLine("\nÇıkış yapmak için \"çıkış\" yazıp \"enter\"a basın");
        }
        static string SecimAl()
        {
            while (true)
            {
                Console.Write("Yapmak istediğiniz işlemi seçin: ");
                string secim = Console.ReadLine();
                int secimRakam = 0;
                int.TryParse(secim, out secimRakam);
                if (secim.ToLower() == "çıkış" || secim.ToLower() == "liste" || (secimRakam > 0 && secimRakam < 23))
                {
                    return secim;
                }
                else
                {
                    Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.\nMenüyü tekrar listelemek için \"liste\", çıkış yapmak için" +
                        "\"çıkış\" yazın.");
                }
            }
        }
        static void NotEkle()
        {
            Console.WriteLine("2 - Not Gir------------------------------------------------ -");
            int no;
            while (true)
            {
                no = SayiAl("Öğrencinin numarası: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    Console.WriteLine("Ogrencinin adi soyadi: " + Okulumuz.OgrenciBul(no));
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Bu numaraya ait öğrenci yok");
                }
            }
            Dersler ders = DersSec();
            int adet = SayiAl("Eklemek istediğiniz not adedi: ");
            for (int i = 1; i <= adet; i++)
            {
                int not = SayiAl(i + ".Notu girin: ");

                if (not > 100 || not < 0)
                {
                    Console.WriteLine("Girdiğiniz değer 0 ve 100 arasında olmalıdır.");
                    i--;
                }
                else
                {
                    Okulumuz.NotEkle(no, ders, not);
                }
            }
            Console.WriteLine("Bilgiler sisteme girilmiştir.");
        }
        static void SahteVeriGir()
        {
            Okulumuz.OgrenciEkle(12, "Ayşe", "Batı", new DateTime(2000, 5, 4), CINSIYET.Kiz, SUBE.B);
            Okulumuz.OgrenciEkle(65, "Berkan", "Güven", new DateTime(2000, 9, 4), CINSIYET.Erkek, SUBE.A);
            Okulumuz.OgrenciEkle(23, "Ceylan", "Yılmaz", new DateTime(2000, 5, 3), CINSIYET.Kiz, SUBE.C);
            Okulumuz.OgrenciEkle(90, "Deniz", "Gezmiş", new DateTime(2000, 9, 4), CINSIYET.Erkek, SUBE.B);
        }
        static string StringAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                string veri = Console.ReadLine();
                veri = veri.ToUpper();
                bool kontrol = true;
                if (veri.Length > 1)
                {
                    string karakterler = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
                    foreach (char item in veri)
                    {
                        if (!karakterler.Contains(item.ToString().ToUpper()))
                        {
                            Console.WriteLine("Hatalı giriş");
                            kontrol = false;
                            break;
                        }
                    }
                    if (kontrol)
                    {
                        return veri;
                    }
                }
            }

        }
        static void OgrenciEkle()
        {
            Console.WriteLine("1- Öğrenci Ekle ------------------------------------------------");
            int numara = SayiAl("Ogrencinin numarası: ");
            if (Okulumuz.OgrenciVarMi(numara))
            {
                numara = Okulumuz.NumaraAta();
            }
            string ad = StringAl("Ogrencinin adı: ");
            ad = AracGerecler.IlkHarfBuyut(ad);
            string soyAd = StringAl("Ogrencinin soyadı: ");
            soyAd = AracGerecler.IlkHarfBuyut(soyAd);
            DateTime dogumTarihi = TarihAl("Ogrencinin dogum tarihi: ");
            CINSIYET cinsiyet = CinsiyetAL("Ogrencinin cinsiyeti: ");
            SUBE sube = SubeAl("Ogrencinin subesi: ");
            Okulumuz.OgrenciEkle(numara, ad, soyAd, dogumTarihi, cinsiyet, sube);
            Console.WriteLine(numara + " numaralı öğrenci başarılı bir şekilde eklenmiştir");
        }
        static SUBE SubeAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        return SUBE.A;
                    case "B":
                        return SUBE.B;
                    case "C":
                        return SUBE.C;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin");
                        break;
                }
            }
        }
        static int SayiAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                int numara = 0;
                if (!int.TryParse(Console.ReadLine(), out numara))
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Lütfen tekrar deneyin.");
                }
                else
                {
                    return numara;
                }
            }
        }
        static DateTime TarihAl(string mesaj)
        {
            DateTime result;
            while (true)
            {
                Console.Write(mesaj);
                if (!DateTime.TryParse(Console.ReadLine(), out result))
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                else
                    return result;
            }
        }
        static CINSIYET CinsiyetAL(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                switch (Console.ReadLine().ToUpper())
                {
                    case "E":
                        return CINSIYET.Erkek;
                    case "K":
                        return CINSIYET.Kiz;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin");
                        break;
                }
            }
        }
        static Dersler DersSec()
        {
            Console.WriteLine("------------ Eklenebilecek Dersler ------------ ");
            Console.WriteLine("- Fen için 1");
            Console.WriteLine("- Matematik için 2");
            Console.WriteLine("- Sosyal için 3");
            Console.WriteLine("- Türkçe için 4");
            while (true)
            {
                Console.Write("Ders: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        return Dersler.Fen;
                    case "2":
                        return Dersler.Matematik;
                    case "3":
                        return Dersler.Sosyal;
                    case "4":
                        return Dersler.Turkce;
                    default:
                        Console.WriteLine("Hatalı giriş yapıldı. Lütfen 4 ders arasından seçim yapın.");
                        break;
                }
            }
        }
        static void OrtalamaGor()
        {
            Console.WriteLine("3- Öğrencinin not ortalamasını gör ----------------------");
            int no;
            while (true)
            {
                no = SayiAl("Öğrencinin numarası: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    Console.WriteLine("Ogrencinin adi soyadi: " + Okulumuz.OgrenciBul(no));
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Bu numaraya ait öğrenci yok");
                }
            }
            double ortalama = Okulumuz.OgrenciOrtalamasi(no);
            Console.WriteLine("Öğrencinin not ortalaması: " + ortalama);
        }
        static void TumOgrencileriListele()
        {
            Console.WriteLine("5- Bütün öğrencileri listele ".PadRight(50, '-'));
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.OgrenciListele();
        }
        static void SubeyeGoreOgrenciListele()
        {
            Console.WriteLine("6- Şubeye göre öğrenci listele".PadRight(30, '-'));
            SUBE sube;
            while (true)
            {
                sube = SubeAl("Listelemek istediğiniz şubeyi girin(A/B/C): ");
                Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
                Console.WriteLine("".PadRight(80, '-'));
                Okulumuz.OgrenciListele(sube);
                break;
            }
        }
        static void SinifinNotOrtalamasi()
        {
            Console.WriteLine("8- Sınıfın not ortalamsını gör".PadRight(30, '-'));
            SUBE sube = SubeAl("Bir şube seçin(A/B/C): ");
            double ortalama = Okulumuz.NotOrtalamasi(sube);
            Console.WriteLine("Sınıfın not ortalaması: " + ortalama);
        }
        static void CinsiyeteGoreOgrencilistele()
        {
            Console.WriteLine("9- Cinsiyete göre öğrenci listele".PadRight(30, '-'));
            CINSIYET cinsiyet;
            while (true)
            {
                cinsiyet = CinsiyetAL("Listelemek istediğiniz cinsiyeti girin (E/K): ");
                Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
                Console.WriteLine("".PadRight(80, '-'));
                Okulumuz.OgrenciListele(cinsiyet);
                break;
            }
        }
        static void NotlariYazdir()
        {
            Console.WriteLine("7- Öğrencinin notlarını görüntüle".PadRight(50, '-'));
            int no;
            while (true)
            {
                no = SayiAl("Öğrencinin numarası: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    Console.WriteLine("Ogrencinin adi soyadi: " + Okulumuz.OgrenciBul(no));
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Bu numaraya ait öğrenci yok");
                }
            }
            Console.WriteLine("Dersin Adı".PadRight(15) + "Notu".PadRight(15));
            Console.WriteLine("".PadRight(50, '-'));
            Okulumuz.NotlariYazdir(no);
        }
        static void TariheGoreOgrenciListele()
        {
            Console.WriteLine("10- Şu tarihten sonra doğan örencileri listele".PadRight(65, '-'));
            DateTime dogumTarihi = TarihAl("Hangi tarihten sonraki öğrencileri listelemek istersin: ");
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.OgrenciListele(dogumTarihi);
        }
        static void OkuldakiEnBasarili5OgrenciListele()
        {
            Console.WriteLine("12- Okuldaki en başarılı 5 öğrenciyi listele".PadRight(65, '-'));
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.OkuldakiEnBasarili5Ogrenci();
        }
        static void OkuldakiEnBasarisiz3OgrenciListele()
        {
            Console.WriteLine("13- Okuldaki en başarısız 3 öğrenciyi listele".PadRight(65, '-'));
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.OkuldakiEnBasarisiz3Ogrenci();
        }
        static void SiniftakiEnBasarili5OgrenciListele()
        {
            Console.WriteLine("14- Sınıftaki en başarılı 5 öğrenciyi listele".PadRight(65, '-'));
            SUBE sube = SubeAl("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.SiniftakiEnBasarili5Ogrenci(sube);
        }
        static void SiniftakiEnBasarisiz3OgrenciListele()
        {
            Console.WriteLine("15- Sınıftaki en başarısız 3 öğrenciyi listele".PadRight(65, '-'));
            SUBE sube = SubeAl("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.SiniftakiEnBasarisiz3Ogrenci(sube);
        }
        static void AciklamaGir()
        {
            Console.WriteLine("16- Açıklama Gir".PadRight(65, '-'));
            int no = SayiAl("Öğrenci no giriniz: ");
            Okulumuz.AciklamaGir(no);
        }
        static void AciklamaGor()
        {
            Console.WriteLine("17- Açıklama Gör".PadRight(65, '-'));
            int no = SayiAl("Öğrenci no giriniz: ");
            Okulumuz.AciklamaGor(no);
        }
        static void KitapEkle()
        {
            Console.WriteLine("18- Öğrencinin okuduğu kitabı gir".PadRight(65, '-'));
            int no;
            while (true)
            {
                no = SayiAl("Öğrencinin numarası: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    Console.WriteLine("Ogrencinin adi soyadi: " + Okulumuz.OgrenciBul(no));
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Bu numaraya ait öğrenci yok");
                }
            }
            Console.Write("Eklenecek Kitap Adı: ");
            string kitapAdi = Console.ReadLine();
            kitapAdi = AracGerecler.IlkHarfBuyut(kitapAdi);
            Okulumuz.KitapEkle(no, kitapAdi);
        }
        static void KitapListele()
        {
            Console.WriteLine("19- Öğrencinin okuduğu kitapları listele".PadRight(65, '-'));
            int no = SayiAl("Öğrenci no giriniz: ");
            Console.WriteLine("Okuduğu kitaplar".PadRight(25));
            Console.WriteLine("".PadRight(25, '-'));
            Okulumuz.KitapListele(no);
        }
        static void SonKitapListele()
        {
            Console.WriteLine("20- Öğrencinin okuduğu son kitabı görüntüle".PadRight(65, '-'));
            int no = SayiAl("Öğrenci no giriniz: ");
            Okulumuz.SonKitapGetir(no);
        }
        static void OgrenciSil()
        {
            Console.WriteLine("21- Öğrenci Sil".PadRight(65, '-'));
            int no = SayiAl("Öğrenci no giriniz: ");
            if (Okulumuz.OgrenciVarMi(no))
            {
                Okulumuz.OgrenciSil(no);
            }
        }
        static void OgrenciGuncelle()
        {
            while (true)
            {
                Console.WriteLine("22- Öğrenci Güncelle".PadRight(65, '-'));
                int no = SayiAl("Öğrenci no giriniz: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    string ad = StringAl("Öğrencinin Adı: ");
                    if (ad != "")
                    {
                        Okulumuz.IsimGuncelle(no, ad);
                    }
                    Console.Write("Öğrencinin Soyadı: ");
                    string soyad = StringAl("Öğrencinin Adı: ");
                    if (soyad != "")
                    {
                        Okulumuz.SoyIsimGuncelle(no, soyad);
                    }
                    DateTime dogumTarihi;
                    while (true)
                    {
                        Console.Write("Öğrencinin Dogum Tarihi: ");
                        string giris = Console.ReadLine();
                        if (giris != "")
                        {
                            if (!DateTime.TryParse(giris, out dogumTarihi))
                            {
                                Console.WriteLine("Hatalı giriş yapıldı tekrar deneyin");
                            }
                            else
                            {
                                Okulumuz.TarihGuncelle(no, dogumTarihi);
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    CINSIYET cinsiyet = CinsiyetAL("Ogrencinin cinsiyeti: ");
                    Okulumuz.CinsiyetGuncelle(no, cinsiyet);
                    SUBE sube = SubeAl("Öğrencinin şubesi: ");
                    Okulumuz.SubeGuncelle(no, sube);
                    Console.WriteLine("Öğrenci başarılı bir şekilde güncellendi.");
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numaraya ait öğrenci bulunamadı");
                }
            }
        }
        private static void AdresGir()
        {
            Console.WriteLine("4- Öğrencinin adresini gir".PadRight(50, '-'));
            int no;
            while (true)
            {
                no = SayiAl("Öğrencinin numarası: ");
                if (Okulumuz.OgrenciVarMi(no))
                {
                    Console.WriteLine("Ogrencinin adi soyadi: " + Okulumuz.OgrenciBul(no));
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Bu numaraya ait öğrenci yok");
                }
            }
            string il = StringAl("İl: ");
            string ilce = StringAl("İlce: ");
            string mahalle = StringAl("Mahalle: ");
            Okulumuz.AdresEkle(no, il, ilce, mahalle);
            Console.WriteLine("Adres başarılı bir şekilde eklendi");
        }
        private static void SemtlereGoreListele()
        {
            Console.WriteLine("11- Semtlerine göre listele ".PadRight(50, '-'));
            Console.WriteLine("Sube".PadRight(15) + "No".PadRight(15) + "Adı Soyadı".PadRight(25) + "Şehir".PadRight(15) + "Semt");
            Console.WriteLine("".PadRight(80, '-'));
            Okulumuz.SemteGoreListele();
        }
    }
}
