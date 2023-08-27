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
    public partial class frmYeniRandevu : Form
    {
        public frmYeniRandevu()
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
        private void frmYeniRandevu_Load(object sender, EventArgs e)
        {
            //dataGridView'e hastaları çekme...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ad,soyad,tc,telefon from Tbl_Hastalar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl9.Text;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl10.Text;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl11.Text;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl12.Text;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl13.Text;
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl14.Text;
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl15.Text;
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmYeniRandevuDetay frm = new frmYeniRandevuDetay();
            frm.tc = mskTC.Text;
            frm.tarih = dateTimePicker1.Text;
            frm.saat = lbl16.Text;
            frm.Show();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }
    }
}
