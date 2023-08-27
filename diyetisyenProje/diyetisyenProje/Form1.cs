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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = false;
            btnShow.Hide();
            btnHide.Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
            btnHide.Hide();
            btnShow.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSifremiUnuttum frm = new frmSifremiUnuttum();
            frm.Show();
            this.Hide();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Diyetisyen where tc=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmGirisAnimasyonsssss frm = new frmGirisAnimasyonsssss();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Bilgileri Hatalı...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
            txtSifre.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKaydol frm = new frmKaydol();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mskTC.Focus();
        }
        
    }
}
