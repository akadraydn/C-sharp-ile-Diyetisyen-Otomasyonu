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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            btnHastaGoruntule.Visible = true;
            btnHastaDuzenle.Visible = true;
            //diğer başlıkları gizleme...
            label3.Visible = false;
            label4.Visible = false;
            btnYeniRandevu.Visible = false;
            btnRandevuDuzenle.Visible = false;

            label5.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            btnCinsiyet.Visible = false;
            btnYas.Visible = false;
            btnBoy.Visible = false;
            btnKilo.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            btnYeniRandevu.Visible = true;
            btnRandevuDuzenle.Visible = true;
            //diğer başlıkları gizleme...
            label1.Visible = false;
            label2.Visible = false;
            btnHastaGoruntule.Visible = false;
            btnHastaDuzenle.Visible = false;

            label5.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            btnCinsiyet.Visible = false;
            btnYas.Visible = false;
            btnBoy.Visible = false;
            btnKilo.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            btnCinsiyet.Visible = true;
            btnYas.Visible = true;
            btnBoy.Visible = true;
            btnKilo.Visible = true;
            //diğer başlıkları gizleme...
            label1.Visible = false;
            label2.Visible = false;
            btnHastaGoruntule.Visible = false;
            btnHastaDuzenle.Visible = false;

            label3.Visible = false;
            label4.Visible = false;
            btnYeniRandevu.Visible = false;
            btnRandevuDuzenle.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            DateTime bugun = new DateTime();
            bugun = DateTime.Today;
            lblTarih.Text = bugun.ToLongDateString();
            timer2.Start();
            
        }

        private void btnHastaGoruntule_Click(object sender, EventArgs e)
        {
            frmHastalar frm = new frmHastalar();
            frm.Show();
            this.Hide();
        }

        private void btnHastaDuzenle_Click(object sender, EventArgs e)
        {
            frmHastalar frm = new frmHastalar();
            frm.Show();
            this.Hide();
        }

        private void frmAnaSayfa_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            btnHastaGoruntule.Visible = false;
            btnHastaDuzenle.Visible = false;

            label3.Visible = false;
            label4.Visible = false;
            btnYeniRandevu.Visible = false;
            btnRandevuDuzenle.Visible = false;

            label5.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            btnCinsiyet.Visible = false;
            btnYas.Visible = false;
            btnBoy.Visible = false;
            btnKilo.Visible = false;
        }

        private void btnYeniRandevu_Click(object sender, EventArgs e)
        {
            frmYeniRandevu frm = new frmYeniRandevu();
            frm.Show();
            this.Hide();
        }

        private void btnRandevuDuzenle_Click(object sender, EventArgs e)
        {
            frmRandevular frm = new frmRandevular();
            frm.Show();
            this.Hide();
        }

        private void btnCinsiyet_Click(object sender, EventArgs e)
        {
            frmCinsiyetGrafik frm = new frmCinsiyetGrafik();
            frm.Show();
            
        }

        private void btnYas_Click(object sender, EventArgs e)
        {
            frmYasGrafik frm = new frmYasGrafik();
            frm.Show();
        }

        private void btnBoy_Click(object sender, EventArgs e)
        {
            frmBoyGrafik frm = new frmBoyGrafik();
            frm.Show();
        }

        private void btnKilo_Click(object sender, EventArgs e)
        {
            frmKiloGrafik frm = new frmKiloGrafik();
            frm.Show();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (islem == false)
            {
                this.Opacity += 0.009;
            }
            if (this.Opacity == 1.0)
            {
                islem = true;
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
