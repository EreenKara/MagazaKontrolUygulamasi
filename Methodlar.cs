/*****************************************************************************************************
**					                 SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				       NESNEYE DAYALI PROGRAMLAMA DERSİ 2021-2012 BAHAR DÖNEMİ
**					
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: Eren Kara
**				ÖĞRENCİ NUMARASI.......: B211210031
**              DERSİN ALINDIĞI GRUP...: 1-B
**
****************************************************************************************************/





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ProjeOdevi2.Donem
{
    public static class Methodlar
    {

        static string dosya_yolu_siparis = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\siparis.txt";
        static string dosya_yolu_stok = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\stok.txt";
        static string dosya_yolu_gider = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\gider.txt";
        static string dosya_yolu_gelir = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\gelir.txt";
        static string dosya_yolu_KarZarar = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\kar_zarar.txt";

        static string tarih = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        public static bool Bosmu(string yazi)
        {
            if (yazi == "" || yazi == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        } // Bos mu kontrol ediyor
        public static bool Harfmi(string yazi)
        {
            for (int i = 0; i < yazi.Length; i++)
            {
                if (!(Char.IsLetter(yazi[i])) && yazi[i] != 32)
                {
                    return false;
                }
            }
            return true;
        } // Harf mi kontrol ediyor
        public static bool Sayimi(string yazi)
        {
            foreach (char ch in yazi)
            {
                if (!(Char.IsDigit(ch)))
                {
                    return false;
                }
            }
            return true;

        } // Sayi mi kontrol ediyor
        public static bool Emailmi(string email)
        {
            if (!(email.Contains("@gmail.com") || email.Contains("@hotmail.com") || email.Contains("@outlook.com")))
            {
                return false;
            }

            return true;

        }  // Email mi kontrol ediyor
        public static bool urun_kodu(string urunKodu)
        {
            if (urunKodu[0] == 35)
            {
                return true;
            }
            else
            {
                return false;
            }
        } // Urun kodu mu kontrol ediyor
        public static int text_uzunlugu(string dosya_yolu)
        {
            string[] satirlar = File.ReadAllLines(dosya_yolu);
            return satirlar.Length;
        } // Text'in satır uzunlugunu söylüyor.
        public static void Yazma(string dosya_yolu, string[] dizi)  // 0'dan text'e yazma işlemi yapıyor .
        {
            StreamWriter tedarikci = new StreamWriter(dosya_yolu, true);
            for (int i = 0; i < dizi.Length; i++)
            {
                tedarikci.Write(dizi[i]);
                tedarikci.Write("\\");
            }
            tedarikci.WriteLine("");
            tedarikci.Close();
        }


        public static void Eslesme(string[,] dizi_siparis, int siparis_uzunluk, string[,] dizi_stok, int stok_uzunluk)  // siparis ile stok'un verilerini eslestiriyor.
        {
            for (int i = 0; i < siparis_uzunluk; i++)
            {
                for (int k = 0; k < stok_uzunluk; k++)
                {
                    if (dizi_stok[k, 0] == dizi_siparis[i, 0])
                    {
                        dizi_siparis[i, 2] = dizi_stok[k, 1];
                        dizi_siparis[i, 3] = dizi_stok[k, 2];
                        dizi_siparis[i, 4] = dizi_stok[k, 3];
                        dizi_siparis[i, 5] = dizi_stok[k, 4];
                        dizi_siparis[i, 7] = dizi_stok[k, 6];

                    }
                }
            }
        }

        public static void DiziAktarma(string[,] dizi2D, string[] dizi1D)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < dizi1D.Length; j++)
                {
                    dizi1D[j] = dizi2D[i, j];
                }

            }
        }
        public static void Gelir_Gider(string[,] gelirler, int uzunluk, string[,] satislar)  // Gelir Gider hesaplatıyor
        {
            int gelir;
            for (int i = 0; i < uzunluk; i++)
            {
                if (gelirler[i, 1] == satislar[0, 9])
                {
                    gelir = Convert.ToInt32(gelirler[i, 0]);
                    gelir += Convert.ToInt32(satislar[0, 8]);
                    gelirler[i, 0] = Convert.ToString(gelir);

                }
                else
                {
                    string[] gelirler1D = new string[2];
                    gelir = Convert.ToInt32(satislar[0, 8]);
                    gelirler1D[0] = Convert.ToString(gelir);
                    gelirler1D[1] = tarih;
                    
                    
                    Yazma(dosya_yolu_gelir, gelirler1D);
                }

            }

        }


        public static void KarZarar(string[,]KarZarar,int uzunlukKarZarar, string[,] hesaplanacak,int uzunlukHesaplanacak,bool toplama)
        {
            int kar = 0;
            int hesap = 0;
            bool booll = false;
            for (int i = 0; i < uzunlukKarZarar; i++)
            {
                if (KarZarar[i, 1] == hesaplanacak[0, 9])
                {
                    if (toplama)
                    {
                        booll = true;
                        kar = Convert.ToInt32(KarZarar[i, 0]);
                        hesap = Convert.ToInt32(hesaplanacak[0, 8]);
                        KarZarar[i, 0] = Convert.ToString(kar + hesap);
                        Yazma_silerek(dosya_yolu_KarZarar, KarZarar, Methodlar.text_uzunlugu(dosya_yolu_KarZarar), 2);
                    }
                    else
                    {
                        booll = true;
                        kar = Convert.ToInt32(KarZarar[i, 0]);
                        hesap = Convert.ToInt32(hesaplanacak[0, 8]);
                        KarZarar[i, 0] = Convert.ToString(kar - hesap);
                        Yazma_silerek(dosya_yolu_KarZarar, KarZarar, Methodlar.text_uzunlugu(dosya_yolu_KarZarar), 2);
                    }

                }   
                

            }
            if(!(booll))
            {
                string[] dizi = new string[2];
                if (toplama)
                {
                    dizi[0] = hesaplanacak[0, 8];
                    dizi[1] = hesaplanacak[0, 9];
                    Yazma(dosya_yolu_KarZarar, dizi);
                }
                else
                {
                    kar = Convert.ToInt32(hesaplanacak[0, 8]);
                    kar = -kar;
                    dizi[0] = Convert.ToString(kar);
                    dizi[1] = hesaplanacak[0, 9];
                    Yazma(dosya_yolu_KarZarar, dizi);
                }
            }
        }


        public static void Yazma_silerek(string dosya_yolu, string[,] dizi, int length, int uzunluk)
        {
            StreamWriter tedarikci = new StreamWriter(dosya_yolu);


            for (int i = 0; i < length; i++)
            {
                for (int k = 0; k < uzunluk; k++)
                {
                    if (dizi[i, k] != "")
                    {
                        tedarikci.Write(dizi[i, k]);
                        tedarikci.Write("\\");
                    }
                    if (k == uzunluk - 1 && dizi[i, k] != "")
                    {
                        tedarikci.WriteLine("");
                    }
                }
            }

            //#1\mavi\kazak\m\erkek\depo\20\
            //er\er@hotmail.com\05380692857\Kazak\Mavi\

            tedarikci.Flush();
            tedarikci.Close();
        }

        public static void Guncelle(string dosya_yolu_stok, int stok_uzunluk, string urun_kodu, int kac_tane, ref string yazi, ref bool eslesme, bool toplama)
        {
            eslesme = false;
            string[,] dizi_stok = new string[stok_uzunluk, 8];
            Okuma(dosya_yolu_stok, dizi_stok);
            for (int i = 0; i < stok_uzunluk; i++)
            {
                if (dizi_stok[i, 0] == urun_kodu)
                {
                    eslesme = true;
                    int stok = Convert.ToInt32(dizi_stok[i, 7]);
                    int kalan;
                    if (toplama)
                    {
                        kalan = stok + kac_tane;
                    }
                    else
                    {
                        kalan = stok - kac_tane;
                    }

                    if (kalan >= 0)
                    {
                        dizi_stok[i, 7] = Convert.ToString(kalan);
                        yazi = "Güncellendi";
                    }
                    else
                    {
                        yazi = "Stokta yeteri kadar ürün yok";
                    }
                    break;
                }
            }
            if (eslesme)
                Yazma_silerek(dosya_yolu_stok, dizi_stok, stok_uzunluk, 8);
            else
            {
                if(toplama)
                {
                    yazi = "Yeni Ürün Olarak Eklendi";
                }
                else
                {
                    yazi = "Eşleşen ürün bulunamadı";
                }
                
            }
        }


        public static void Tarih_ekle(string[,] dizi, int dizi_uzunluk, int index)
        {
            string tarih = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            for (int i = 0; i < dizi_uzunluk; i++)
            {
                dizi[i, index] = tarih;
            }
        }


        public static void Okuma(string dosya_yolu, string[,] dizi)  // text'ten okuma
        {
            string istenilen = "\\";

            string[] satirlar = File.ReadAllLines(dosya_yolu);

            for (int i = 0; i < satirlar.Length; i++)
            {
                bool devammi = true;
                string satir = satirlar[i];
                for (int j = 0; devammi; j++)
                {
                    if (satir.Contains(istenilen))
                    {
                        int index = satir.IndexOf(istenilen);
                        dizi[i, j] = satir.Substring(0, index);
                        satir = satir.Remove(0, index + 1);
                    }
                    else
                    {
                        devammi = false;
                    }

                }
            }
        }

        




        //public static bool StokKontrol(int sayi)
        //{
        //    if (sayi < 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //}


        //public static void Eslesme_urun_kodu(string[,] dizi_stok,int dizi_stok_uzunluk,string[,] dizi_aktarılacak)
        //{

        //    for (int i = 0; i < dizi_stok_uzunluk; i++)
        //    {
        //        if (dizi_stok[i, 0] == dizi_aktarılacak[1,0])
        //        {
        //            dizi_aktarılacak[1, 2] = dizi_stok[i, 1];
        //            dizi_aktarılacak[1, 3] = dizi_stok[i, 2];
        //            dizi_aktarılacak[1, 4] = dizi_stok[i, 3];
        //            dizi_aktarılacak[1, 5] = dizi_stok[i, 4];


        //        }


        //    }


        //}


        //public static void Guncelle_siparis(string dosya_yolu_stok, int stok_uzunluk, string urun_kodu, int kac_tane, ref string yazi, ref bool eslesme)
        //{
        //    eslesme = false;
        //    string[,] dizi_stok = new string[stok_uzunluk, 7];
        //    Okuma(dosya_yolu_stok, dizi_stok);
        //    for (int i = 0; i < stok_uzunluk; i++)
        //    {
        //        if (dizi_stok[i, 0] == urun_kodu)
        //        {
        //            eslesme = true;
        //            int stok = Convert.ToInt32(dizi_stok[i, 6]);
        //            int kalan = stok + kac_tane;
        //            if (kalan >= 0)
        //            {
        //                dizi_stok[i, 6] = Convert.ToString(kalan);
        //                yazi = "Güncellendi";
        //            }
        //            break;
        //        }
        //    }
        //    if (eslesme)
        //        Yazma_silerek(dosya_yolu_stok, dizi_stok, stok_uzunluk, 7);
        //    else
        //    {
        //        yazi = "Eşleşen ürün bulunamadı. Yeni ürün eklendi";
        //    }
        //}



        //public static void Eslesme_ekleme(string[] dizi_ekleme,int dizi_uzunluk,string[,] dizi_stok, int stok_uzunluk)
        //{
        //    for (int i = 0; i < dizi_uzunluk; i++)
        //    {
        //        for (int k = 0; k < stok_uzunluk; k++)
        //        {
        //            if (dizi_stok[i, 0] == dizi_ekleme[k, 0])
        //            {

        //                dizi_ekleme[i, 2] = dizi_stok[i, 1];
        //                dizi_ekleme[i, 3] = dizi_stok[i, 2];
        //                dizi_ekleme[i, 4] = dizi_stok[i, 3];
        //                dizi_ekleme[i, 5] = dizi_stok[i, 4];

        //            }
        //        }

        //    }
        //}


        //public static bool isimmi(string ad_soyad)
        //{
        //    if (Bosmu(ad_soyad) || !(Harfmi(ad_soyad)))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


        //public static void Aktarma(string[,]dizi,string dosya_yolu)
        //{
        //    StreamWriter stw = new StreamWriter(dosya_yolu);



        //}


        //public static void Stoktan_silme(string dosya_yolu_stok, int stok_uzunluk, string dosya_yolu_kactane, string urun_kodu)
        //{
        //    string[,] dizi_stok = new string[10, 7];
        //    string[,] dizi = new string[10, 7];
        //    Okuma(dosya_yolu_stok, dizi_stok);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (dizi_stok[i, 0] == dizi[i, 0])
        //        {
        //            int kac_tane = Convert.ToInt32(dizi[i, 6]);
        //            int stok = Convert.ToInt32(dizi_stok[i, 6]);
        //            dizi_stok[i, 6] = Convert.ToString(stok - kac_tane);
        //        }
        //    }
        //    Yazma_silerek(dosya_yolu_stok, dizi_stok, 10, 7);
        //}






        //        string istenilen = textBox1.Text;
        //        int stok;
        //        int satis = Convert.ToInt32(numericUpDown1.Value);
        //        int kalan = 8;
        //        int i = 0;
        //                for (; i<listView1.Items.Count; i++)
        //                {
        //                    if (istenilen == listView1.Items[i].SubItems[0].Text)
        //                    {
        //                        stok = int.Parse(listView1.Items[i].SubItems[6].Text);
        //        kalan = stok - satis;

        //                    }
        //}
        //if (Methodlar.StokKontrol(kalan))
        //{
        //    listView1.Items[i - 1].SubItems[6].Text = Convert.ToString(kalan);
        //}



    }
}
