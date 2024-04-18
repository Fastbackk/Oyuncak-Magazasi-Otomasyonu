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
    public partial class MusteriGiris : Form
    {
        public MusteriGiris()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        string isim;

        private void MusteriGiris_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            panel2.BackColor = Color.FromArgb(210, 0, 0, 0);
            MaximizeBox = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MusteriHesapOlustur s=new MusteriHesapOlustur();
            s.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Musteriler where Eposta=@p1 AND Sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                //müşterinin adını e postasına göre çekme

                SqlCommand komut2 = new SqlCommand("Select Ad From Tbl_Musteriler where Eposta=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textBox1.Text);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    isim = dr2[0].ToString();
                }
                bgl.baglanti().Close();

                if (checkBox1.Checked==true)
                {
                    SqlCommand komut4 = new SqlCommand("update KayitHatirla set Hatirla='"+true+"'",bgl.baglanti());
                    komut4.ExecuteNonQuery();
                    bgl.baglanti().Close(); 
                }
                else
                {
                    SqlCommand komut4 = new SqlCommand("update KayitHatirla set Hatirla='" + false + "'", bgl.baglanti());
                    komut4.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                //adını bulup anlık alışverişte olanlar tablosuna ekleme
                SqlCommand komut3 = new SqlCommand("insert into Tbl_AnlikAlisveriste (MusteriAdi) values (@p1)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", isim);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                f.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Hatalı E-Posta veya Şifre!");
            }
            bgl.baglanti().Close();
        }

        private void MusteriGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            SifreYenileme f= new SifreYenileme();
            f.Show();
            this.Hide();
        }
        int x = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            x++;
            if (x % 2 == 0)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
