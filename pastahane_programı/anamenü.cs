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
    public partial class anamenü : Form
    {
        public String ka;
        public anamenü()
        {
            InitializeComponent();
        }
          OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");
       

      //  sqlbag bag = new sqlbag();

     
        
        
     

        public void yenile()
        {

            
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From stok",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }
        private void anamenü_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yenile();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                DataTable dt = new DataTable();
                baglanti.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("SELECT * FROM stok WHERE kimlik LIKE '"+textBox1.Text+"'",baglanti);
                ara.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch ( Exception hata)
            {
                MessageBox.Show(hata.Message);              
            }
            if(textBox1.Text=="")
            {
                yenile();
            }
        }

        private void anamenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü form = new anamenü();
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void masalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            masalar form = new masalar();
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void gelalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
            form.ka = ka;
            form.numara = ka;
            form.Show();
            this.Close();
        }

        private void kasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasa form = new kasa();
            form.ka = ka;
           
            form.Show();
            this.Close();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            evesipariş form = new evesipariş();
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
