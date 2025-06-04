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
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=tsomtal.com;Initial Catalog=SporSalonu;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {

        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {


        }
        private void b_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string sifre = txtSifre.Text;

            if (mail == "admin@gmail.com" && sifre == "654321")
            {
                new Form4().Show();
                this.Hide();
                return;
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Uyeler WHERE Mail=@mail AND Sifre=@sifre", baglanti);
            komut.Parameters.AddWithValue("@mail", mail);
            komut.Parameters.AddWithValue("@sifre", sifre);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form3 form3 = new Form3();
                form3.mail = mail;
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
        }

        private void btnUyeOl_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
