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
    public partial class AnlikAlisveris : Form
    {
        public AnlikAlisveris()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        private void AnlikAlisveris_Load(object sender, EventArgs e)
        {
            goster();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            goster();
        }
        void goster()
        {
            listView1.Items.Clear();
            if (bgl.baglanti().State == ConnectionState.Closed) //Bağlantı kapalıysa aç
                bgl.baglanti().Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_AnlikAlisveriste" , bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriAdi"].ToString();

                listView1.Items.Add(ekle);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici f = new Yonetici();
            f.Show();
            this.Hide();
        }
    }
}
