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
    public partial class frmYasGrafik : Form
    {
        public frmYasGrafik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmYasGrafik_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select yas,count(*) from Tbl_Hastalar group by yas", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Yaş"].Points.AddXY(dr[0], dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
