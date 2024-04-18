using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toy_Shop_Otomasyonu_NTP_.Properties;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class SatisEkkle : Form
    {
        public SatisEkkle()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void SatisEkkle_Load(object sender, EventArgs e)
        {
            goster();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Kategori", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbKategori.Items.Add(oku["Kategori"].ToString());
            }
            bgl.baglanti().Close();


            //

            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut2 = new SqlCommand("select * from Tbl_UrunIsmi", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                Txtİsim.Items.Add(oku2["UrunIsmi"].ToString());
            }
            bgl.baglanti().Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Sadece resim dosyalarını filtrele
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            openFileDialog.Title = "Resources2 Klasöründen Fotoğraf Seç";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın konumunu metin kutusuna ata
                richTextBox1.Text = openFileDialog.FileName;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            TxtText.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            Txtİsim.Text = listView1.SelectedItems[0].SubItems[3].Text;
            richTextBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            CmbKategori.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtYas.Text = listView1.SelectedItems[0].SubItems[6].Text;
        }
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
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["Text"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());

                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Foto"].ToString());
                ekle.SubItems.Add(oku["Kategori"].ToString());
                ekle.SubItems.Add(oku["Yas"].ToString());

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
            TxtId.Clear();
            TxtText.Clear();
            TxtYas.Text = "";
            Txtİsim.Text="";
            CmbKategori.Text = "";
            richTextBox1.Clear();
            textBox1.Clear();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Satis(Text,Ad,Foto,Kategori,Yas,Fiyat)values('" + TxtText.Text + "','" + Txtİsim.Text+ "','" + richTextBox1.Text + "','" + CmbKategori.Text + "','" + TxtYas.Text + "','"+textBox1.Text+"')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("update Tbl_Satis set Text='" + TxtText.Text + "',Ad='" + Txtİsim.Text + "',Fiyat='"+textBox1.Text+"',Foto='" + richTextBox1.Text + "',Kategori='" + CmbKategori.Text + "',Yas='" + TxtYas.Text + "' where Id='"+TxtId.Text+"'", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Satis WHERE Id = @id AND Text = @text AND Ad = @isim AND Foto = @foto AND Kategori = @kategori AND Yas = @yas", bgl.baglanti());

            komut.Parameters.AddWithValue("@id", TxtId.Text);
            komut.Parameters.AddWithValue("@text", TxtText.Text);
            komut.Parameters.AddWithValue("@isim", Txtİsim.Text);
            komut.Parameters.AddWithValue("@foto", richTextBox1.Text);
            komut.Parameters.AddWithValue("@kategori", CmbKategori.Text);
            komut.Parameters.AddWithValue("@yas", TxtYas.Text);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
