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
    public partial class ogretmenekle : Form
    {
        public ogretmenekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty || textBox2.Text==string.Empty || comboBox1.Text==string.Empty)
            {
                MessageBox.Show("BİLGİLERİ EKSİK GİRDİNİZ", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tbl_ogretmen (ogretmenadsoyad,ogretmensifre,ogretmenbrans) values (@p1,@p2,@p3)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", (comboBox1.SelectedIndex+1));
                komut.ExecuteNonQuery();
                baglanti.Close();
                
                
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("select ogretmenid from tbl_ogretmen where ogretmenadsoyad=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", textBox1.Text);
                SqlDataReader dr = komut2.ExecuteReader();
                while (dr.Read())
                {

                    MessageBox.Show("KAYIT BAŞARI İLE EKLENDİ!\n ÖĞRETMEN NUMARANIZ:"+dr[0], "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                baglanti.Close();
            }
        }

        private void ogretmenekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select kulupad from tbl_kulup ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ogretmengiris fr = new ogretmengiris();
            fr.Show();
            this.Close();
            
        }
    }
}
