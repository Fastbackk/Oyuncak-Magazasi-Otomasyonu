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
    public partial class KategoriDuzenle : Form
    {
        public KategoriDuzenle()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void KategoriDuzenle_Load(object sender, EventArgs e)
        {
            goster();
        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Kategori", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Kategori"].ToString();
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kategori(Kategori)values('" + textBox1.Text + "')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Kategori WHERE Kategori = @isim", bgl.baglanti());

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
        void temizleme()
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Kategori set Kategori='" + textBox1.Text + "'", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
