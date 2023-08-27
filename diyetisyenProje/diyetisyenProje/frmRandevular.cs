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
    public partial class frmRandevular : Form
    {
        public frmRandevular()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAnaSayfa frm = new frmAnaSayfa();
            frm.Show();
            this.Hide();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmRandevular_Load(object sender, EventArgs e)
        {
            //datagride randevuları çekme...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void cmbTekrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTekrar.Text == "Tekrar yok")
            {
                lblTekrar.Visible = false;
                cmbHafta.Visible = false;
                cmbAy.Visible = false;
                panel8.Visible = false;
            }
            if (cmbTekrar.Text == "Haftalık tekrarla")
            {
                lblTekrar.Visible = true;
                cmbHafta.Visible = true;
                panel8.Visible = true;
                cmbAy.Visible = false;
            }
            if (cmbTekrar.Text == "Aylık tekrarla")
            {
                lblTekrar.Visible = true;
                cmbHafta.Visible = false;
                cmbAy.Visible = true;
                panel8.Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            dtDate.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskSaat.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            nmrSure.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbTekrar.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            cmbHafta.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            cmbAy.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Randevu güncelleme...
            SqlCommand komut = new SqlCommand("update Tbl_Randevular set hastaAd=@p1,hastaSoyad=@p2,randevuTarih=@p3,randevuSaat=@p4,randevuSure=@p5,randevuTekrar=@p6,haftalikTekrar=@p7,aylikTekrar=@p8 where hastaTC=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", dtDate.Text);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", nmrSure.Text);
            komut.Parameters.AddWithValue("@p6", cmbTekrar.Text);
            komut.Parameters.AddWithValue("@p7", cmbHafta.Text);
            komut.Parameters.AddWithValue("@p8", cmbAy.Text);
            komut.Parameters.AddWithValue("@p9", mskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Bilgileri Güncellendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Randevu iptali...
            SqlCommand komut = new SqlCommand("delete from Tbl_Randevular where hastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu İptal Edildi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //listeyi yenileme...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Randevular where randevuTarih=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", dateTimePicker1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (dateTimePicker1.Text == dr[2].ToString())
                {
                    lblDurum.Text = "VAR";
                    linkLabel1.Visible = true;
                }
            }
            else
                lblDurum.Text = "YOK";
            bgl.baglanti().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select (hastaAd + ' ' + hastaSoyad) as 'Ad Soyad',randevuTarih,randevuSaat from Tbl_Randevular where randevuTarih='" + dateTimePicker1.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblDurum.Text = "";
            linkLabel1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
