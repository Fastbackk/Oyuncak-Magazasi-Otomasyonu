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
    public partial class Yorum : Form
    {
        public Yorum()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Yorum_Load(object sender, EventArgs e)
        {
            
        }
        string begenme;

        string gizlilik;
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text=="")
            {
                
                MessageBox.Show("Lütfen Bir Yorum Giriniz");
            }
            else if((radioButton1.Checked==false && radioButton2.Checked==false) ||( radioButton3.Checked==false && radioButton4.Checked==false && radioButton5.Checked==false))
            {
                MessageBox.Show("Yorumunuz Yayınlanma Şeklini Seçin");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    gizlilik = "acik";
                }
                else {
                     gizlilik = "gizli";
                }
                if (radioButton4.Checked == true) {
                    begenme = "Olumlu";
                }
                else if (radioButton3.Checked==true)
                {
                    begenme = "Olumsuz";
                }
                else
                {
                    begenme = "Kararsız";
                }
                string isim="" ;
                if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                    bgl.baglanti().Open();
                SqlCommand cmd = new SqlCommand("SELECT MusteriAdi FROM Tbl_AnlikAlisveriste", bgl.baglanti());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    isim = dr["MusteriAdi"].ToString();
                }
                bgl.baglanti().Close();

                if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                    bgl.baglanti().Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_Yorumm(Kullanici,Yorum,Urun,Tarih,Gizlilik,Begenme)values('" + isim + "','" + richTextBox1.Text + "','" + label1.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + gizlilik + "','" + begenme + "')", bgl.baglanti());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yorumunuz Gönderilmiştir");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OyuncakYakından_inceleme s = new OyuncakYakından_inceleme();
            s.Show();
            this.Hide();
        }

        private void Yorum_FormClosing(object sender, FormClosingEventArgs e)
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
