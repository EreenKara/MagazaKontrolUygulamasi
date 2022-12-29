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
    public partial class Stok : Form
    {

        string dosya_yolu = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\stok.txt";
        public Stok()
        {
            InitializeComponent();

            listView1.Columns.Add("Ürün Kodu", 100);    //1
            listView1.Columns.Add("Markası", 100);   //2
            listView1.Columns.Add("Çeşidi ", 100);   //3
            listView1.Columns.Add("Bedeni", 100);   //4
            listView1.Columns.Add("Cinsiyeti", 100);   //5
            listView1.Columns.Add("Nerede", 100); // 6
            listView1.Columns.Add("Tane Fiyatı", 100);   //7
            listView1.Columns.Add("Stok Sayısı", 100);   //8

            listView2.Columns.Add("Ürün Kodu", 100);
            listView2.Columns.Add("Markası", 100);
            listView2.Columns.Add("Çeşidi", 100);
            listView2.Columns.Add("Bedeni", 100);
            listView2.Columns.Add("Cinsiyeti", 100);
            listView2.Columns.Add("Nerede", 100);
            listView2.Columns.Add("Tane Fiyatı" ,100);
            listView2.Columns.Add("Stok Sayısı", 100);

        }

        private void Stok_Load(object sender, EventArgs e)
        {
            
            listView1.Items.Clear();
            listView2.Items.Clear();
            string[,] dizi = new string[Methodlar.text_uzunlugu(dosya_yolu), 8];

            string[] dizi2 = new string[8];

            Methodlar.Okuma(dosya_yolu, dizi);
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

        private void button1_Click(object sender, EventArgs e) // ARA
        {
            if (!(Methodlar.Bosmu(textBox1.Text)))
            {
                if (Methodlar.urun_kodu(textBox1.Text))
                {
                    bool eklimi = false;
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (textBox1.Text == listView2.Items[i].SubItems[0].Text)
                        {
                            eklimi = true;
                        }
                    }
                    if (eklimi)
                    {
                        MessageBox.Show("Arama Sonuçlarında İstenilen Bilgi Zaten Gösterilmekte.");
                    }
                    else
                    {
                        string aranan_kod = textBox1.Text;
                        bool bulundumu=false;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            string kod = listView1.Items[i].SubItems[0].Text;
                            if (aranan_kod == kod)
                            {
                                bulundumu = true;
                                string urun_kodu = listView1.Items[i].SubItems[0].Text;
                                string markasi = listView1.Items[i].SubItems[1].Text;
                                string cesidi = listView1.Items[i].SubItems[2].Text;
                                string bedeni = listView1.Items[i].SubItems[3].Text;
                                string cinsiyeti = listView1.Items[i].SubItems[4].Text;
                                string nerede = listView1.Items[i].SubItems[5].Text;
                                string fiyat= listView1.Items[i].SubItems[6].Text;
                                string stok = listView1.Items[i].SubItems[7].Text;


                                string[] dizi = { urun_kodu, markasi, cesidi, bedeni, cinsiyeti, nerede,fiyat, stok };

                                ListViewItem item = new ListViewItem(dizi);
                                listView2.Items.Add(item);
                            }
                            
                        }
                        if (!(bulundumu))
                        {
                            MessageBox.Show("Eşleşen sonuç bulunamadı.");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Yanlış bir ürün kodu girdiniz.");
                }
            }
            else
            {
                MessageBox.Show("Ürün kodunu boş bırakmayın.");
            }
        }
        private void button2_Click(object sender, EventArgs e)  // TEMİZLE
        {
            listView2.Items.Clear();
        }





    }
}
