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
    public partial class Yorum_oku : Form
    {
        public Yorum_oku()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        void goster()
        {
            /*/
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("select Kullanici, Tarih, Begenme, Yorum from Tbl_Yorum where Urun=@urun", bgl.baglanti());
            komut.Parameters.AddWithValue("@urun", label1.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Kullanici"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Begenme"].ToString());
                item.SubItems.Add(dr["Yorum"].ToString());
                listView1.Items.Add(item);
            }

            dr.Close();
            bgl.baglanti().Close();
            /*/
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            string urun = label1.Text;
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Yorumm WHERE Urun=@urun AND Gizlilik='acik'", bgl.baglanti());
            komut.Parameters.AddWithValue("@urun", urun);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Kullanici"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Begenme"].ToString());
                item.SubItems.Add(dr["Yorum"].ToString());
                listView1.Items.Add(item);
            }
            dr.Close();
            bgl.baglanti().Close();

        }
        private void Yorum_oku_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goster();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urun = label1.Text;
            listView1.Items.Clear(); //listviewi temizle
            if (radioButton1.Checked==true)
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Yorumm WHERE Urun=@urun AND Gizlilik='acik' AND Begenme='Olumlu'", bgl.baglanti());
                komut.Parameters.AddWithValue("@urun", urun);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["Kullanici"].ToString());
                    item.SubItems.Add(dr["Tarih"].ToString());
                    item.SubItems.Add(dr["Begenme"].ToString());
                    item.SubItems.Add(dr["Yorum"].ToString());
                    listView1.Items.Add(item);
                }
                dr.Close();
            }
            if (radioButton2.Checked == true)
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Yorumm WHERE Urun=@urun AND Gizlilik='acik' AND Begenme='Kararsız'", bgl.baglanti());
                komut.Parameters.AddWithValue("@urun", urun);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["Kullanici"].ToString());
                    item.SubItems.Add(dr["Tarih"].ToString());
                    item.SubItems.Add(dr["Begenme"].ToString());
                    item.SubItems.Add(dr["Yorum"].ToString());
                    listView1.Items.Add(item);
                }
                dr.Close();
            }
            if (radioButton1.Checked == true)
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Yorumm WHERE Urun=@urun AND Gizlilik='acik' AND Begenme='Olumsuz'", bgl.baglanti());
                komut.Parameters.AddWithValue("@urun", urun);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["Kullanici"].ToString());
                    item.SubItems.Add(dr["Tarih"].ToString());
                    item.SubItems.Add(dr["Begenme"].ToString());
                    item.SubItems.Add(dr["Yorum"].ToString());
                    listView1.Items.Add(item);
                }
                dr.Close();
            }

            bgl.baglanti().Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OyuncakYakından_inceleme s = new OyuncakYakından_inceleme();
            s.Show();
            this.Hide();
        }

        private void Yorum_oku_FormClosing(object sender, FormClosingEventArgs e)
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
