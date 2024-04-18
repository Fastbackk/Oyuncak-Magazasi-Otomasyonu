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

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class SifreYenileme : Form
    {
        public SifreYenileme()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==textBox3.Text)
            {
                string yeniSifre = textBox2.Text;
                string eposta = textBox1.Text;
                if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                    bgl.baglanti().Open();
                SqlCommand cmd = new SqlCommand("UPDATE Tbl_Musteriler SET Sifre = @sifre WHERE Eposta = @eposta", bgl.baglanti());
                cmd.Parameters.AddWithValue("@sifre", yeniSifre);
                cmd.Parameters.AddWithValue("@eposta", eposta);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Şifre başarıyla değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Şifre değiştirilemedi.");
                }
                bgl.baglanti().Close();
            }
            else
            {
                MessageBox.Show("Parolar Uyuşmuyor");
            }
        }

        private void SifreYenileme_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(210, 0, 0, 0);
            MaximizeBox = false;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            f.Show();
            this.Hide();
        }
    }
}
