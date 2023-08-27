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
    public partial class frmKaydol : Form
    {
        public frmKaydol()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Diyetisyen (ad,soyad,tc,sifre,telefon) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTelefon.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (txtAd.Text == "" || txtSoyad.Text == "" || mskTC.Text == "" || txtSifre.Text == "" || mskTelefon.Text == "")
            {
                MessageBox.Show("Alan boş bırakılamaz...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kayıt Yapıldı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
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
    }
}
