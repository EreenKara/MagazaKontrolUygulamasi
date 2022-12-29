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
using System.Collections;

namespace ProjeOdevi2.Donem
{
    public partial class Tedarikciler : Form
    {

        int uzunluk = 5;
        public Tedarikciler()
        {


            InitializeComponent();

            listView1.Columns.Add("İsim Soyisim", 140);
            listView1.Columns.Add("E-mail", 160);
            listView1.Columns.Add("Telefon", 140);
            listView1.Columns.Add("Çeşit", 100);
            listView1.Columns.Add("Marka", 120);

            
            listView2.Columns.Add("İsim Soyisim", 140);
            listView2.Columns.Add("E-mail", 160);
            listView2.Columns.Add("Telefon", 140);
            listView2.Columns.Add("Çeşit", 100);
            listView2.Columns.Add("Marka", 120);

        }

        string dosya_yolu = @"D:\Dersler\Kodlar\\C#\ProjeOdevi2.Donem\Text_Dosyalari\tedarikci.txt";


        
        private void Tedarikciler_Load(object sender, EventArgs e)
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
       

        private void button1_Click(object sender, EventArgs e)  // EKLE
        {
            if (Methodlar.Bosmu(textBox1.Text) || Methodlar.Bosmu(textBox2.Text) || Methodlar.Bosmu(textBox3.Text) || Methodlar.Bosmu(comboBox1.Text) || Methodlar.Bosmu(comboBox2.Text))
            {
                MessageBox.Show("Lütfen Her Yeri Doldurunuz.");
            }
            else if (!(Methodlar.Harfmi(textBox1.Text)) || !(Methodlar.Emailmi(textBox2.Text)) || !(textBox3.Text.Length == 11) || !(Methodlar.Sayimi(textBox3.Text)) || !(Methodlar.Harfmi(comboBox2.Text)))
            {
                MessageBox.Show("Lütfen Bilgileri Doğru Giriniz.");
            }
            else
            {
                bool eklimi = false;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (textBox2.Text == listView1.Items[i].SubItems[1].Text || textBox3.Text == listView1.Items[i].SubItems[2].Text)
                    {
                        eklimi = true;
                    }
                }
                if (eklimi)
                {
                    MessageBox.Show("Tedarikçi zaten listede bulunuyor.");
                }
                else
                {
                    string[] dizi = { textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text };
                    Methodlar.Yazma(dosya_yolu, dizi);
                    ListViewItem item = new ListViewItem(dizi);
                    listView1.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // SİL
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string item_text="";
                for(int k=0;k< 5;k++)
                {
                    item_text += item.SubItems[k].Text;
                }
                
                string[,] dizi = new string[Methodlar.text_uzunlugu(dosya_yolu),5];
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
                        for(int k=0;k<5;k++)
                        {
                            
                            dizi[i,k]=dizi[i, k].Remove(0,dizi[i,k].Length) ;
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

        private void button3_Click(object sender, EventArgs e)  // ARA
        {

            if (!(Methodlar.Bosmu(textBox2.Text)) || !(Methodlar.Bosmu(textBox3.Text)))
            {
                if (Methodlar.Emailmi(textBox2.Text) && (textBox3.Text.Length == 11 || Methodlar.Sayimi(textBox3.Text)))
                {
                    bool eklimi = false;
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (textBox2.Text == listView2.Items[i].SubItems[1].Text || textBox3.Text == listView2.Items[i].SubItems[2].Text)
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
                        string email_istenilen = textBox2.Text;
                        string telefon_istenilen = textBox3.Text;
                        bool bulundumu = false;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            string email_olan = listView1.Items[i].SubItems[1].Text;
                            string telefon_olan = listView1.Items[i].SubItems[2].Text;
                            if (email_istenilen == email_olan || telefon_istenilen == telefon_olan)
                            {
                                bulundumu = true;
                                string isim = listView1.Items[i].SubItems[0].Text;
                                string email = listView1.Items[i].SubItems[1].Text;
                                string telefon = listView1.Items[i].SubItems[2].Text;
                                string cesit = listView1.Items[i].SubItems[3].Text;
                                string marka = listView1.Items[i].SubItems[4].Text;



                                string[] dizi = { isim, email, telefon, cesit, marka };

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
                MessageBox.Show("E-posta ve Telefon boş bırakılamaz.");
            }
        }
        
        private void button4_Click(object sender, EventArgs e) // Arama Sonuçlarını Sıfırla
        {
            listView2.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
