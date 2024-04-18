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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class YorumYonetici : Form
    {
        public YorumYonetici()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void YorumYonetici_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            TxtID.Text= listView1.SelectedItems[0].SubItems[0].Text;
            TxtKullaniciAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtUrun.Text = listView1.SelectedItems[0].SubItems[2].Text;
            DtpTarih.Text = listView1.SelectedItems[0].SubItems[3].Text;
            TxtDerece.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtGizlilik.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtYorum.Text = listView1.SelectedItems[0].SubItems[6].Text;
        }
        void goster() 
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yorumm", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Kullanici"].ToString());
                ekle.SubItems.Add(oku["Urun"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Begenme"].ToString());
                ekle.SubItems.Add(oku["Gizlilik"].ToString());
                ekle.SubItems.Add(oku["Yorum"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            goster();
        }
        void temizleme()
        {
            TxtID.Clear();
            TxtKullaniciAdi.Clear();
            TxtUrun.Clear();
            TxtDerece.Clear();
            TxtGizlilik.Clear();
            TxtYorum.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Yorumm(Kullanici,Urun,Tarih,Begenme,Gizlilik,Yorum)values('" + TxtKullaniciAdi.Text + "','" + TxtUrun.Text  + "','" + DtpTarih.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + TxtDerece.Text + "','" + TxtGizlilik.Text + "','" + TxtYorum.Text + "')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Yorumm WHERE Kullanici = @kullanici AND Urun = @urun AND Tarih = @tarih AND Begenme = @begenme AND Gizlilik = @gizlilik AND Yorum = @yorum", bgl.baglanti());

            komut.Parameters.AddWithValue("@kullanici", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@urun", TxtUrun.Text);
            komut.Parameters.AddWithValue("@tarih", DtpTarih.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            komut.Parameters.AddWithValue("@begenme", TxtDerece.Text);
            komut.Parameters.AddWithValue("@gizlilik", TxtGizlilik.Text);
            komut.Parameters.AddWithValue("@yorum", TxtYorum.Text);

            int affectedRows = komut.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                MessageBox.Show("Kayıt başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.");
            }

            bgl.baglanti().Close();

            goster();
            temizleme();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("update Tbl_Yorumm set Kullanici='" + TxtKullaniciAdi.Text + "',Urun='" + TxtUrun.Text + "',Tarih='" + DtpTarih.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',Begenme='" + TxtDerece.Text + "',Gizlilik='" + TxtGizlilik.Text + "',Yorum='" + TxtYorum.Text + "' Where id='"+TxtID.Text+"'", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yorumm where Kullanici like '%" + textBox1.Text + "%'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Kullanici"].ToString());
                ekle.SubItems.Add(oku["Urun"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Begenme"].ToString());
                ekle.SubItems.Add(oku["Gizlilik"].ToString());
                ekle.SubItems.Add(oku["Yorum"].ToString());
                listView1.Items.Add(ekle);

            }
            bgl.baglanti().Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yorumm where Urun like '%" + textBox3.Text + "%'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Kullanici"].ToString());
                ekle.SubItems.Add(oku["Urun"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Begenme"].ToString());
                ekle.SubItems.Add(oku["Gizlilik"].ToString());
                ekle.SubItems.Add(oku["Yorum"].ToString());
                listView1.Items.Add(ekle);

            }
            bgl.baglanti().Close();
        }
        string secim1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==false && radioButton3.Checked==false && radioButton2.Checked==false)
            {
                MessageBox.Show("");
            }
            else
            {
                if(radioButton1.Checked==true)
                {
                    secim1 = "Olumlu";
                }
                else if (radioButton2.Checked==true)
                {
                    secim1 = "Kararsız";
                }
                else
                {
                    secim1 = "Olumsuz";
                }
                listView1.Items.Clear();

                if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                    bgl.baglanti().Open();
                SqlCommand komut = new SqlCommand("select * from Tbl_Yorumm where Begenme like '%" + secim1 + "%'", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["id"].ToString();
                    ekle.SubItems.Add(oku["Kullanici"].ToString());
                    ekle.SubItems.Add(oku["Urun"].ToString());
                    ekle.SubItems.Add(oku["Tarih"].ToString());
                    ekle.SubItems.Add(oku["Begenme"].ToString());
                    ekle.SubItems.Add(oku["Gizlilik"].ToString());
                    ekle.SubItems.Add(oku["Yorum"].ToString());
                    listView1.Items.Add(ekle);

                }
                bgl.baglanti().Close();
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        string secim2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("");
            }
            else
            {
                if (radioButton4.Checked == true)
                {
                    secim2 = "acik";
                }
                else
                {
                    secim2 = "gizli";
                }
                listView1.Items.Clear();

                if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                    bgl.baglanti().Open();
                SqlCommand komut = new SqlCommand("select * from Tbl_Yorumm where Gizlilik like '%" + secim2 + "%'", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["id"].ToString();
                    ekle.SubItems.Add(oku["Kullanici"].ToString());
                    ekle.SubItems.Add(oku["Urun"].ToString());
                    ekle.SubItems.Add(oku["Tarih"].ToString());
                    ekle.SubItems.Add(oku["Begenme"].ToString());
                    ekle.SubItems.Add(oku["Gizlilik"].ToString());
                    ekle.SubItems.Add(oku["Yorum"].ToString());
                    listView1.Items.Add(ekle);

                }
                bgl.baglanti().Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
