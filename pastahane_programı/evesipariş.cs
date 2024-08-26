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
    public partial class evesipariş : Form
    {
        public String ka;
        public evesipariş()
        {
            InitializeComponent();
        }

          OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=pastane.accdb");
      //  sqlbag bag = new sqlbag();
        public void sill()
        {

            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        public void yenile()
        {

          
            DataTable dt = new DataTable();
            baglanti.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT AD_SOYAD,TELEFON,GMAIL,PASTA,BUYUKLUK FROM evesiparis", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        
        public void Bosmu()
        {
            if(textBox1.Text.Trim()=="" || maskedTextBox1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("boş kutuları doldurun.");

            }

        }
        bool olay;

        void var()
        {

          
            baglanti.Open();
            OleDbCommand var = new OleDbCommand("SELECT * FROM evesiparis WHERE AD_SOYAD='"+textBox1.Text+"'",baglanti);
            OleDbDataReader dr = var.ExecuteReader();
            if (dr.Read())
            {
                olay = false;
            }
            else
                olay = true;
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

         
            Bosmu();
            try
            {
                var();
                if (olay == true)
                {

                    OleDbCommand ekle = new OleDbCommand("insert into evesiparis(AD_SOYAD,TELEFON,GMAIL,PASTA,BUYUKLUK)" +
                        "values('" + textBox1.Text + "', '" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
                    //telefonu veri tabanından almıyor hata verıyor ölçüt 
                    baglanti.Open();
                    ekle.ExecuteNonQuery();
                    baglanti.Close();


                    yenile();
                    MessageBox.Show("veriler eklenmiştir");

                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (Controls[i] is TextBox) Controls[i].Text = "";
                    }
                    sill();
                   
                }
                else
                    MessageBox.Show("bu kayıt zaten var!.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
            baglanti.Close();
        }
       
        private void evesipariş_Load(object sender, EventArgs e)
        {
            yenile();
           // label3.Text = numara;
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = new DataTable();
                baglanti.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("SELECT AD_SOYAD,TELEFON,GMAIL,PASTA,BUYUKLUK FROM evesiparis WHERE AD_SOYAD LIKE'" + textBox6.Text+"%'",baglanti);
                ara.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DialogResult cevap;
            cevap = MessageBox.Show("silmek istediğinize emin misiniz..!", "dikkat verileriniz silinecek..!", MessageBoxButtons.YesNo); ;
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand sil = new OleDbCommand("DELETE FROM evesiparis WHERE AD_SOYAD='" + textBox6.Text + "'", baglanti);
                baglanti.Open();
                sil.ExecuteNonQuery();
                baglanti.Close();
                yenile();
                MessageBox.Show("kaydı sildiniz.");

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (Controls[i] is TextBox) Controls[i].Text = "";
                }
                sill();
            }
            else
                MessageBox.Show("işlemi sonlandırdınız.");
                baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DialogResult cevap;
            cevap = MessageBox.Show("güncellemek istediğinize emin misiniz.","verileriniz güncellenecek",MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    OleDbCommand gnc = new OleDbCommand("UPDATE evesiparis SET AD_SOYAD='" + textBox1.Text + "',TELEFON='" + maskedTextBox1.Text + "',GMAIL='" + textBox3.Text + "',PASTA='" + textBox4.Text + "',BUYUKLUK='" + textBox5.Text + "' WHERE AD_SOYAD='" + textBox6.Text + "'", baglanti);
                    baglanti.Open();
                    gnc.ExecuteNonQuery();
                    baglanti.Close();
                    yenile();
                    MessageBox.Show("güncelleme işlemi tamamlanmıştır.");

                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (Controls[i] is TextBox) Controls[i].Text = "";
                    }
                    sill();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
                baglanti.Close();
            }
            else
                MessageBox.Show("işlem iptal edildi.");
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
           // form.numara = ka;
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
            //MessageBox.Show(ka);  ka değerini gönderiyormu diye kontrol ettim.
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            
        }
    }
}
