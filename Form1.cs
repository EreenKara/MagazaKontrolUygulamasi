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


    public partial class Form1 : Form
    {

        Stok form_stoklar = new Stok();
        Musteriler form_musteriler = new Musteriler();
        Tedarikciler form_tedarikciler = new Tedarikciler();
        Satislar form_satislar = new Satislar();
        Siparisler form_siparisler = new Siparisler();
        Kar_Zarar form_kar_zarar = new Kar_Zarar();



        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }






        private void button1_Click(object sender, EventArgs e)
        {
            form_stoklar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_musteriler.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_tedarikciler.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form_satislar.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            form_siparisler.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            form_kar_zarar.ShowDialog();
        }


    }
}
