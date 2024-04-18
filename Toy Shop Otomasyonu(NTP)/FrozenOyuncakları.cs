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
    public partial class FrozenOyuncakları : Form
    {
        public FrozenOyuncakları()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        public string isim;
        public int elsafiyat, annafiyat, atlilisetfiyat, geyikfiyat, olaffiyat, kristofffiyat, frozentemalicadirfiyat, karlardiyarievifiyat;

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

        private void tuna_Paint(object sender, PaintEventArgs e)
        {

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
        void elsa()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label2.Text;
            f.oyuncakfiyat.Text = label3.Text;
            f.pictureBox1.Image = pictureBox1.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 119;
            darthvaderkonum.Y = 115;
            f.urun = "elsa";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(486, 500);
            f.sayfaisim = "frozen";
            elsafiyat = 350;
            f.fiyat = elsafiyat;
            f.Show();
            this.Hide();
        }
        
        void frozentemalicadir()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label4.Text;
            f.oyuncakfiyat.Text = label1.Text;
            f.pictureBox1.Image = pictureBox2.Image;
            f.urun = "frozentemalıçadır";  
            f.sayfaisim = "frozen";
            frozentemalicadirfiyat = 1350;
            f.fiyat = frozentemalicadirfiyat;
            f.Show();
            this.Hide();
        }
        void anna()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label6.Text;
            f.oyuncakfiyat.Text = label5.Text;
            f.pictureBox1.Image = pictureBox3.Image;
            f.pictureBox1.Location = new Point(93, 115);
            f.pictureBox1.Size = new Size(439, 500);
            f.urun = "anna";
            f.sayfaisim = "frozen";
            annafiyat = 250;
            f.fiyat = annafiyat;
            f.Show();
            this.Hide();
        }
        void kristoff()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label8.Text;
            f.oyuncakfiyat.Text = label7.Text;
            f.pictureBox1.Image = pictureBox4.Image;
            f.pictureBox1.Location = new Point(246, 115);
            f.pictureBox1.Size = new Size(210, 500);
            f.urun = "kristoff";
            f.sayfaisim = "frozen";
            kristofffiyat = 250;
            f.fiyat =kristofffiyat;
            f.Show();
            this.Hide();
        }
        void olaf()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label10.Text;
            f.oyuncakfiyat.Text = label9.Text;
            f.pictureBox1.Image = pictureBox13.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 119;
            darthvaderkonum.Y = 115;
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(486, 500);
            f.urun = "olaf";
            f.sayfaisim = "frozen";
            olaffiyat = 120;
            f.fiyat = olaffiyat;
            f.Show();
            this.Hide();
        }
        void geyik()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label12.Text;
            f.oyuncakfiyat.Text = label11.Text;
            f.pictureBox1.Image = pictureBox14.Image;
            f.pictureBox1.Location = new Point(93, 115);
            f.pictureBox1.Size = new Size(439, 500);
            f.urun = "geyik";
            f.sayfaisim = "frozen";
            geyikfiyat = 120;
            f.fiyat = geyikfiyat;
            f.Show();
            this.Hide();
        }
        void karlardiyarievi()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label14.Text;
            f.oyuncakfiyat.Text = label13.Text;
            f.pictureBox1.Image = pictureBox15.Image;
          
            f.urun = "karlardiyarıevi";
            f.sayfaisim = "frozen";
            karlardiyarievifiyat = 870;
            f.fiyat = karlardiyarievifiyat;
            f.Show();
            this.Hide();
        }
        void altılioyuncakseti()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label16.Text;
            f.oyuncakfiyat.Text = label15.Text;
            f.pictureBox1.Image = pictureBox16.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 119;
            darthvaderkonum.Y = 115;
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(486, 500);
            f.urun = "6lıoyuncakseti";
            f.sayfaisim = "frozen";
            atlilisetfiyat = 470;
            f.fiyat = atlilisetfiyat;
            f.Show();
            this.Hide();
        }
        private void FrozenOyuncakları_Load(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            elsa();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            elsa();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            elsa();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frozentemalicadir();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frozentemalicadir();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frozentemalicadir();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            anna();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            anna();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            anna();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            kristoff();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            kristoff();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            kristoff();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            olaf();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            olaf();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            olaf();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            geyik();

        }

        private void label12_Click(object sender, EventArgs e)
        {
            geyik();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            geyik();
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            karlardiyarievi();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            karlardiyarievi();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            karlardiyarievi();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            altılioyuncakseti();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            altılioyuncakseti();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            altılioyuncakseti();
        }

        private void FrozenOyuncakları_FormClosing(object sender, FormClosingEventArgs e)
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
