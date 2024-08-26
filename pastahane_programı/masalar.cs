using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pastahane_programı
{
    public partial class masalar : Form
    {
        public String ka;
        public masalar()
        {
            InitializeComponent();
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ımageList1.Images[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ımageList1.Images[1];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ımageList1.Images[1];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = ımageList1.Images[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = ımageList1.Images[1];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = ımageList1.Images[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = ımageList1.Images[1];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = ımageList1.Images[0];
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = ımageList1.Images[1];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = ımageList1.Images[0];
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = ımageList1.Images[1];
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = ımageList1.Images[0];
        }

        private void button21_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = ımageList1.Images[1];
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = ımageList1.Images[0];
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = ımageList1.Images[1];
        }

        private void button23_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = ımageList1.Images[0];
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = ımageList1.Images[1];
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = ımageList1.Images[0];
        }

        private void button30_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = ımageList1.Images[1];
        }

        private void button29_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = ımageList1.Images[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();           
           
            form.numara = ka;
            form.ka = ka;
            form.numara = "1";
            form.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
            
            form.numara = ka;
            form.ka = ka;
            form.numara = "2";
            form.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
           
            form.numara = ka;
            form.ka = ka;
            form.numara = "3";
            form.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
          
            form.numara = ka;
            form.ka = ka;
            form.numara = "4";
            form.Show();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
            
            form.numara = ka;
            form.ka = ka;
            form.numara = "5";
            form.Show();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
          
            form.numara = ka;
            form.ka = ka;
            form.numara = "6";
            form.Show();
            this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
           
            form.numara = ka;
            form.ka = ka;
            form.numara = "7";
            form.Show();
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
            
            form.numara = ka;
            form.ka = ka;
            form.numara = "8";
            form.Show();
            this.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
          
            form.numara = ka;
            form.ka = ka;
            form.numara = "9";
            form.Show();
            this.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            siparişler form = new siparişler();
           
            form.numara = ka;
            form.ka = ka;
            form.numara = "10";
            form.Show();
            this.Close();
        }

        private void anamenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anamenü form = new anamenü();
            //form.numara = ka;
            form.ka = ka;
            form.Show();
            this.Close();
        }

        private void masalar_Load(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mesaj form = new mesaj();
            form.numara = ka;
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
           // form.numara = ka;
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
