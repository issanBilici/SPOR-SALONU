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
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=tsomtal.com;Initial Catalog=SporSalonu;Integrated Security=True;");
        public string mail;
        public Form3()
        {
            InitializeComponent();
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT GirisHakki FROM Uyeler WHERE Mail=@mail", baglanti);
            komut.Parameters.AddWithValue("@mail", mail);
            int hak = Convert.ToInt32(komut.ExecuteScalar());
            label1.Text = hak.ToString();
            baglanti.Close();
        }

        private void btnGirisYap_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();

            // Hakkı çek
            SqlCommand komut = new SqlCommand("SELECT GirisHakki FROM Uyeler WHERE Mail=@mail", baglanti);
            komut.Parameters.AddWithValue("@mail", mail);
            int hak = Convert.ToInt32(komut.ExecuteScalar());

            if (hak > 0)
            {
                SqlCommand guncelle = new SqlCommand("UPDATE Uyeler SET GirisHakki=GirisHakki-1 WHERE Mail=@mail", baglanti);
                guncelle.Parameters.AddWithValue("@mail", mail);
                guncelle.ExecuteNonQuery();


                SqlCommand yeniHak = new SqlCommand("SELECT GirisHakki FROM Uyeler WHERE Mail=@mail", baglanti);
                yeniHak.Parameters.AddWithValue("@mail", mail);
                int kalan = Convert.ToInt32(yeniHak.ExecuteScalar());


                label1.Text = kalan.ToString();

                MessageBox.Show("Giriş yapıldı.");
            }
            else
            {
                MessageBox.Show("Giriş hakkınız kalmamış.");
            }

            baglanti.Close();
        }

        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
