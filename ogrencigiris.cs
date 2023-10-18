using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eokulörnek
{
    public partial class ogrencigiris : Form
    {
        public ogrencigiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("NUMARA GİRİŞİ KISMI BOŞ GEÇİLEMEZ", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ogrencibilgi fr = new ogrencibilgi();
                fr.numara = textBox1.Text;
                fr.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("NUMARA GİRİŞİ KISMI BOŞ GEÇİLEMEZ", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ogrencibilgi fr = new ogrencibilgi();
                fr.numara = textBox1.Text;
                fr.Show();
                this.Hide();
            }
        }
    }
}
