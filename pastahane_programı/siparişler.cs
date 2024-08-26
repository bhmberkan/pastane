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
    public partial class siparişler : Form
    {
        public String ka;
        public siparişler()
        {
            InitializeComponent();
            
        }
        public String numara;
        public string tutar;
        private void siparişler_Load(object sender, EventArgs e)
        {
            textBox1.Text = numara;
        }
         OleDbConnection baglanti= new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");

        //sqlbag bag = new sqlbag();

       // OleDbConnection baglanti = new OleDbConnection(bag.adres);
        public void yenile()
        {
           
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM siparisler", baglanti);
            da.Fill(dt);
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            OleDbCommand ekle = new OleDbCommand("INSERT INTO siparisler(masa_no,toplam_tutar)" +
                        " values('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
            baglanti.Open();
            ekle.ExecuteNonQuery();
            baglanti.Close();

            hesaplar form = new hesaplar();
            form.numara = textBox1.Text;
            form.tutar = textBox2.Text;
            form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }
        public int fiyat;
        private void button2_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)//1
            {
                fiyat += 10;
            }

            if (checkBox2.Checked == true)//2
            {
                fiyat += 12;
            }

            if (checkBox3.Checked == true)//3
            {
                fiyat += 11;
            }

            if (checkBox4.Checked == true)//4
            {
                fiyat += 23;
            }

            if (checkBox5.Checked == true)//5
            {
                fiyat += 5;
            }

            if (checkBox6.Checked == true)//6
            {
                fiyat += 15;
            }

            if (checkBox7.Checked == true)//7
            {
                fiyat += 3;
            }

            if (checkBox8.Checked == true)//8
            {
                fiyat += 2;
            }

            if (checkBox9.Checked == true)//9
            {
                fiyat += 10;
            }

            if (checkBox10.Checked == true)//10
            {
                fiyat += 3;
            }

            if (checkBox11.Checked == true)//11
            {
                fiyat += 3;
            }

            if (checkBox12.Checked == true)//12
            {
                fiyat += 2;
            }

            textBox2.Text = fiyat.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            fiyat = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
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
          //  form.numara = ka;
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
         //   form.numara = ka;
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
            mesaj form = new mesaj();
            form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yönetim form = new yönetim();
         //   form.numara = ka;
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
