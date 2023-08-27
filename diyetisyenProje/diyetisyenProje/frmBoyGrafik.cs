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
    public partial class frmBoyGrafik : Form
    {
        public frmBoyGrafik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmBoyGrafik_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select boy,count(*) from Tbl_Hastalar group by boy", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Boy"].Points.AddXY(dr[0], dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
