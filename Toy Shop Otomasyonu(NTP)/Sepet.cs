using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class Sepet : Form
    {
        public Sepet()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        SqlConnection baglanti=new SqlConnection("Data Source=\"BAB\u008dLI\\SQLEXPRESS\";Initial Catalog=\"Toy Shop Otomasyonu\";Integrated Security=True");
        public string MusteriAd;
        string isim;
        string sepettekiOyuncaklar;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tuna.Width -= 10;
            if (tuna.Width <= 66)
            {
                timer1.Stop();

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tuna.Width += 10;
            if (tuna.Width >= 222)
            {
                timer2.Stop();

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
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

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
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
        private void verilerigoster()
        {
  
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sepet", bgl.baglanti()) ;
            SqlDataReader oku=komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle=new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["sepettekioyuncaklar"].ToString()); 
                ekle.SubItems.Add(oku["sOyuncakfiyat"].ToString()); 
                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }
        void verilerigoster2()
        {
            try
            {
                string query = "SELECT SUM(sOyuncakfiyat) FROM Tbl_Sepet";

                // SqlCommand nesnesi oluşturma
                SqlCommand command = new SqlCommand(query, bgl.baglanti());
                // Verileri çekme işlemi
                int toplamFiyat = (int)command.ExecuteScalar();

                // Label'a yazdırma
                label3.Text = toplamFiyat.ToString();

                // Veritabanı bağlantısını kapatma
                bgl.baglanti().Close();

            }
            catch { 

            
            
            
            }
            










        }
        public  int sayiiiii;
        private void Sepet_Load(object sender, EventArgs e)
        {
            verilerigoster();
            verilerigoster2();
            MaximizeBox = false;
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



        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            
        }
        public double odenecektutar;
        private void ürünüSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                // Seçili olan öğeyi alın
                string selectedItem = item.Text;
                // SQL sorgusu için parametre olarak kullanmak üzere öğenin değerini alın
                // Örneğin, varsayalım ki ListView'da bir sütun "ID" ve "Name" olsun
                // Biz "ID" sütununun değerini kullanarak SQL'de kaydı belirleyebiliriz

                int selectedID = Convert.ToInt32(item.SubItems[0].Text); // 2. sütundan değeri alır
                sayiiiii = Convert.ToInt32(item.SubItems[0].Text);
                string sepettekioyuncaklar =item.SubItems[1].Text; // 2. sütundan değeri alır
                
                int sOyuncakfiyat = Convert.ToInt32(item.SubItems[2].Text); // 3. sütundan değeri alır


                // Öğeyi ListView'dan kaldırın
                listView1.Items.Remove(item);

                // SQL veritabanından öğeyi kaldırın
                // Aşağıdaki kod, öğeyi "items" adlı bir tablodan kaldırır
                string connectionString = "Data Source=VOLKAN\\SQLEXPRESS01;Initial Catalog=ToyzShop;Integrated Security=True";
                string query = "DELETE FROM Tbl_Sepet WHERE id = @id";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", selectedID);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        Console.WriteLine("SQL hatası: öğe silinemedi");
                    }
                }
            }
            verilerigoster2();

            SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Sepet", bgl.baglanti());
            int elemanSayisi = (int)command2.ExecuteScalar();
            if (elemanSayisi==0)
            {
                label3.Text = "0";
            }
            bgl.baglanti().Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int elemanSayisi = listView1.Items.Count;
           int toplampara= Convert.ToInt32(label3.Text);
            if (elemanSayisi == 0)
            {
                label3.Text = "0";
                MessageBox.Show("Sepet boş");
            }
            else
            {
                // Veritabanı bağlantısı oluşturma
                string connectionString = "Data Source=VOLKAN\\SQLEXPRESS01;Initial Catalog=ToyzShop;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Veritabanı bağlantısını açma
                    connection.Open();

                    // Sorgu yazma
                    string query = "SELECT sepettekioyuncaklar FROM Tbl_Sepet";

                    // Sorguyu veritabanına gönderme
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Verileri okuma
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verileri işleme
                            while (reader.Read())
                            {
                                 sepettekiOyuncaklar = reader.GetString(0);
                                listBox1.Items.Add(sepettekiOyuncaklar);
                            }
                        }
                    }
                }
                SqlCommand k = new SqlCommand("insert into Tbl_Satislaar (slot1,slot2,slot3,slot4,slot5,MusteriAdSoyad,Tarih,ToplamOdenilenPara) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                try
                {
                    int count = listBox1.Items.Count;
                    if (count >= 1)
                        k.Parameters.AddWithValue("@p1", listBox1.Items[0]);
                    else
                        k.Parameters.AddWithValue("@p1", DBNull.Value);

                    if (count >= 2)
                        k.Parameters.AddWithValue("@p2", listBox1.Items[1]);
                    else
                        k.Parameters.AddWithValue("@p2", DBNull.Value);

                    if (count >= 3)
                        k.Parameters.AddWithValue("@p3", listBox1.Items[2]);
                    else
                        k.Parameters.AddWithValue("@p3", DBNull.Value);

                    if (count >= 4)
                        k.Parameters.AddWithValue("@p4", listBox1.Items[3]);
                    else
                        k.Parameters.AddWithValue("@p4", DBNull.Value);

                    if (count >= 5)
                        k.Parameters.AddWithValue("@p5", listBox1.Items[4]);
                    else
                        k.Parameters.AddWithValue("@p5", DBNull.Value);
                    k.Parameters.AddWithValue("@p6",isim);
                    k.Parameters.AddWithValue("@p7",DateTime.Now);
                    k.Parameters.AddWithValue("@p8",Convert.ToInt32(label3.Text));
                    k.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listView1.Items.Clear();
                    MessageBox.Show("Siparişiniz alınmıştır. :) ");
                    label3.Text = "0";
                }
                catch (Exception)
                {
                    throw;
                }
            }

            Tool1("Grogu");
            Tool2("Grogu", "SinirliStokStarWars");
           


        }
        public string Tool1(string g)
        {
            int groguCount = 0;

            foreach (var item in listBox1.Items)
            {
                if (item.ToString() == g)
                {
                    groguCount++;
                }
            }
           
            return g;
        }
        public string Tool2(string oyuncakisimi, string tabloisimi)
        {
           
                

                SqlCommand selectCommand = new SqlCommand("SELECT " + oyuncakisimi + " FROM " + tabloisimi, bgl.baglanti());
                SqlDataReader dr = selectCommand.ExecuteReader();

                while (dr.Read())
                {
                    byte stok = (byte)dr[oyuncakisimi];
                    stok--;

                    SqlCommand updateCommand = new SqlCommand("UPDATE " + tabloisimi + " SET " + oyuncakisimi + " = @p1", bgl.baglanti());
                    updateCommand.Parameters.AddWithValue("@p1", stok);
                    updateCommand.ExecuteNonQuery();
                }

               bgl.baglanti().Close();
            

            return tabloisimi;
        }






        private void Sepet_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
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

        private void button1_Click_3(object sender, EventArgs e)
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

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Sepet f = new Sepet();
            f.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            CmbKategoriler f = new CmbKategoriler();
            f.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
