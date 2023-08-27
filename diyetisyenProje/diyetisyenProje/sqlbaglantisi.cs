using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace diyetisyenProje
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-G0K7707\\SQLEXPRESS;Initial Catalog=diyetisyenDemo;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
