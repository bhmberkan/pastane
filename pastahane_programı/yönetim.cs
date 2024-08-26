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
    public partial class yönetim : Form
    {
        public String ka;
        public yönetim()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");
        public void yenile()
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * from stok",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
          

        }
        bool olay;
        void ekleme()
        {
            baglanti.Open();
            OleDbCommand ekleme = new OleDbCommand("SELECT * FROM STOK WHERE ekleme_adı=@P1", baglanti);
            ekleme.Parameters.AddWithValue("@p1", textBox6.Text);
            OleDbDataReader oku = ekleme.ExecuteReader();
            if (oku.Read())
            {
                olay = false;
            }
            else
            {
                olay = true;
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ekleme();
                if (olay == true)
                {
                    OleDbCommand ekle = new OleDbCommand("insert into stok(ekleme_adı,PARA,PASTA_DILIM,DONDURMA,TATLI,ICECEK)" +
                                        "values('" + textBox6.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);

                    baglanti.Open();
                    ekle.ExecuteNonQuery();
                    baglanti.Close();


                    yenile();
                    MessageBox.Show("ürünler eklenmiştir.");
                    //dolu olan satırları boşalttık
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (Controls[i] is TextBox) Controls[i].Text = "";
                    }
                }
                else
                    MessageBox.Show("bu ekleme adı zaten var.!","DİKKAT!",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
            baglanti.Close();
        }

        private void yönetim_Load(object sender, EventArgs e)
        {
            yenile();
            yenile2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("silmek istediğinize emin misiniz..!","dikkat verileriniz silinecek..!",MessageBoxButtons.YesNo); ;
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    OleDbCommand sil = new OleDbCommand("DELETE  FROM  stok WHERE ekleme_adı='" + textBox7.Text + "'",baglanti);
                    baglanti.Open();
                    sil.ExecuteNonQuery();
                    baglanti.Close();
                    yenile();
                    MessageBox.Show("kayıt silindi.");

                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (Controls[i] is TextBox) Controls[i].Text = "";
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else 
            
                MessageBox.Show("işlem iptal edildi.");
            baglanti.Close();
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand db = new OleDbCommand("UPDATE stok SET ekleme_adı='" + textBox6.Text + "',PARA='" + textBox1.Text+ "',PASTA_DILIM='"+textBox2.Text+"',DONDURMA='"+textBox3.Text+"',TATLI='"+textBox4.Text+"',ICECEK='"+textBox5.Text+"' WHERE ekleme_adı='"+textBox7.Text+"'",baglanti);
                baglanti.Open();
                db.ExecuteNonQuery();
                baglanti.Close();
                yenile();
                MessageBox.Show("güncellenmiştir.");

                for(int i=0; i<this.Controls.Count; i++)
                {
                    if (Controls[i] is TextBox) Controls[i].Text = " ";

                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                baglanti.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("SELECT * FROM stok WHERE ekleme_adı LIKE '" + textBox7.Text + "%'", baglanti);
                ara.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
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
          //  form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evesipariş form = new evesipariş();
         //   form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mesaj form = new mesaj();
            form.numara = ka; form.numara = ka;
            form.ka = ka;
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

        public void yenile2()
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT GONDEREN,ALICI,BASLIK,ICERIK from TBLMESAJLAR", baglanti);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();


        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand sil = new OleDbCommand("DELETE FROM TBLMESAJLAR WHERE BASLIK='" + textBox8.Text + "'", baglanti);
                baglanti.Open();
                sil.ExecuteNonQuery();
                baglanti.Close();
                yenile2();
                textBox8.Text = "";
                MessageBox.Show("messaj silindi.");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tablo = new DataTable();
                baglanti.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("SELECT GONDEREN,ALICI,BASLIK,ICERIK FROM TBLMESAJLAR WHERE BASLIK LIKE '" + textBox8.Text + "%'", baglanti);
                ara.Fill(tablo);
                dataGridView2.DataSource = tablo;
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglanti.Close();
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
