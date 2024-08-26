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
    public partial class kasa : Form
    {
        public String ka;
        public kasa()
        {
            InitializeComponent();
        }
          OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");

       // sqlbag bag = new sqlbag();

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView2.SelectedCells[0].RowIndex;
                textBox1.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
                textBox8.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
                textBox9.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
                textBox10.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
                textBox11.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
                textBox2.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            
        }
        public void yenile1()
        {

         
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM siparisler",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            

        }
        public void yenile2()
        {
            
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM stok", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();

        }
        private void kasa_Load(object sender, EventArgs e)
        {
            yenile1();
            yenile2();
            int stokp = 0;
            int sp = 0;// sp siparişlerdeki para 
            int kar = 0;
            int anapara = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sp += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox3.Text = sp.ToString();

            
            for(int k=0; k<dataGridView2.Rows.Count; k++)
            {

                stokp += Convert.ToInt32(dataGridView2.Rows[k].Cells[2].Value);
            }
            textBox4.Text = stokp.ToString();
      
            anapara = sp + stokp;
            textBox6.Text = anapara.ToString();

            kar = anapara / 2;
            textBox7.Text = kar.ToString();

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
         //   form.numara = ka;
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
          //  form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evesipariş form = new evesipariş();
           // form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mesaj form = new mesaj();
            form.ka = ka;
            form.numara = ka;
            form.Show();
            this.Close();
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
