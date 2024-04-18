using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl=new SQLbaglanti();
        private void Form2_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminGiris f = new AdminGiris();
            //Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa f=new AnaSayfa();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GirisEkrani_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SQL sorgusu
            string query = "DELETE FROM Tbl_Sepet";

            // SqlCommand nesnesi oluştur
            SqlCommand command = new SqlCommand(query, bgl.baglanti());

            // Sorguyu çalıştır
            command.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();




            // SQL sorgusu
            string query2 = "DELETE FROM Tbl_AnlikAlisveriste";

            // SqlCommand nesnesi oluştur
            SqlCommand command2 = new SqlCommand(query2, bgl.baglanti());

            // Sorguyu çalıştır
            command2.ExecuteNonQuery();

            // Bağlantıyı kapat
            bgl.baglanti().Close();
        }
    }
}
