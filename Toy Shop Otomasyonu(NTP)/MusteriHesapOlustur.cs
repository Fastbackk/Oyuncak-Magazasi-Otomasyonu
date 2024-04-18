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
    public partial class MusteriHesapOlustur : Form
    {
        public MusteriHesapOlustur()
        {
            InitializeComponent();
        }
        SQLbaglanti bgl = new SQLbaglanti();
        int saniye = 0;
        int yaskriteri = 0;
        Int16 dogumg;
        string doguma;
        Int32 dogumy;
     
        private void MusteriHesapOlustur_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button2.Visible = false;


            panel2.BackColor = Color.FromArgb(185, 0, 0, 0);
        }
        void durum2()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            label1.Location = new Point(235,9);
            label2.Location = new Point(372,9);
            label3.Location = new Point(235,9);
            label4.Location = new Point(235,9);          
            comboBox2.Location = new Point(235,9);
          textBox1.Location = new Point(235,9);
            button1.Location = new Point(235, 9);










            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button2.Visible = true;
            label5.Location = new Point(182,38);
            label6.Location= new Point(103, 81);
            label7.Location = new Point(278, 81);
            label8.Location = new Point(182, 160);
            label9.Location = new Point(90, 266);
            label10.Location = new Point(278, 266);
            textBox2.Location = new Point(51, 110);
            textBox3.Location = new Point(238, 110);
            textBox4.Location = new Point(51, 189);
            textBox5.Location = new Point(51, 295);
            textBox6.Location = new Point(238, 295);
            button2.Location = new Point(105, 383);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
           
            
                timer2.Start();
            
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text)|| string.IsNullOrEmpty(textBox3.Text)||string.IsNullOrEmpty(textBox4.Text)||string.IsNullOrEmpty(textBox5.Text)||string.IsNullOrEmpty(textBox6.Text))
            {
                timer1.Start();
            }
            else
            {
                SqlCommand komut=new SqlCommand("insert into Tbl_Musteriler (Ad,Soyad,Eposta,Telefon,Sifre,DogumTarihiG,DogumTarihiA,DogumTarihiY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                komut.Parameters.AddWithValue("@p3", textBox4.Text);
                komut.Parameters.AddWithValue("@p4", textBox5.Text);
                komut.Parameters.AddWithValue("@p5", textBox6.Text);
                komut.Parameters.AddWithValue("@p6", comboBox1.Text);
                komut.Parameters.AddWithValue("@p7",comboBox2.Text);
                komut.Parameters.AddWithValue("@p8", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MusteriGiris m=new MusteriGiris();
                m.Show();
                this.Hide();

            }
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (yaskriteri!=5)
            {
                saniye++;
                if (saniye == 3)
                {
                    timer1.Stop();
                    label5.Text = "Kayıt Ol";
                    label5.ForeColor = Color.White;
                    label5.Location = new Point(182, 38);
                    saniye = 0;
                }
                else
                {
                    label5.Text = "Boş Alan Bırakmayınız!";
                    label5.ForeColor = Color.Red;
                    label5.Location = new Point(125, 32);

                }
            }
            else
            {
                saniye++;
                if (saniye == 3)
                {
                    timer1.Stop();
                    label1.Text = "Lütfen Doğum Tarihi Gir";
                    label1.Location = new Point(118, 111);
                    label1.ForeColor = Color.White;
                    saniye = 0;

                }
                else
                {
                    label1.Text = "Kayıt işlemi için 18 yaşından büyük olmalısınız!";
                    label1.Location = new Point(27, 109);
                    label1.ForeColor = Color.White;
                }
            }
                
        





    }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text)|| string.IsNullOrEmpty(comboBox2.Text)|| string.IsNullOrEmpty(textBox1.Text))
            {
                timer2.Stop();
               

            }
            else
            {
                   timer2.Stop();
                   durum2();
                dogumg = Convert.ToInt16(comboBox1.Text);
                doguma = comboBox2.Text;
                dogumy = Convert.ToInt32(textBox1.Text);
            
              
            
                
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MusteriHesapOlustur_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            AnaSayfa f = new AnaSayfa();
            f.Show();
            this.Hide();
        }
    }
}
