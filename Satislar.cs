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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjeOdevi2.Donem
{
    public partial class Satislar : Form
    {

        string dosya_yolu = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\satis.txt";
        string dosya_yolu_stok = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\stok.txt";
        string dosya_yolu_gider = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\gider.txt";
        string dosya_yolu_gelir = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\gelir.txt";
        string dosya_yolu_siparis = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\siparis.txt";
        string dosya_yolu_KarZarar = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\kar_zarar.txt";

        string tarih = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        public Satislar()
        {
            InitializeComponent();
            listView1.Columns.Add("Ürün Kodu", 100); //1
            listView1.Columns.Add("Müşteri", 130);  //2
            listView1.Columns.Add("Markası", 100);  //3
            listView1.Columns.Add("Çeşidi ", 100);  //4
            listView1.Columns.Add("Bedeni", 80);  //5
            listView1.Columns.Add("Cinsiyeti", 100);  //6
            listView1.Columns.Add("Kaç tane", 100);  //7
            listView1.Columns.Add("Fiyat", 100);  //8
            listView1.Columns.Add("Satış Fiyatı", 100);  //9
            listView1.Columns.Add("Tarih", 120);  //10


        }

        private void Satislar_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int dizi_stok_uzunluk = Methodlar.text_uzunlugu(dosya_yolu_stok);
            string[,] dizi_stok = new string[Methodlar.text_uzunlugu(dosya_yolu_stok), 8];
            string[,] dizi = new string[Methodlar.text_uzunlugu(dosya_yolu), 10];  // sotkatn ürün koduna göre yaızlıarı oku
            int dizi_uzunluk = Methodlar.text_uzunlugu(dosya_yolu);

            string[] dizi2 = new string[10];

            Methodlar.Okuma(dosya_yolu_stok, dizi_stok);
            Methodlar.Okuma(dosya_yolu, dizi);

            Methodlar.Eslesme(dizi, dizi_uzunluk, dizi_stok, dizi_stok_uzunluk);
            //Methodlar.Tarih_ekle(dizi, dizi_uzunluk - 1, 9);
            //Methodlar.Yazma_silerek(dosya_yolu, dizi, dizi_uzunluk, 10);
            //Methodlar.Okuma(dosya_yolu, dizi);


            dizi_aktarma(dizi, dizi2);

        }
        public void liste_aktarma(string[] dizi)
        {
            ListViewItem item = new ListViewItem(dizi);
            listView1.Items.Add(item);

        }
        public void dizi_aktarma(string[,] dizi, string[] dizi2)
        {
            for (int i = 0; i < Methodlar.text_uzunlugu(dosya_yolu); i++)
            {
                for (int j = 0; j < dizi2.Length; j++)
                {
                    dizi2[j] = dizi[i, j];
                }
                liste_aktarma(dizi2);
            }
        }
        public void dizi_aktarma2(string[,] dizi, string[] dizi2)
        {
            for (int j = 0; j < dizi2.Length; j++)
            {
                dizi2[j] = dizi[0, j];
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Methodlar.Bosmu(textBox1.Text))
            {
                MessageBox.Show("Lütfen Ürün Kodunu Doldurunuz");
            }
            else if (!(Methodlar.urun_kodu(textBox1.Text)))
            {
                MessageBox.Show("Lütfen Geçerli Bir Ürün Kodu Giriniz");
            }
            else if (!(textBox2.Text.Length == 11) || !(Methodlar.Sayimi(textBox2.Text)))
            {
                MessageBox.Show("Lütfen Geçerli bir TC Giriniz");
            }
            else if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir satış adedi giriniz");
            }
            else
            {
                int dizi_stok_uzunluk = Methodlar.text_uzunlugu(dosya_yolu_stok);
                string[,] dizi_stok = new string[Methodlar.text_uzunlugu(dosya_yolu_stok), 8];
                bool guncellendimi = false;
                Methodlar.Okuma(dosya_yolu_stok, dizi_stok);
                string urun_kodu = textBox1.Text;
                int kac_tane = Convert.ToInt32(numericUpDown1.Value);
                string uyari = "";
                bool toplama = false;
                Methodlar.Guncelle(dosya_yolu_stok, dizi_stok_uzunluk, urun_kodu, kac_tane, ref uyari, ref guncellendimi, toplama);


                if (guncellendimi)
                {

                    Methodlar.Okuma(dosya_yolu_stok, dizi_stok);
                    string[,] dizi = new string[1, 10];
                    string[,] diziGelir = new string[Methodlar.text_uzunlugu(dosya_yolu_gelir), 2];
                    string[,] diziKarZarar2D = new string[Methodlar.text_uzunlugu(dosya_yolu_KarZarar), 2];
                    Methodlar.Okuma(dosya_yolu_gelir, diziGelir);
                    Methodlar.Okuma(dosya_yolu_KarZarar, diziKarZarar2D);


                    dizi[0, 0] = textBox1.Text;
                    dizi[0, 1] = textBox2.Text;

                    dizi[0, 6] = Convert.ToString(numericUpDown1.Value);
                    int kacTane = Convert.ToInt32(numericUpDown1.Value);


                    Methodlar.Eslesme(dizi, 1, dizi_stok, dizi_stok_uzunluk);
                    int Fiyat = Convert.ToInt32(dizi[0, 7]);
                    dizi[0, 8] = Convert.ToString(kacTane * Fiyat);

                    string[] dizi2 = new string[10];

                    Methodlar.Tarih_ekle(dizi, 1, 9);

                    Methodlar.Gelir_Gider(diziGelir, Methodlar.text_uzunlugu(dosya_yolu_gelir), dizi);
                    Methodlar.Yazma_silerek(dosya_yolu_gelir, diziGelir, Methodlar.text_uzunlugu(dosya_yolu_gelir), 2);
                    Methodlar.KarZarar(diziKarZarar2D, Methodlar.text_uzunlugu(dosya_yolu_KarZarar), dizi, Methodlar.text_uzunlugu(dosya_yolu), true);


                    dizi_aktarma2(dizi, dizi2);
                    liste_aktarma(dizi2);

                    Methodlar.Yazma(dosya_yolu, dizi2);
                    MessageBox.Show(uyari);
                }
                else
                {
                    MessageBox.Show(uyari);
                }

            }
        }

        //public void dizi_aktarma3(string[,] dizi, string[] dizi2)
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        for (int j = 0; j < dizi2.Length; j++)
        //        {
        //            dizi2[j] = dizi[i, j];
        //        }
        //        liste_aktarma(dizi2);
        //    }
        //}

    }
}
