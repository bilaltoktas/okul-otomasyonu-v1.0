using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eokulörnek
{
    public partial class ogretmengiris : Form
    {
        public ogretmengiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
            int giris = Convert.ToInt32(textBox1.Text);
            if (giris <= 250)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from tbl_ogretmen where ogretmenid = @p1 and ogretmensifre = @p2", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    ogretmendetay fr = new ogretmendetay();
                    fr.ogretmenid = textBox1.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("EKSİK VE YA HATALI BİLGİ GİRDİNİZ LÜTFEN TEKRAR DENEYİNİZ...", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("ÖĞRETMEN NUMARANIZ 250'DEN BÜYÜK OLAMAZ","UYARI EKRANI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ogretmengiris_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 3;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ogretmenekle fr = new ogretmenekle();
            fr.Show();
        }
    }
}
