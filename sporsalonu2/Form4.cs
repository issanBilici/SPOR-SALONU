using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sporsalonu2
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=tsomtal.com;Initial Catalog=SporSalonu;Integrated Security=True;");
        public Form4()
        {
            InitializeComponent();
        }
        private void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Uyeler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Sütun başlıklarını düzenle
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            dataGridView1.Columns["Mail"].HeaderText = "E-Posta";
            dataGridView1.Columns["Sifre"].HeaderText = "Şifre";
            dataGridView1.Columns["GirisHakki"].HeaderText = "Giriş Hakkı";
        }
        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtGirisHakki.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Uyeler (AdSoyad, Mail, Sifre, GirisHakki) VALUES (@adsoyad, @mail, @sifre, @hak)", baglanti);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@mail", txtMail.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@hak", int.Parse(txtGirisHakki.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Üye başarıyla eklendi.");
            Listele(); 
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Uyeler WHERE Id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Uyeler WHERE AdSoyad LIKE @ara", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@ara", txtAra.Text + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtGirisHakki.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Uyeler SET AdSoyad=@adsoyad, Mail=@mail, Sifre=@sifre, GirisHakki=@hak WHERE Id=@id", baglanti);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@mail", txtMail.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@hak", int.Parse(txtGirisHakki.Text));
            komut.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Güncelleme başarılı.");
            Listele(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                txtId.Text = satir.Cells["Id"].Value.ToString();
                txtAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
                txtMail.Text = satir.Cells["Mail"].Value.ToString();
                txtSifre.Text = satir.Cells["Sifre"].Value.ToString();
                txtGirisHakki.Text = satir.Cells["GirisHakki"].Value.ToString();
            }
        }
    }
}