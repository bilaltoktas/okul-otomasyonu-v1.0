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
    public partial class ogretmendetay : Form
    {
        public ogretmendetay()
        {
            InitializeComponent();
        }
        public string ogretmenid;
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");

        private void ogretmendetay_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ogretmenadsoyad from tbl_ogretmen where ogretmenid=" + ogretmenid, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                label1.Text = dr[0].ToString();
            }
            baglanti.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_ogrenci",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)//anasayfa düğmesi
        {
             Form1 fr = new Form1();
             fr.Show();
             this.Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e) // kapatma düğmesi
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)//kulüp işlemleri
        {
            frmkulüp fr = new frmkulüp();
            fr.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)//kulüp işlemleri
        {
            frmkulüp fr = new frmkulüp();
            fr.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e) //geri düğmesi
        {
            ogretmengiris fr = new ogretmengiris();
            fr.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e) //ders işlemleri
        {
            frmders fr = new frmders();
            fr.Show();
        }

        private void label5_Click(object sender, EventArgs e) //ders işlemleri
        {
            frmders fr = new frmders();
            fr.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmogrenci fr = new frmogrenci();
            fr.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmogrenci fr = new frmogrenci();
            fr.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
