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
    public partial class frmders : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");


        public void datayaAktar() //kod yükünü azaltmak için birden fazla yapacağımız tekrarlı işlemi metod olarak tanımladık
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ders", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = string.Empty;//işlem sonrası textboxlarda veri kalmaması için bunları ekledik
            textBox2.Text = string.Empty;
        }
        public frmders()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Form1 fr = new Form1();
            this.Close();
            Application.Restart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmders_Load(object sender, EventArgs e)
        {
            datayaAktar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_ders (dersad) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("DERS BİLGİSİ BAŞARI İLE EKLENDİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();
            datayaAktar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("SİLİNECEK DERSİ SEÇMEDİNİZ", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from tbl_ders where dersid=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("KAYIT BAŞARI İLE SİLİNDİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
                datayaAktar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tbl_ders set dersad=@p1 where dersid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARI İLE TAMAMLANDI", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();
            datayaAktar();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); //burada e metodun parametre olarak aldığı e dir
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
