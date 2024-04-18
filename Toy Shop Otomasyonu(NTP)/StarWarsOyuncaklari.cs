using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class StarWarsOyuncaklari : Form
    {
        public StarWarsOyuncaklari()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        public string isim;

        byte stok;
        public int bd1fiyat, obiwanfiyat, chewbaccafiyat, altınlıolanfiyat, yodafiyat, darthvaderfiyat, legofiyat, isinkilicifiyat;





      

        void babyoda()
        {

            tool("Grogu");
          

            if (stok==0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                stok = 0;
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = label2.Text;
                f.oyuncakfiyat.Text = label3.Text;
                f.pictureBox1.Image = Resources.Baby_Yoda;
                f.urun = "Grogu";
                f.sayfaisim = "starwars";
                yodafiyat = 550;
                f.fiyat = yodafiyat;
                f.Show();
                this.Hide();
            }




          
            
        }
        public string tool(string s)
        {
            SqlCommand komut = new SqlCommand("Select " + s + " From SinirliStokStarWars", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                stok = (byte)dr[s];
               


            }
            bgl.baglanti().Close();
            return s;
          
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           babyoda();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            babyoda();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            babyoda();
        }
        void darth_vader()
        {
            tool("darthvader");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = label5.Text;
                f.oyuncakfiyat.Text = label4.Text;
                f.pictureBox1.Image = Resources.darth_vader;
                Point darthvaderkonum = new Point();
                darthvaderkonum.X = 186;
                darthvaderkonum.Y = 115;
                f.urun = "Darth Vader";
                f.pictureBox1.Location = darthvaderkonum;
                f.pictureBox1.Size = new Size(335, 487);
                f.sayfaisim = "starwars";
                darthvaderfiyat = 600;
                f.fiyat = darthvaderfiyat;
                f.Show();
                this.Hide();
            }
            
        }
        private void StarWarsOyuncaklari_Load(object sender, EventArgs e)
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


        void obiwan()
        {

            tool("obivan");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = "Star Wars™ | The Black Series | Obi-Wan Kenobi";
                f.oyuncakfiyat.Text = label7.Text;
                f.pictureBox1.Image = pictureBox4.Image;
                Point darthvaderkonum = new Point();
                darthvaderkonum.X = 179;
                darthvaderkonum.Y = 115;
                f.urun = "obivan";
                f.pictureBox1.Location = darthvaderkonum;
                f.pictureBox1.Size = new Size(381, 500);
                f.Show();
                obiwanfiyat = 414;
                f.fiyat = obiwanfiyat;
                f.sayfaisim = "starwars";
                this.Hide();
            }




        }
        void altınlı()
        {
            tool("Archive C-3PO");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = label10.Text;
                f.oyuncakfiyat.Text = label9.Text;
                Point darthvaderkonum = new Point();
                darthvaderkonum.X = 159;
                darthvaderkonum.Y = 115;
                f.urun = "Archive C-3PO";
                f.pictureBox1.Location = darthvaderkonum;
                f.pictureBox1.Size = new Size(410, 500);
                f.pictureBox1.Image = pictureBox13.Image;
                f.sayfaisim = "starwars";
                altınlıolanfiyat = 310;
                f.fiyat = altınlıolanfiyat;
                f.oyuncakisim.Text = "Star Wars™ | The Black Series | Archive C-3PO";
                f.Show();
                this.Hide();
            }
           
        }
        void lego()
        {
            tool("lego");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else {


                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = "Star Wars™ | LEGO Millennium Falcon";
                f.oyuncakfiyat.Text = label1.Text;

                Point darthvaderkonum = new Point();
                darthvaderkonum.X = 186;
                darthvaderkonum.Y = 115;
                f.urun = "lego";
                f.pictureBox1.Location = darthvaderkonum;
                f.pictureBox1.Size = new Size(335, 487);
                f.pictureBox1.Image = pictureBox3.Image;
                f.sayfaisim = "starwars";
                legofiyat = 2548;
                f.fiyat = legofiyat;
                f.Show();
                this.Hide();

            }
            



        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            darth_vader();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            darth_vader();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            darth_vader();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            darth_vader();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
           label4.ForeColor = Color.White;
        }


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

        private void btnKategoriler_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lego();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            lego();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            lego();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lego();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            obiwan();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            obiwan();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            obiwan();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            obiwan();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            altınlı();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            altınlı();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            altınlı();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            altınlı();
        }
        void chewbacca()
        {
            tool("chewbacca");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = "Star Wars™ | The Black Series| Chewbacca";
                f.oyuncakfiyat.Text = label11.Text;
                Point darthvaderkonum = new Point();
                darthvaderkonum.X = 156;
                darthvaderkonum.Y = 115;
                f.urun = "chewbacca";
                f.pictureBox1.Location = darthvaderkonum;
                f.pictureBox1.Size = new Size(422, 500);
                f.pictureBox1.Image = pictureBox14.Image;
                f.sayfaisim = "starwars";
                chewbaccafiyat = 370;
                f.fiyat = chewbaccafiyat;
                f.Show();
                this.Hide();
            }
            
        }
        void isinkilici()
        {
            tool("ligthsaber");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = label14.Text;
                f.oyuncakfiyat.Text = label13.Text;

                f.urun = "lightsaber";


                f.pictureBox1.Image = pictureBox15.Image;
                f.sayfaisim = "starwars";
                isinkilicifiyat = 120;
                f.fiyat = isinkilicifiyat;
                f.Show();
                this.Hide();
            }
           
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            chewbacca();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            chewbacca();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            chewbacca();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            chewbacca();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            isinkilici();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            isinkilici();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            isinkilici();
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

        private void btnKategoriler_Click_1(object sender, EventArgs e)
        {

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            isinkilici();
        }
        void bd1()
        {
            tool("bd-1");
            if (stok == 0)
            {
                label2.Enabled = false;
                label3.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Stok Tükenmiştir...");
            }
            else
            {
                OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
                f.oyuncakisim.Text = label16.Text;
                f.oyuncakfiyat.Text = label15.Text;

                f.urun = "bd-1";


                f.pictureBox1.Image = Resources.bd_1;
                f.sayfaisim = "starwars";
                bd1fiyat = 370;
                f.fiyat = bd1fiyat;
                f.Show();
                this.Hide();
            }
         
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {
            bd1();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            bd1();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            bd1();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            bd1();
        }

        private void StarWarsOyuncaklari_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SQL sorgusu
            string query = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command = new SqlCommand(query, bgl.baglanti());

            // Sorguyu çalıştır
            command.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
        }
    }
}
