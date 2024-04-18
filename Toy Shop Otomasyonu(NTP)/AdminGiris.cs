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

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            MaximizeBox = false;
            panel2.BackColor = Color.FromArgb(185, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void AdminGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SQL sorgusu
            string query = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command = new SqlCommand(query, bgl.baglanti());

            // Sorguyu çalıştır
            command.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();


            // SQL sorgusu
            string query2 = "DELETE FROM Tbl_AnlikAlisveriste";

            // SqlCommand nesnesi oluştur
            SqlCommand command2 = new SqlCommand(query2, bgl.baglanti());

            // Sorguyu çalıştır
            command2.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_admin where KullaniciAdi=@p1 AND Sifre=@p2", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", textBox1.Text);
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader reader = komut1.ExecuteReader();
            if (reader.Read())
            {
                Yonetici s = new Yonetici();
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }
            bgl.baglanti().Close();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            GirisEkrani f = new GirisEkrani();
            f.Show();
            this.Hide();
        }
        int x = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            x++;
            if (x % 2 == 1)
            {
                textBox2.PasswordChar = '*';

                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\acik.png");

            }
            else
            {
                textBox2.PasswordChar = '\0';
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kitli.png");
            }
        }
    }
}
