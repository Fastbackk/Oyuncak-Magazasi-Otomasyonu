using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class OyuncakYakından_inceleme : Form
    {
        public OyuncakYakından_inceleme()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        public string sayfaisim;
        int groguSayisi;
        public string isim;
        public int fiyat;
        public string MusteriAd="null";
      
        private void button1_Click(object sender, EventArgs e)
        {
            
           

            if (sayfaisim=="ben10")
            {
                Ben1Oyuncaklari b = new Ben1Oyuncaklari();
                b.Show();
                this.Hide();
            }
            else if (sayfaisim=="starwars")
            {
                StarWarsOyuncaklari f = new StarWarsOyuncaklari();
                f.Show();
                this.Hide();
            }
            else if (sayfaisim == "adv")
            {
               AdventureTimeOyuncakları f = new AdventureTimeOyuncakları();
                f.Show();
                this.Hide();
            }
            else if (sayfaisim=="frozen")
            {
                FrozenOyuncakları f = new FrozenOyuncakları();
                f.Show();
                this.Hide();
            }
            else
            {
                AnaSayfa f = new AnaSayfa();
                f.Show();
                this.Hide();
            }
            
            


        }
        // ürünü  belirtir ona göre işlem yapılır mesela baby yoda ise ona göre fiyat biçilir 
        public string urun;
      
        private void OyuncakYakından_inceleme_Load(object sender, EventArgs e)
        {
            button4.Hide();
            pictureBox3.Visible = false;
            MaximizeBox = false;
            button3.Visible = false;
            pictureBox1.ImageLocation = AnaSayfa.fotoadres;
            oyuncakisim.Text = AnaSayfa.text;
            oyuncakfiyat.Text = AnaSayfa.fiyat+" TL";

            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_AnlikAlisveriste", bgl.baglanti());
            int satirSayisi = Convert.ToInt32(komut2.ExecuteScalar());
            if (satirSayisi == 0)
            {
                MusteriGiris musteriGirisFormu = new MusteriGiris();
                musteriGirisFormu.Show();
                this.Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand("SELECT MusteriAdi FROM Tbl_AnlikAlisveriste", bgl.baglanti());
                SqlDataReader dr2 = komut.ExecuteReader();
                while (dr2.Read())
                {
                    isim = dr2[0].ToString();
                }
                bgl.baglanti().Close();
            }








        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
     
        private void button2_Click(object sender, EventArgs e)
        {


            SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Sepet WHERE sepettekioyuncaklar = 'Grogu'", bgl.baglanti());
            groguSayisi = (int)command2.ExecuteScalar();
            command2.Dispose();
           




            if (groguSayisi > 0)
            {
                MessageBox.Show("Sepete bir üründen maksimum 1 tane ekleyebilirsiniz");
            }
            else
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Tbl_Sepet", bgl.baglanti());
                int elemanSayisi = (int)command.ExecuteScalar();
                if (elemanSayisi != 5)
                {
                    command = new SqlCommand("insert into Tbl_Sepet (sepettekioyuncaklar,sOyuncakfiyat) values (@p1,@p2)", bgl.baglanti());
                    command.Parameters.AddWithValue("@p1", AnaSayfa.urunisim);
                    command.Parameters.AddWithValue("@p2", AnaSayfa.fiyat);
                    command.ExecuteNonQuery();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Sepete en fazla 5 ürün ekleyebilirsiniz");
                }
                command.Dispose();
            }

            


            










        }
        int saniye = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            saniye++;
            if (saniye==3)
            {
                timer1.Stop();
                saniye = 0;
                pictureBox3.Visible = true;
                timer2.Start();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye++;
            if(saniye==2) {
                timer2.Stop();
                pictureBox3.Visible = false;
                button3.Visible = true;
                button4.Show();
            }
        }

        private void OyuncakYakından_inceleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            string hatirla = "";
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand cmd = new SqlCommand("SELECT Hatirla FROM KayitHatirla", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                hatirla = dr["Hatirla"].ToString();
            }
            bgl.baglanti().Close();
            if (hatirla == "False")
            {

                // SQL sorgusu
                string query = "DELETE FROM Tbl_AnlikAlisveriste";

                // SqlCommand nesnesi oluştur
                SqlCommand command = new SqlCommand(query, bgl.baglanti());

                // Sorguyu çalıştır
                command.ExecuteNonQuery();

                // Bağlantıyı kapat
                bgl.baglanti().Close();

            }


            //mmw, mmh ve clr değişkenleri database'e kaydet sonrasında form load kısmında bunların verileri geri değişkenlere ata.



            // SQL sorgusu
            string query2 = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command2 = new SqlCommand(query2, bgl.baglanti());

            // Sorguyu çalıştır
            command2.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yorum f = new Yorum();
            f.label1.Text = oyuncakisim.Text;
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yorum_oku f = new Yorum_oku();
            f.label1.Text=oyuncakisim.Text;
            f.Show();
            this.Hide();
        }
        bool fav = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
