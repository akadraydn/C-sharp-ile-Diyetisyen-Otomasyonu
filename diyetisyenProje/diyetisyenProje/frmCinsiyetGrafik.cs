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
    public partial class frmCinsiyetGrafik : Form
    {
        public frmCinsiyetGrafik()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string erkek;
        public string kadin;
        private void frmCinsiyetGrafik_Load(object sender, EventArgs e)
        {
            erkek = txtErkek.Text;
            kadin = txtKadin.Text;
            SqlCommand komut = new SqlCommand("select count(*) from Tbl_Hastalar where cinsiyet=1", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtErkek.Text = dr[0].ToString();
            }
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Hastalar where cinsiyet=0", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                txtKadin.Text = dr2[0].ToString();
            }
            frmCinsiyetGrafik frm = new frmCinsiyetGrafik();
            frm.BackColor = Color.YellowGreen;
            float d1, d2, toplam;
            d1 = int.Parse(txtErkek.Text);
            d2 = int.Parse(txtKadin.Text);
            toplam = d1 + d2;

            float pd1, pd2;
            pd1 = (d1 / toplam) * 360;
            pd2 = (d2 / toplam) * 360;
            Pen p = new Pen(Color.White, 10);
            Graphics g = this.CreateGraphics();
            Rectangle rec = new Rectangle(txtErkek.Location.X + txtErkek.Size.Width + 10, 10, 250, 260);

            Brush b1 = new SolidBrush(Color.Blue);
            Brush b2 = new SolidBrush(Color.Pink);

            g.Clear(frmCinsiyetGrafik.DefaultBackColor);
            g.DrawPie(p, rec, 0, pd1);
            g.FillPie(b1, rec, 0, pd1);
            g.DrawPie(p, rec, pd1, pd2);
            g.FillPie(b2, rec, pd1, pd2);
            /*float d1, d2, toplam;
            d1 = int.Parse(txtErkek.Text);
            d2 = int.Parse(txtKadin.Text);
            toplam = d1 + d2;

            float pd1, pd2;
            pd1 = (d1 / toplam) * 360;
            pd2 = (d2 / toplam) * 360;
            Pen p = new Pen(Color.White,4);
            Graphics g = this.CreateGraphics();
            Rectangle rec = new Rectangle(txtErkek.Location.X + txtErkek.Size.Width + 10, 10, 250, 260);
            
            Brush b1 = new SolidBrush(Color.Blue);
            Brush b2 = new SolidBrush(Color.Pink);

            g.Clear(frmCinsiyetGrafik.DefaultBackColor);
            g.DrawPie(p, rec, 0, pd1);
            g.FillPie(b1, rec, 0, pd1);
            g.DrawPie(p, rec, pd1, pd2);
            g.FillPie(b2, rec, pd1, pd2);*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label2.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
            float d1, d2, toplam;
            d1 = int.Parse(txtErkek.Text);
            d2 = int.Parse(txtKadin.Text);
            toplam = d1 + d2;

            float pd1, pd2;
            pd1 = (d1 / toplam) * 360;
            pd2 = (d2 / toplam) * 360;
            Pen p = new Pen(Color.White, 20);
            Graphics g = this.CreateGraphics();
            Rectangle rec = new Rectangle(txtErkek.Location.X + txtErkek.Size.Width + 470, 30, 400, 390);

            Brush b1 = new SolidBrush(Color.Blue);
            Brush b2 = new SolidBrush(Color.Pink);

            g.Clear(frmCinsiyetGrafik.DefaultBackColor);
            g.DrawPie(p, rec, 0, pd1);
            g.FillPie(b1, rec, 0, pd1);
            g.DrawPie(p, rec, pd1, pd2);
            g.FillPie(b2, rec, pd1, pd2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
