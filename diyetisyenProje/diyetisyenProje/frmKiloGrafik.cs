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

namespace diyetisyenProje
{
    public partial class frmKiloGrafik : Form
    {
        public frmKiloGrafik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmKiloGrafik_Load(object sender, EventArgs e)
        {
            SqlCommand komutG1 = new SqlCommand("select kilo,count(*) from Tbl_Hastalar group by kilo", bgl.baglanti());
            SqlDataReader dr1 = komutG1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Kilo"].Points.AddXY(dr1[0], dr1[1]);
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
