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
    public partial class frmYeniRandevuDetay : Form
    {
        public frmYeniRandevuDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        public string tarih;
        public string saat;
        private void frmYeniRandevuDetay_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            nmrSure.Value = 60;
            lblTekrar.Visible = false;
            cmbHafta.Visible = false;
            cmbAy.Visible = false;
            frmYeniRandevu fr = new frmYeniRandevu();
            lblTC.Text = tc;
            lblTarih.Text = tarih;
            lblSaat.Text = saat;
            SqlCommand komut = new SqlCommand("select ad,soyad,telefon from Tbl_Hastalar where tc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[0].ToString();
                lblSoyad.Text = dr[1].ToString();
                lblTelefon.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTekrar.Text == "Tekrar yok")
            {
                panel1.Visible = false;
                cmbAy.Visible = false;
                cmbHafta.Visible = false;
                lblTekrar.Visible = false;
                cmbAy.Text = "              -";
                cmbHafta.Text = "               -";
            }
            if (cmbTekrar.Text == "Haftalık tekrarla")
            {
                cmbHafta.Visible = true;
                cmbAy.Visible = false;
                lblTekrar.Visible = true;
                cmbAy.Text = "               -";
            }
            if (cmbTekrar.Text == "Aylık tekrarla")
            {
                cmbAy.Visible = true;
                cmbHafta.Visible = false;
                lblTekrar.Visible = true;
                cmbHafta.Text = "               -";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            //aynı güne ve saate randevu alamama...
            SqlCommand komut2 = new SqlCommand("select * from Tbl_Randevular where randevuTarih=@p1 and randevuSaat=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", lblTarih.Text);
            komut2.Parameters.AddWithValue("@p2", lblSaat.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            if (dr.Read())
            {
                if (lblTarih.Text == dr[2].ToString() && lblSaat.Text == dr[3].ToString())
                {
                    
                    if((MessageBox.Show("O gün ve saatte zaten randevu mevcut!", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)) == DialogResult.Retry)
                    {
                        this.Hide();
                    }

                }
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Randevular (hastaAd,hastaSoyad,randevuTarih,randevuSaat,randevuSure,randevuTekrar,haftalikTekrar,aylikTekrar,hastaTC) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", lblAd.Text);
                komut.Parameters.AddWithValue("@p2", lblSoyad.Text);
                komut.Parameters.AddWithValue("@p3", lblTarih.Text);
                komut.Parameters.AddWithValue("@p4", lblSaat.Text);
                komut.Parameters.AddWithValue("@p5", nmrSure.Text);
                komut.Parameters.AddWithValue("@p6", cmbTekrar.Text);
                komut.Parameters.AddWithValue("@p7", cmbHafta.Text);
                komut.Parameters.AddWithValue("@p8", cmbAy.Text);
                komut.Parameters.AddWithValue("@p9", lblTC.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevu Eklendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
