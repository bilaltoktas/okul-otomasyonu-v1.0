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
    public partial class ogrencibilgi : Form
    {
        public ogrencibilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");
        public string numara;

        private void ogrencibilgi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            //form başlığını öğrenci adını yapmak
            SqlCommand komut2 = new SqlCommand("select ogrenciad,ogrencisoyad from tbl_ogrenci where ogrenciid=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label4.Text= dr[0].ToString() + " " + dr[1].ToString();
            }
            baglanti.Close();

            if (label4.Text == "(NULL)")
            {
                MessageBox.Show("ÖĞRENCİ BİLGİSİ BULUNAMADI \n LÜTFEN ANASAYFAYA DÖNÜP TEKRAR DENEYİNİZ!", "UYARI EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            // datagrid aracına verileri çekmek
            SqlCommand komut = new SqlCommand("select tbl_ders.dersad,sınav1,sınav2,sınav3,proje,ortalama,durum from tbl_not inner join tbl_ders on tbl_not.dersid=tbl_ders.dersid where ogrenciid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

           
        }

        private void ogrencibilgi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }
    }
}
