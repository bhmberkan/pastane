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
    public partial class hesaplar : Form
    {
        public String ka;
        public hesaplar()
        {
            InitializeComponent();
        }
          OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");
    //    sqlbag bag = new sqlbag();
        public void yenile()
        {

         
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM siparisler",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {

        
            int toplamt;
            double verilent, pü; //  toplam tutar, verilen tutar, para üstü
            //hesap öde yapınca hesabın ödendiği hakkında bilgi vericek.
            toplamt = Convert.ToInt32(textBox2.Text);// doubleye donuşturucem ! aşşağıdakını de.
            verilent = Convert.ToInt32(textBox3.Text);
            pü = verilent-toplamt;
            textBox4.Text = pü.ToString();

            if(textBox1.Text.Trim()!="" && textBox2.Text.Trim()!="" && textBox3.Text.Trim() != "")
            {
                try
                {
                   /* OleDbCommand ekle = new OleDbCommand("INSERT INTO siparisler(masa_no,toplam_tutar)" +
                        " values('"+textBox1.Text+"','"+textBox2.Text+"')",baglanti);
                    baglanti.Open();
                    ekle.ExecuteNonQuery();
                    baglanti.Close();*/

                    yenile();
                    MessageBox.Show("hesap ödendi.");
                    /* döngü çalişmiyor. :( */
                    for(int i=0; i<this.Controls.Count;i++)
                    {
                        if (Controls[i] is TextBox) Controls[i].Text = " ";

                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                   

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
                baglanti.Close();
                yenile();

            }

        }
        public string numara;
        public string tutar;
        private void hesaplar_Load(object sender, EventArgs e)
        {
            textBox1.Text = numara;
            textBox2.Text = tutar.ToString();
            yenile();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

          
            OleDbCommand sil = new OleDbCommand("DELETE FROM siparisler",baglanti);
            baglanti.Open();
            sil.ExecuteNonQuery();
            baglanti.Close();
            yenile();

        }

        private void anamenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü form = new anamenü();
         //   form.numara = ka;
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
           // form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çiıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hesapsayısı;
            hesapsayısı = dataGridView1.RowCount - 1;
            MessageBox.Show(hesapsayısı.ToString());
        }
    }
}
