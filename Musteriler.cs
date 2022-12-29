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
    public partial class Musteriler : Form
    {

        int uzunluk = 5;
        public Musteriler()
        {
            
            InitializeComponent();

            listView1.Columns.Add("İsim Soyisim", 150);
            listView1.Columns.Add("TC No", 150);
            listView1.Columns.Add("Yaş", 80);
            listView1.Columns.Add("Telefon", 150);
            listView1.Columns.Add("Cinsiyet", 100);

            listView2.Columns.Add("İsim Soyisim", 150);
            listView2.Columns.Add("TC No", 150);
            listView2.Columns.Add("Yaş", 80);
            listView2.Columns.Add("Telefon", 150);
            listView2.Columns.Add("Cinsiyet", 100);
        }
        string dosya_yolu = @"D:\Dersler\Kodlar\C#\ProjeOdevi2.Donem\Text_Dosyalari\musteri.txt";
        private void Musteriler_Load(object sender, EventArgs e)
        {

            
            listView1.Items.Clear();
            listView2.Items.Clear();
            string[,] dizi = new string[Methodlar.text_uzunlugu(dosya_yolu), 5];

            string[] dizi2 = new string[5];

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

        private void button1_Click(object sender, EventArgs e)  // SİL // ARanılan müşteriyi silebil ve bu siliş texten de olsun
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string item_text = "";
                for (int k = 0; k < 5; k++)
                {
                    item_text += item.SubItems[k].Text;
                }

                string[,] dizi = new string[Methodlar.text_uzunlugu(dosya_yolu), 5];
                Methodlar.Okuma(dosya_yolu, dizi);
                string satir = "";

                for (int i = 0; i < Methodlar.text_uzunlugu(dosya_yolu); i++)
                {
                    satir = "";
                    for (int j = 0; j < 5; j++)
                    {
                        satir += dizi[i, j];
                    }
                    if (satir == Convert.ToString(item_text))
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            dizi[i, k] = dizi[i, k].Remove(0, dizi[i, k].Length);
                        }
                    }
                }
                Methodlar.Yazma_silerek(dosya_yolu, dizi, Methodlar.text_uzunlugu(dosya_yolu),uzunluk);
                item.Remove();

            }
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                item.Remove();
            }


        }

        private void button2_Click(object sender, EventArgs e) // EKLE
        {
            if (Methodlar.Bosmu(textBox1.Text) || Methodlar.Bosmu(textBox2.Text) || Methodlar.Bosmu(textBox3.Text) || Methodlar.Bosmu(textBox4.Text))
            {
                MessageBox.Show("Lütfen Her Yeri Doldurunuz.");
            }
            else if (!(Methodlar.Harfmi(textBox1.Text)) || !(Methodlar.Sayimi(textBox2.Text)) || !(textBox2.Text.Length == 11) || !(Methodlar.Sayimi(textBox3.Text)) || !(textBox4.Text.Length == 11) || !(Methodlar.Sayimi(textBox4.Text)))
            {
                MessageBox.Show("Lütfen Bilgileri Doğru Giriniz.");
            }
            else
            {
                bool eklimi = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (textBox2.Text == listView1.Items[i].SubItems[1].Text)
                    {
                        eklimi = true;
                    }
                }
                if (eklimi)
                {
                    MessageBox.Show("Kişi zaten ekli.");
                }
                else
                {
                    string cinsiyet = null;
                    if (radioButton1.Checked)
                    {
                        cinsiyet = "Erkek";
                    }
                    else if (radioButton2.Checked)
                    {
                        cinsiyet = "Kadın";
                    }

                    string[] dizi = { textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text, cinsiyet };
                    Methodlar.Yazma(dosya_yolu, dizi);
                    ListViewItem item = new ListViewItem(dizi);
                    listView1.Items.Add(item);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e) // ARA   
        {

            if (!(Methodlar.Bosmu(textBox2.Text)))
            {
                if (Methodlar.Sayimi(textBox2.Text) && (textBox2.Text.Length == 11))
                {
                    bool eklimi = false;
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (textBox2.Text == listView2.Items[i].SubItems[1].Text)
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
                        string aranan_kod = textBox2.Text;
                        bool bulundumu = false;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            string kod = listView1.Items[i].SubItems[1].Text;
                            if (aranan_kod == kod)
                            {
                                bulundumu = true;
                                string urun_kodu = listView1.Items[i].SubItems[0].Text;
                                string markasi = listView1.Items[i].SubItems[1].Text;
                                string cesidi = listView1.Items[i].SubItems[2].Text;
                                string bedeni = listView1.Items[i].SubItems[3].Text;
                                string cinsiyeti = listView1.Items[i].SubItems[4].Text;
                                


                                string[] dizi = { urun_kodu, markasi, cesidi, bedeni, cinsiyeti };

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
                    MessageBox.Show("Yanlış bir TC girdiniz.");
                }
            }
            else
            {
                MessageBox.Show("TC'yi boş bırakmayınız.");
            }


        }

        private void button4_Click(object sender, EventArgs e)  // ARAMA SONUÇLARINI SIFIRLA
        {
            listView2.Items.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
