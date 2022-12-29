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
    public partial class Kar_Zarar : Form
    {
        string dosya_yolu_gider= @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\gider.txt";
        string dosya_yolu_gelir = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\kar_zarar.txt";
        string dosya_yolu_stok= @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\stok.txt";
        string dosya_yolu_satis = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\satis.txt";
        string dosya_yolu_siparis= @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\siparis.txt";
        string dosya_yolu_KarZarar= @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\kar_zarar.txt";
        


        public Kar_Zarar()
        {
            InitializeComponent();

            listView1.Columns.Add("Giderin Tutarı", 156);
            listView1.Columns.Add("Tarihi",100);

            listView2.Columns.Add("Kar-Zarar", 156);
            listView2.Columns.Add("Tarihi", 100);

        }

        private void Kar_Zarar_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            int diziGiderUzunluk = Methodlar.text_uzunlugu(dosya_yolu_gider);
            int diziSatisUzunluk = Methodlar.text_uzunlugu(dosya_yolu_satis);
            string[,] diziGider2D = new string[diziGiderUzunluk, 2];
            string[,] diziGelir2D = new string[diziSatisUzunluk, 2];
            string[,] diziKarZarar2D = new string[Methodlar.text_uzunlugu(dosya_yolu_KarZarar), 2];
            string[] diziGider1D = new string[2];
            string[] diziGelir1D = new string[2];
            string[] diziKarZarar = new string[2];
            Methodlar.Okuma(dosya_yolu_gider, diziGider2D);
            Methodlar.Okuma(dosya_yolu_gelir, diziGelir2D);
            Methodlar.Okuma(dosya_yolu_KarZarar, diziKarZarar2D);
            dizi_aktarma(diziGider2D, diziGider1D,1,dosya_yolu_gider);
            dizi_aktarma(diziKarZarar2D, diziKarZarar, 2,dosya_yolu_KarZarar);

            int karZarar = 0;
            


            


        }

        private void button1_Click(object sender, EventArgs e)  // EKLE
        {
            string tutar = textBox2.Text;
            string giderTarihi = textBox1.Text;
            
            if (Methodlar.Bosmu(giderTarihi) || Methodlar.Bosmu(tutar))
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz");
            }
            else if(!(Methodlar.Sayimi(tutar)))
            {
                MessageBox.Show("Lütfen Tutar Sadece Sayılardan Oluşsun");
            }
            else
            {
                string[] dizi = { giderTarihi, tutar };
                ListViewItem item = new ListViewItem(dizi);
                listView1.Items.Add(item);
                Methodlar.Yazma(dosya_yolu_gider, dizi);

            }
            


        }

        private void button2_Click(object sender, EventArgs e) // Sil
        {

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string item_text = "";
                string satir = "";
                for (int k = 0; k < 2; k++)
                {
                    item_text += item.SubItems[k].Text;
                }
                int diziGiderUzunluk = Methodlar.text_uzunlugu(dosya_yolu_gider);
                string[,] diziGider2D = new string[diziGiderUzunluk, 2];
                Methodlar.Okuma(dosya_yolu_gider, diziGider2D);

                for (int i = 0; i < Methodlar.text_uzunlugu(dosya_yolu_gider); i++)
                {
                    satir = "";
                    for (int j = 0; j < 2; j++)
                    {
                        satir += diziGider2D[i, j];
                    }
                    if (satir == Convert.ToString(item_text))
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            diziGider2D[i, k] = diziGider2D[i, k].Remove(0, diziGider2D[i, k].Length);
                        }
                    }
                }
                Methodlar.Yazma_silerek(dosya_yolu_gider, diziGider2D, Methodlar.text_uzunlugu(dosya_yolu_gider), 2);
                item.Remove();
            }

        }

        public void liste_aktarma(string[] dizi,int a)
        {
            ListViewItem item = new ListViewItem(dizi);
            if(a==1)
            {
                listView1.Items.Add(item);
            }
            if(a==2)
            {
                listView2.Items.Add(item);
            }
            

        }
        public void dizi_aktarma(string[,] dizi, string[] dizi2,int a,string dosyaYolu)
        {
            for (int i = 0; i < Methodlar.text_uzunlugu(dosyaYolu); i++)
            {
                for (int j = 0; j < dizi2.Length; j++)
                {
                    dizi2[j] = dizi[i, j];
                }
                liste_aktarma(dizi2,a);
            }
        }
        public void dizi_aktarma2(string[,] dizi, string[] dizi2)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < dizi2.Length; j++)
                {
                    dizi2[j] = dizi[i, j];
                }

            }
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
