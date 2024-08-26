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
    public partial class giriş : Form
    {
        public giriş()
        {
            InitializeComponent();
        }

           OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");
      //  sqlbag bag = new sqlbag();
        private void button1_Click(object sender, EventArgs e)
        {

            
            baglanti.Open();            
            OleDbCommand komut = new OleDbCommand("select * from TBLKISILER where NUMARA=@p1 AND SIFRE=@P2",baglanti);
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            OleDbDataReader dr = komut.ExecuteReader();
            
            if(dr.Read())
            {
                mesaj mesaj = new mesaj();
                mesaj.numara = maskedTextBox1.Text;
                //mesaj.Show();
               anamenü form = new anamenü();
                form.ka = maskedTextBox1.Text;
                form.Show();
            }
            else
            {
                MessageBox.Show("hatalı bilgi.");
            }
            baglanti.Close();
            this.Hide();
        }

        private void giriş_Load(object sender, EventArgs e)
        {

        }

        private void giriş_Load_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
