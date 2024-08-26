using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pastahane_programı
{
    public partial class mesaj : Form
    {
        public String ka;
        public mesaj()
        {
            InitializeComponent();
        }
        public String numara;

         OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");

     //  sqlbag bag = new sqlbag();

       



        void gelenkutusu()
        {

         
            try
            {
                OleDbDataAdapter da1 = new OleDbDataAdapter("select GONDEREN,ALICI,BASLIK,ICERIK from TBLMESAJLAR where ALICI=" + numara,baglanti);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                
            }
        }
        void gidenkutusu()
        {

            
            try
            {
                OleDbDataAdapter da2 = new OleDbDataAdapter("select GONDEREN,ALICI,BASLIK,ICERIK from TBLMESAJLAR where GONDEREN=" + numara, baglanti);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        bool deger;
        void var()
        {

           
            baglanti.Open();
            OleDbCommand tekrar = new OleDbCommand("SELECT GONDEREN,ALICI,BASLIK,ICERIK FROM TBLMESAJLAR WHERE BASLIK='" + textBox1.Text + "'", baglanti);
            OleDbDataReader ara = tekrar.ExecuteReader();
            if (ara.Read())
            {
                deger = false;
            }
            else
            {
                deger = true;
            }
            baglanti.Close();

        }
        private void mesaj_Load(object sender, EventArgs e)
        {
           

            {
                lblnumara.Text = numara;
                gelenkutusu();
                gidenkutusu();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select AD,SOYAD from TBLKISILER where NUMARA= "+numara, baglanti);
                OleDbDataReader dr = komut.ExecuteReader();
               while (dr.Read())
               {
                    lbladsoyad.Text = dr[0] + "" + dr[1];
               }
                baglanti.Close();
            }
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                var();
                if (deger == true)
                {

                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("insert into TBLMESAJLAR(GONDEREN,ALICI,BASLIK,ICERIK) values(@p1,@p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", numara);
                    komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@p3", textBox1.Text);
                    komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("mesajınız iletildi.");
                    gidenkutusu();
                }
                else
                    MessageBox.Show("lütfen Farklı Başlık giriniz!.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                
            }
            baglanti.Close();
            richTextBox1.Text = "";
            maskedTextBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void anamenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü form = new anamenü();
          //  form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void masalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masalar form = new masalar();
           // form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void gelalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
            form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasa form = new kasa();
           // form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evesipariş form = new evesipariş();
          //  form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

         
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yönetim form = new yönetim();
          //  form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çiıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
