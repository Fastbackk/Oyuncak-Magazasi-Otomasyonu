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
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class AdventureTimeOyuncakları : Form
    {
        public AdventureTimeOyuncakları()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        public int finnfiyat, jakefiyat, prensessakızfiyat, marcelinefiyat, fionnafiyat, bimofiyat;
        public string isim;
        byte stok;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tuna.Width -= 10;
            if (tuna.Width <= 66)
            {
                timer1.Stop();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tuna.Width += 10;
            if (tuna.Width >= 222)
            {
                timer2.Stop();

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            if (tuna.Width >= 222)
            {
                f.tuna.Width = 222;
            }
            else
            {
                f.tuna.Width = 66;
            }
            f.Show();
            this.Hide();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            if (tuna.Width >= 222)
            {
                f.tuna.Width = 222;
            }
            else
            {
                f.tuna.Width = 66;
            }
            f.Show();
            this.Hide();
        }
        void jake()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label2.Text;
            f.oyuncakfiyat.Text = label3.Text;
            f.pictureBox1.Image = pictureBox1.Image;
           
            f.urun = "jake";
           
            f.sayfaisim = "adv";
            jakefiyat = 890;
            f.fiyat = jakefiyat;
            f.Show();
            this.Hide();
        }
        void marceline() {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label8.Text;
            f.oyuncakfiyat.Text = label7.Text;
            f.pictureBox1.Image = pictureBox4.Image;
            
            f.urun = "marceline";
            
            f.Show();
            f.sayfaisim = "adv";
            marcelinefiyat = 350;
            f.fiyat = marcelinefiyat;
            this.Hide();
        }
        void bimo()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label6.Text;
            f.oyuncakfiyat.Text = label5.Text;
            f.pictureBox1.Image = pictureBox3.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 130;
            darthvaderkonum.Y = 115;
            f.urun = "bimo";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(469, 500);
            f.Show();
            f.sayfaisim = "adv";
            bimofiyat = 130;
            f.fiyat = bimofiyat;
            this.Hide();

        }
        void fionna()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label10.Text;
            f.oyuncakfiyat.Text = label9.Text;
            f.pictureBox1.Image = pictureBox13.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 251;
            darthvaderkonum.Y = 115;
            f.urun = "fionna";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(209, 500);
            f.Show();
            f.sayfaisim = "adv";
            fionnafiyat = 560;
            f.fiyat = fionnafiyat;
            this.Hide();
        }
        public string tool(string s)
        {
            SqlCommand komut = new SqlCommand("Select " + s + " From SinirliStokAdventureTime", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                stok = (byte)dr[s];



            }
            bgl.baglanti().Close();
            return s;

        }
        private void AdventureTimeOyuncakları_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;


            try
            {
                SqlCommand komut = new SqlCommand("Select Musteriadi From Tbl_AnlikAlisveriste", bgl.baglanti());
                SqlDataReader dr2 = komut.ExecuteReader();
                while (dr2.Read())
                {
                    isim = dr2[0].ToString();
                }
                bgl.baglanti().Close();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesap yok");
            }
        }
        void prenses()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label12.Text;
            f.oyuncakfiyat.Text = label11.Text;
            f.pictureBox1.Image = pictureBox14.Image;
          
            f.urun = "prenses";
            
            f.Show();
            f.sayfaisim = "adv";
            prensessakızfiyat = 470;
            f.fiyat = prensessakızfiyat;
            this.Hide();
        }
        void finn()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label4.Text;
            f.oyuncakfiyat.Text = label1.Text;
            f.pictureBox1.Image = pictureBox2.Image;
            
            f.urun = "Finn";
            
            f.sayfaisim = "adv";
            finnfiyat = 900;
            f.fiyat = finnfiyat;
            f.Show();
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            jake();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            jake();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            jake();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            finn();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            finn();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            finn();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bimo();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            marceline();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            bimo();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            bimo();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            marceline();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            prenses();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            prenses();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            prenses();
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            if (tuna.Width >= 222)
            {
                f.tuna.Width = 222;
            }
            else
            {
                f.tuna.Width = 66;
            }
            f.Show();
            this.Hide();
        }

        private void btnAnaSayfa_Click_1(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            if (tuna.Width >= 222)
            {
                f.tuna.Width = 222;
            }
            else
            {
                f.tuna.Width = 66;
            }
            f.Show();
            this.Hide();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            marceline();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            fionna();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            fionna();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            fionna();
        }

        private void AdventureTimeOyuncakları_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
