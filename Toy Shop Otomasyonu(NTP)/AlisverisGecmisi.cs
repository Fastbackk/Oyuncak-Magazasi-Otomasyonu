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
    public partial class AlisverisGecmisi : Form
    {
        public AlisverisGecmisi()
        {
            InitializeComponent();
            
        }
        SQLbaglanti bgl = new SQLbaglanti();

        private void AlisverisGecmisi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'toy_Shop_OtomasyonuDataSet5.Tbl_Satislar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.tbl_SatislarTableAdapter.Fill(this.toy_Shop_OtomasyonuDataSet5.Tbl_Satislar);
            goster();

            

        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Satislaar", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Id"].ToString();
                ekle.SubItems.Add(oku["MusteriAdSoyad"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["slot1"].ToString());
                ekle.SubItems.Add(oku["slot2"].ToString());
                ekle.SubItems.Add(oku["slot3"].ToString());
                ekle.SubItems.Add(oku["slot4"].ToString());
                ekle.SubItems.Add(oku["slot5"].ToString());
                ekle.SubItems.Add(oku["ToplamOdenilenPara"].ToString());
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            goster();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = listView1.SelectedItems[0].SubItems[0].Text;
            TxtAdSoyad.Text = listView1.SelectedItems[0].SubItems[1].Text;
            DtpTarih.Text = listView1.SelectedItems[0].SubItems[2].Text;
            slt1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            slt2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            slt3.Text = listView1.SelectedItems[0].SubItems[5].Text;
            slt4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            slt5.Text = listView1.SelectedItems[0].SubItems[7].Text;
            txtTutar.Text = listView1.SelectedItems[0].SubItems[8].Text;
            


        }
        void temizleme()
        {
            TxtAdSoyad.Clear();
            slt1.Clear();
            slt2.Clear();
            slt3.Clear();   
            slt4.Clear();   
            slt5.Clear();
            txtTutar.Clear();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();

            SqlCommand komut = new SqlCommand("update Tbl_Satislaar set MusteriAdSoyad='" + TxtAdSoyad.Text + "',Tarih='" + DtpTarih.Value.ToString("yyyy-MM-dd") + "',slot1='" + slt1.Text + "',slot2='" + slt2.Text + "',slot3='" + slt3.Text + "',slot4='" + slt4.Text + "',slot5='" + slt5.Text + "',ToplamOdenilenPara='" + txtTutar.Text +"' where Id="+TxtId.Text+"", bgl.baglanti());
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();



            SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Satislaar WHERE Id = @id", bgl.baglanti());

            //SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Satislaar WHERE Id = @id AND MusteriAdSoyad = @adsoyad AND Tarih = @tarih AND Slot1 = @slot1 AND Slot2 = @slot2 AND Slot3 = @slot3 AND Slot4 = @slot4 AND Slot5 = @slot5 AND ToplamOdenilenPara = @Tutar", bgl.baglanti());
            komut.Parameters.AddWithValue("@id", TxtId.Text);
            /*/
            komut.Parameters.AddWithValue("@adsoyad", TxtAdSoyad.Text);
            komut.Parameters.AddWithValue("@tarih", DtpTarih.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@slot1", slt1.Text);
            komut.Parameters.AddWithValue("@slot2", slt2.Text);
            komut.Parameters.AddWithValue("@slot3", slt3.Text);
            komut.Parameters.AddWithValue("@slot4", slt4.Text);
            komut.Parameters.AddWithValue("@slot5", slt5.Text);
            komut.Parameters.AddWithValue("@Tutar", slt5.Text);
            /*/


            int affectedRows = komut.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                MessageBox.Show("Kayıt başarıyla silindi.");
                temizleme();
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.");
            }

            bgl.baglanti().Close();

            goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Satislaar(MusteriAdSoyad,Tarih,slot1,slot2,slot3,slot4,slot5,ToplamOdenilenPara)values('" + TxtAdSoyad.Text + "','" + DtpTarih.Value.ToString("yyyy-MM-dd") + "','"+slt1.Text+ "','"+slt2.Text+ "','"+slt3.Text+ "','"+slt4.Text+"','"+slt5.Text+ "','"+txtTutar.Text+"')", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            goster();
            temizleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Satislaar where MusteriAdSoyad like '%" + textBox8.Text + "%'", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriAdSoyad"].ToString();
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["slot1"].ToString());
                ekle.SubItems.Add(oku["slot2"].ToString());
                ekle.SubItems.Add(oku["slot3"].ToString());
                ekle.SubItems.Add(oku["slot4"].ToString());
                ekle.SubItems.Add(oku["slot5"].ToString());
                ekle.SubItems.Add(oku["ToplamOdenilenPara"].ToString());
                listView1.Items.Add(ekle);
               
            }
            bgl.baglanti().Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici y = new Yonetici();
            y.Show();
            this.Hide();
        }
    }
    
}
