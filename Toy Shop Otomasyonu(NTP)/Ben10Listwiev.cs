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
    public partial class Ben10Listwiev : Form
    {
        public Ben10Listwiev()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void Ben10Listwiev_DoubleClick(object sender, EventArgs e)
        {
            
        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Satis WHERE Kategori='" + "Ben 10" + "'", bgl.baglanti());
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OyuncakYakından_inceleme f = new OyuncakYakından_inceleme();
            f.Show();
            this.Hide();
        }

        private void Ben10Listwiev_Load(object sender, EventArgs e)
        {
            goster();
            button1.Enabled= false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            CmbKategoriler f = new CmbKategoriler();
            this.Hide();
            f.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Sepet f = new Sepet();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            f.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            /*/
            if (tuna.Width >= 222)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
            /*/
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void pictureBox17_Click_1(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AnaSayfa f=new AnaSayfa();
            f.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            CmbKategoriler f = new CmbKategoriler();
            f.Show();
            this.Hide();
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            Sepet f = new Sepet();
            f.Show();
            this.Hide();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            AnaSayfa.text = listView1.SelectedItems[0].SubItems[0].Text;
            if (bgl.baglanti().State == ConnectionState.Closed) // Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Satis WHERE Text=@text", bgl.baglanti());
            komut.Parameters.AddWithValue("@text", AnaSayfa.text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                AnaSayfa.id = oku["Id"].ToString();
                AnaSayfa.text = oku["Text"].ToString();
                AnaSayfa.fiyat = oku["Fiyat"].ToString();
                AnaSayfa.urunisim = oku["Ad"].ToString();
                AnaSayfa.fotoadres = oku["Foto"].ToString();

            }

            bgl.baglanti().Close();
            pictureBox2.ImageLocation = AnaSayfa.fotoadres;
            oyuncakisim.Text = AnaSayfa.text;
            label1.Text = AnaSayfa.fiyat + " TL";
            button1.Enabled = true;
        }

        private void tuna_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = System.Windows.Forms.Application.StartupPath + "\\indir (2).png";
            AnaSayfa.id = "";
            AnaSayfa.text = "";
            AnaSayfa.fiyat = "";
            AnaSayfa.urunisim = "";
            AnaSayfa.fotoadres = "";
            oyuncakisim.Text = "";
            label1.Text = "";
            button1.Enabled = false;
        }

        private void Ben10Listwiev_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
