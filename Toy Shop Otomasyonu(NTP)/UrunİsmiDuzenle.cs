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
using System.Xml.Linq;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class UrunİsmiDuzenle : Form
    {
        public UrunİsmiDuzenle()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void Txtİsim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void temizleme()
        {
            textBox1.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_UrunIsmi", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["UrunIsmi"].ToString();
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        private void UrunİsmiDuzenle_Load(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("insert into Tbl_UrunIsmi(UrunIsmi)values('" + textBox1.Text + "')", bgl.baglanti());
            komut.ExecuteNonQuery();

            string isim = "";
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
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Fav(Urunİsmi,Favori,MusteriAdi)values('"+textBox1.Text+"','"+false+"','"+isim+"')", bgl.baglanti());
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_UrunIsmi WHERE UrunIsmi = @isim", bgl.baglanti());

            komut.Parameters.AddWithValue("@isim", textBox1.Text);

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
            SqlCommand komut = new SqlCommand("update Tbl_UrunIsmi set UrunIsmi='" + textBox1.Text + "'", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
