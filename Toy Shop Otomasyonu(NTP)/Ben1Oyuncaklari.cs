using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class Ben1Oyuncaklari : Form
    {
        public Ben1Oyuncaklari()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        public string isim;
        public int yuzenkanatfiyat, omnitrixfiyat, orumcekmaymunfiyat, dortkolfiyat, benkevinarabafiyat, grimaddefiyat, yabankopekfiyat, insanazorfiyat, rookfiyat;
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


        void grimadde() {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label6.Text;
            f.oyuncakfiyat.Text = label5.Text;
            f.pictureBox1.Image = pictureBox3.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 149;
            darthvaderkonum.Y = 115;
            f.urun = "grimadde";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(431, 500);
            f.sayfaisim = "ben10";
            grimaddefiyat = 80;
            f.fiyat = grimaddefiyat;
            f.Show();
            this.Hide();
        }


        void yuzenkanat()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label8.Text;
            f.oyuncakfiyat.Text = label7.Text;
            f.pictureBox1.Image = pictureBox4.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 130;
            darthvaderkonum.Y = 115;
            f.urun = "yuzenkanat";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(462, 500);
            f.sayfaisim = "ben10";
            yuzenkanatfiyat = 350;
            f.fiyat = yuzenkanatfiyat;
            f.Show();
            this.Hide();
        }
       
        private void Ben1Oyuncaklari_Load(object sender, EventArgs e)
        {
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




        void rook()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label18.Text;
            f.oyuncakfiyat.Text = label17.Text;
            f.pictureBox1.Image = pictureBox17.Image;
            f.urun = "rook";
            f.sayfaisim = "ben10";
            rookfiyat = 550;
            f.fiyat=rookfiyat;
            f.Show();
            this.Hide();
        }

        void insanazor()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text= "Ben 10 Ultimate Alien | Ultimate İnsanazor";
            f.oyuncakfiyat.Text = label15.Text;
            f.pictureBox1.Image= pictureBox16.Image;
            f.urun = "insanazor";
            f.sayfaisim = "ben10";
            insanazorfiyat = 500;
            f.fiyat = insanazorfiyat;
            f.Show();
            this.Hide();
            

        }
        public string yakindanincelemeTool2(string s1)
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.urun = s1;
            return s1;
        }
        public int yakindanincelemeTool(int s1,int s2,int s3,int s4)
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = s1;
            darthvaderkonum.Y = s2;
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(s3,s4);
            return s4;
            
            
          
        }
        
        void orumcekmaymun()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = "Ben 10 Ultimate Alien | Örümcek Maymun";
            f.oyuncakfiyat.Text = label13.Text;
            f.pictureBox1.Image = pictureBox15.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 148;
            darthvaderkonum.Y = 115;
            f.urun = "orumcekmaymun";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(411, 500);
            f.sayfaisim = "ben10";
            orumcekmaymunfiyat = 350;
            f.fiyat = orumcekmaymunfiyat;
            f.Show();
            this.Hide();
        }

        void BenarabaKevinaraba()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label10.Text;
            f.oyuncakfiyat.Text = label9.Text;
            f.pictureBox1.Image = pictureBox13.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 12;
            darthvaderkonum.Y = 115;
            f.urun = "benarabakevinaraba";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(643, 500);
            f.sayfaisim = "ben10";
            benkevinarabafiyat = 560;
            f.fiyat =benkevinarabafiyat;
            f.Show();
            this.Hide();
        }
        void yabankopek()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label4.Text;
            f.oyuncakfiyat.Text = label1.Text;
            f.pictureBox1.Image = pictureBox2.Image;
            
            f.urun = "yabankopek";
           
            f.sayfaisim = "ben10";
            yabankopekfiyat = 380;
            f.fiyat = yabankopekfiyat;
            f.Show();
            this.Hide();
        }

        void dortkol()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label12.Text;
            f.oyuncakfiyat.Text = label11.Text;
            f.pictureBox1.Image = pictureBox14.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 167;
            darthvaderkonum.Y = 115;
            f.urun = "dortkol";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(378, 500);
            f.sayfaisim = "ben10";
            dortkolfiyat = 350;
            f.fiyat = dortkolfiyat;
            f.Show();
            this.Hide();
        }


        void omnitrix()
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.oyuncakisim.Text = label2.Text;
            f.oyuncakfiyat.Text = label3.Text;
            f.pictureBox1.Image = pictureBox1.Image;
            Point darthvaderkonum = new Point();
            darthvaderkonum.X = 180;
            darthvaderkonum.Y = 115;
            f.urun = "Omnitrix";
            f.pictureBox1.Location = darthvaderkonum;
            f.pictureBox1.Size = new Size(362, 500);
            f.sayfaisim = "ben10";
            omnitrixfiyat = 250;
            f.fiyat = omnitrixfiyat;
            f.Show();
            this.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            omnitrix();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            omnitrix();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            omnitrix();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            yabankopek();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            yabankopek();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            yabankopek();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            grimadde();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            grimadde();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            grimadde();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            yuzenkanat();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            yuzenkanat();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            yuzenkanat();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            BenarabaKevinaraba();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            BenarabaKevinaraba();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            BenarabaKevinaraba();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            dortkol();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            dortkol();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dortkol();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            orumcekmaymun();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            orumcekmaymun();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            orumcekmaymun();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            insanazor();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            insanazor();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            insanazor();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            rook();
        }

        private void Ben1Oyuncaklari_FormClosing(object sender, FormClosingEventArgs e)
        {
         

           

            // SQL sorgusu
            string query = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command = new SqlCommand(query,bgl.baglanti());

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

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Sepet s=new Sepet();
            s.Show();
            this.Hide();
        }

        private void btnYardım_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            rook();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            rook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sepet s=new Sepet();
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
            }if (tuna.Width >= 222)
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
    }
}
