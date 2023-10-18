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
    public partial class frmogrenci : Form
    {
        DataSet1TableAdapters.tbl_ogrenciTableAdapter ds = new DataSet1TableAdapters.tbl_ogrenciTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT;Initial Catalog=e-okul-proje;Integrated Security=True");

        public frmogrenci()
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
            fr.Show();
            this.Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrenciListe();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulup", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kulupad";
            comboBox1.ValueMember = "kulupid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        string c = "belirtilmedi";
        private void btnekle_Click(object sender, EventArgs e)
        {
           
            ds.ogrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("ÖĞRENCİ EKLEME İŞLEMİ BAŞARI İLE GERÇEKLEŞTİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.ogrenciListe();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ogrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("ÖĞRENCİ BAŞARI İLE SİLİNDİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.ogrenciGuncelle(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(txtid.Text));
        }

        private void rderkek_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rderkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void rdkiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rdkiz.Checked == true)
            {
                c = "Kız";
            }
            
        }
    }
}
