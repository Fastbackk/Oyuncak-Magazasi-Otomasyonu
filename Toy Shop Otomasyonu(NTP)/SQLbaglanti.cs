using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Toy_Shop_Otomasyonu_NTP_
{
    internal class SQLbaglanti
    {

        //tuna pc bağlantı Data Source=\"BAB\u008dLI\\SQLEXPRESS\";Initial Catalog=\"Toy Shop Otomasyonu\";Integrated Security=True
        //tuna laptop bağlantı Data Source=DESKTOP-OC3I572\SQLEXPRESS;Initial Catalog="Toy Shop Otomasyonu";Integrated Security=True


        public SqlConnection baglanti()
        {
            //tuna
            //SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-OC3I572\\SQLEXPRESS;Initial Catalog=\"Toy Shop Otomasyonu\";Integrated Security=True");

            //volkan
            SqlConnection baglan = new SqlConnection("Data Source=VOLKAN\\SQLEXPRESS01;Initial Catalog=ToyzShop;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
