using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Toy_Shop_Otomasyonu_NTP_
{
    public partial class YuklemeEkrani : Form
    {
        bool drag = false;
        Point startp = new Point(0, 0);
        public YuklemeEkrani()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SoundPlayer sesl = new SoundPlayer();
            string masaüstü = Application.StartupPath + "//undetale.wav";
            sesl.SoundLocation = masaüstü;
           sesl.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 5;
            if (panel1.Width >= 455)
            {
                timer1.Stop();
                GirisEkrani f2=new GirisEkrani();
                f2.Show();
                this.Hide();
         
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startp = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startp.X, p.Y - startp.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
