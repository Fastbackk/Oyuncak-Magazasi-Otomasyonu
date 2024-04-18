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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void Musteriler_DoubleClick(object sender, EventArgs e)
        {
           

        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Musteriler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Eposta"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["DogumTarihiG"].ToString());
                ekle.SubItems.Add(oku["DogumTarihiA"].ToString());
                ekle.SubItems.Add(oku["DogumTarihiY"].ToString());
                ekle.SubItems.Add(oku["Sifre"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        void temizleme()
        {
            TxtId.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            TxtEposta.Clear();
            TxtTelefon.Clear();
            TxtDgun.Clear();
            TxtDay.Clear();
            TxtDyil.Clear();
            TxtSifre.Clear();
        }
        private void Musteriler_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            goster();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Musteriler(Ad,Soyad,Eposta,Telefon,DogumTarihiG,DogumTarihiA,DogumTarihiY,Sifre)values('" + TxtAd.Text + "','" + TxtSoyad.Text + "','" + TxtEposta.Text + "','" + TxtTelefon.Text + "','" + TxtDgun.Text + "','"+TxtDay.Text+"','"+TxtDyil.Text+"','"+TxtSifre.Text+"')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            TxtAd.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            TxtEposta.Text = listView1.SelectedItems[0].SubItems[3].Text;
            TxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtDgun.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtDay.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtDyil.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtSifre.Text = listView1.SelectedItems[0].SubItems[8].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Musteriler WHERE Musteriid = @id AND Ad = @ad AND Soyad = @soyad AND Eposta = @eposta AND Telefon = @tel AND DogumTarihiG = @tarihg AND DogumTarihiA = @tariha AND DogumTarihiY = @tarihy AND Sifre = @sifre", bgl.baglanti());

            komut.Parameters.AddWithValue("@id", TxtId.Text);
            komut.Parameters.AddWithValue("@ad", TxtAd.Text);
            komut.Parameters.AddWithValue("@soyad", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@eposta", TxtEposta.Text);
            komut.Parameters.AddWithValue("@tel", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@tarihg", TxtDgun.Text);
            komut.Parameters.AddWithValue("@tariha", TxtDay.Text);
            komut.Parameters.AddWithValue("@tarihy", TxtDyil.Text);
            komut.Parameters.AddWithValue("@sifre", TxtSifre.Text);

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
            
            SqlCommand komut = new SqlCommand("update Tbl_Musteriler set Ad='" + TxtAd.Text + "',Soyad='" + TxtSoyad.Text+ "',Eposta='" + TxtEposta.Text + "',Telefon='" + TxtTelefon.Text + "',DogumTarihiG='" + TxtDgun.Text + "',DogumTarihiA='" + TxtDay.Text + "',DogumTarihiY='" + TxtDyil.Text + "',Sifre='" + TxtSifre.Text + "'", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
