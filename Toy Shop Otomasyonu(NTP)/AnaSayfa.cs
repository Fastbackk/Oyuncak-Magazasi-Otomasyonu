using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class AnaSayfa : Form
    {


        public AnaSayfa()
        {
            InitializeComponent();
        }
        public string isim="";

        SQLbaglanti bgl = new SQLbaglanti();
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            panel10.Hide();
            goster();
            button1.Enabled = false;

            //

            
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
            if (isim == "")
            {
                pictureBox10.Hide();
                pictureBox25.Show();
            }
            else
            {
                pictureBox10.Show(); pictureBox25.Hide();
            }










            MaximizeBox = false;





            //pictureBox1.Image = Resources.starwars;
            //pictureBox4.BackColor = Color.FromArgb(79, 80, 85);
            pc1 = "starwars";


            panel3.BackColor = Color.FromArgb(241, 241, 241);



        }
        public string pc1;
        void goster()
        {

            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Satis", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Text"].ToString();
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Kategori"].ToString());
                ekle.SubItems.Add(oku["Yas"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pc1 == "starwars")
            {
                pictureBox1.Image = Resources.adv;
                pictureBox1.ImageLocation = @"C:\Users\volka\source\Workspaces\Toy Shop Otomasyonu(NTP)\Toy Shop Otomasyonu(NTP)\Resources\adv.png";
                pc1 = "adv";
                //pictureBox4.BackColor = Color.FromArgb(70, 144, 73);



            }
            else if (pc1 == "adv")
            {
                pictureBox1.ImageLocation = @"C:\Users\volka\source\Workspaces\Toy Shop Otomasyonu(NTP)\Toy Shop Otomasyonu(NTP)\Resources\starwars.jpg";
                //pictureBox1.Image = Resources.starwars;
                pc1 = "starwars";
                //.BackColor = Color.FromArgb(79, 80, 85);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void pictureBox12_Click(object sender, EventArgs e)
        {


        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {

        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*/
            tuna.Width -= 10;
            if (tuna.Width <= 66)
            {
                timer1.Stop();

            }
            /*/
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*/
            tuna.Width += 10;
            if (tuna.Width >= 222)
            {
                timer2.Stop();

            }
            /*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ben1Oyuncaklari f = new Ben1Oyuncaklari();
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
            FrozenListwiev f = new FrozenListwiev();
            
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
        public static string hatirla;
        private void AnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

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
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void pictureBox11_Click_2(object sender, EventArgs e)
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

        private void btnMenu_Click_2(object sender, EventArgs e)
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

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Sepet s = new Sepet();
            s.Show();
            this.Hide();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            CmbKategoriler f = new CmbKategoriler();
            f.Show();
            this.Hide();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            

                // SQL sorgusu
                string query = "DELETE FROM Tbl_AnlikAlisveriste";

                // SqlCommand nesnesi oluştur
                SqlCommand command = new SqlCommand(query, bgl.baglanti());

                // Sorguyu çalıştır
                command.ExecuteNonQuery();

                // Bağlantıyı kapat
                bgl.baglanti().Close();
            


            //mmw, mmh ve clr değişkenleri database'e kaydet sonrasında form load kısmında bunların verileri geri değişkenlere ata.



            // SQL sorgusu
            string query2 = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command2 = new SqlCommand(query2, bgl.baglanti());

            // Sorguyu çalıştır
            command2.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
            GirisEkrani f = new GirisEkrani();
            f.Show();
            this.Hide();
        }

        private void denetim_Tick(object sender, EventArgs e)
        {
            
        }

        private void AnaSayfa_KeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }


        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel10.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
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
            MusteriGiris f = new MusteriGiris();
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel10.Hide();
            string query = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command = new SqlCommand(query, bgl.baglanti());

            // Sorguyu çalıştır
            command.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
            SqlCommand komut = new SqlCommand("update KayitHatirla set Hatirla='"+"False"+"'",bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();







            // SQL sorgusu
            string query2 = "DELETE FROM Tbl_AnlikAlisveriste";

            // SqlCommand nesnesi oluştur
            SqlCommand command2 = new SqlCommand(query2, bgl.baglanti());

            // Sorguyu çalıştır
            command2.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
            pictureBox10.Hide();
            pictureBox25.Show();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            MusteriGiris f = new MusteriGiris();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel10.Hide();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            panel10.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            panel10.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel10.Hide();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Ben1Oyuncaklari f = new Ben1Oyuncaklari();
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

        private void button12_Click(object sender, EventArgs e)
        {
            MusteriSatisGorme f = new MusteriSatisGorme();
            f.Show();
            this.Hide();
        }

        private void btnKategoriler_Click_1(object sender, EventArgs e)
        {
            Yonetici y = new Yonetici();
            y.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static string id;
        public static string text;
        public static string urunisim;
        public static string fotoadres;
        public static string fiyat;



        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            text = listView1.SelectedItems[0].SubItems[0].Text;
            if (bgl.baglanti().State == ConnectionState.Closed) // Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Satis WHERE Text=@text", bgl.baglanti());
            komut.Parameters.AddWithValue("@text", text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                id = oku["Id"].ToString();
                text = oku["Text"].ToString();
                urunisim = oku["Ad"].ToString();
                fotoadres = oku["Foto"].ToString();
                fiyat = oku["Fiyat"].ToString();
            }

            bgl.baglanti().Close();
            pictureBox2.ImageLocation = fotoadres;
            oyuncakisim.Text = text;
            label1.Text = fiyat+" TL";
            button1.Enabled = true;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            goster();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.Show();
            this.Hide();
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            if (pc1 == "starwars")
            {
                StarWarsListwiev f = new StarWarsListwiev();
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
            else if (pc1 == "adv")
            {
                AdventureTimeListwiev f = new AdventureTimeListwiev();
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            FrozenListwiev f = new FrozenListwiev();

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

        private void pictureBox13_Click_2(object sender, EventArgs e)
        {
            Ben10Listwiev f = new Ben10Listwiev();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Hakkinda f= new Hakkinda();
           
            f.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
 
        }

        private void button14_Click(object sender, EventArgs e)
        { 

        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            CmbKategoriler f = new CmbKategoriler();
            f.Show();
            this.Hide();
        }

        private void tuna_Paint(object sender, PaintEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click_1(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = System.Windows.Forms.Application.StartupPath + "\\indir (2).png";
            id = "";
            text = "";
            fiyat = "";
            urunisim = "";
            fotoadres = "";
            oyuncakisim.Text = "";
            label1.Text = "";
            button1.Enabled = false;
        }
    }
}
