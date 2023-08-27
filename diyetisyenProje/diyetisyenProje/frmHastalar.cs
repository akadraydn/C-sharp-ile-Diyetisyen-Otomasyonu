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
    public partial class frmHastalar : Form
    {
        public frmHastalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmHastalar_Load(object sender, EventArgs e)
        {
            //datagride hastaları çekme...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Hastalar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            btnHesapla.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ana sayfaya dönme...
            frmAnaSayfa frm = new frmAnaSayfa();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Hasta kaydetme...
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (ad,soyad,tc,telefon,cinsiyet,yas,boy,kilo,bel,kalca,gogus) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", label18.Text);
            komut.Parameters.AddWithValue("@p6", txtYas.Text);
            komut.Parameters.AddWithValue("@p7", txtBoy.Text);
            komut.Parameters.AddWithValue("@p8", txtKilo.Text);
            komut.Parameters.AddWithValue("@p9", txtBel.Text);
            komut.Parameters.AddWithValue("@p10", txtKalca.Text);
            komut.Parameters.AddWithValue("@p11", txtGogus.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (txtAd.Text == "" || txtSoyad.Text == "" || mskTC.Text == "" || mskTelefon.Text == "" || txtYas.Text == "" || txtBoy.Text == "" || txtKilo.Text == "" || txtBel.Text == "" || txtKalca.Text == "" || txtGogus.Text == "")
            {
                MessageBox.Show("Alan Boş Bırakılamaz...", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Hasta Eklendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //butonu inaktif etme...
            btnKaydet.Enabled = false;
            btnTemizle.Enabled = true;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //metinleri temizleme...
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTC.Text = "";
            mskTelefon.Text = "";
            txtYas.Text = "";
            txtBoy.Text = "";
            txtKilo.Text = "";
            txtBel.Text = "";
            txtKalca.Text = "";
            txtGogus.Text = "";
            txtAd.Focus();
            rdErkek.Checked = false;
            rdKadin.Checked = false;

            //butonu aktif etme...
            btnTemizle.Enabled = false;
            btnKaydet.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Hasta bilgileri güncelleme...
            SqlCommand komut = new SqlCommand("update Tbl_Hastalar set ad=@p1,soyad=@p2,telefon=@p4,cinsiyet=@p5,yas=@p6,boy=@p7,kilo=@p8,bel=@p9,kalca=@p10,gogus=@p11 where tc=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", label18.Text);
            komut.Parameters.AddWithValue("@p6", txtYas.Text);
            komut.Parameters.AddWithValue("@p7", txtBoy.Text);
            komut.Parameters.AddWithValue("@p8", txtKilo.Text);
            komut.Parameters.AddWithValue("@p9", txtBel.Text);
            komut.Parameters.AddWithValue("@p10", txtKalca.Text);
            komut.Parameters.AddWithValue("@p11", txtGogus.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Hasta Bilgileri Güncellendi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //Hastaları listeleme...
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Hastalar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Hasta silme...
            SqlCommand komut = new SqlCommand("delete from Tbl_Hastalar where tc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            if (txtAd.Text == "" && txtSoyad.Text == "" && mskTC.Text == "" && mskTelefon.Text == "" && txtYas.Text == "" && txtBoy.Text == "" && txtKilo.Text == "" && txtBel.Text == "" && txtKalca.Text == "" && txtGogus.Text == "")
                MessageBox.Show("Önce Silmek İstediğiniz Hastayı Seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Hasta Silindi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        double boy;
        double kilo;
        double bki;
        double erkek_cal;
        double kadin_cal;
        double gunluk_kalori_ihtiyaci;
        double gunluk_alinan_kalori;
        int gun;
        void kacKilo()
        {
            gun = Convert.ToInt32(txtGun.Text);
            gunluk_alinan_kalori = Convert.ToDouble(txtAlinanKalori.Text);
            gunluk_kalori_ihtiyaci = Convert.ToDouble(lblGerekenKalori.Text);

            if (gunluk_kalori_ihtiyaci > gunluk_alinan_kalori)
            {
                kilo = (gun * (gunluk_kalori_ihtiyaci - gunluk_alinan_kalori)) / 7000;
            }
            if (gunluk_kalori_ihtiyaci < gunluk_alinan_kalori)
            {
                kilo = (gun * (gunluk_alinan_kalori - gunluk_kalori_ihtiyaci)) / 7000;
            }
            txtKiloAlVer.Text = kilo.ToString();


        }
        void kacGun()
        {
            kilo = Convert.ToDouble(txtKiloAlVer.Text);
            gunluk_alinan_kalori = Convert.ToDouble(txtAlinanKalori.Text);
            gunluk_kalori_ihtiyaci = Convert.ToDouble(lblGerekenKalori.Text);

            if (gunluk_kalori_ihtiyaci > gunluk_alinan_kalori)
            {
                gun = (int)((kilo * 7000) / (gunluk_kalori_ihtiyaci - gunluk_alinan_kalori));
                txtGun.Text = gun.ToString();
            }
            if (gunluk_kalori_ihtiyaci < gunluk_alinan_kalori)
            {
                gun = (int)((kilo * 7000) / (gunluk_alinan_kalori - gunluk_kalori_ihtiyaci));
                txtGun.Text = gun.ToString();
            }
        }

        void kacKalori()
        {
            kilo = Convert.ToDouble(txtKiloAlVer.Text);
            gun = Convert.ToInt32(txtGun.Text);
            gunluk_kalori_ihtiyaci = Convert.ToDouble(lblGerekenKalori.Text);

            gunluk_alinan_kalori = gunluk_kalori_ihtiyaci - (kilo * 7000) / gun;

            txtAlinanKalori.Text = gunluk_alinan_kalori.ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTemizle.Enabled = true;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTelefon.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label18.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtYas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtBoy.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtKilo.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtBel.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtKalca.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txtGogus.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            boy = Convert.ToDouble(txtBoy.Text);
            kilo = Convert.ToDouble(txtKilo.Text);
            bki = kilo / (boy * boy);
            txtBKI.Text = bki.ToString();
            if (bki < 18.5)
                lblBKI.Text = "(Düşük Kilolu)";
            else if (18.5 <= bki && bki <= 24.9)
                lblBKI.Text = "(Normal Kilolu)";
            else if (25 <= bki && bki <= 29.9)
                lblBKI.Text = "(Aşırı Kilolu)";
            else if (30 <= bki && bki <= 34.9)
                lblBKI.Text = "(1. Derece Obez)";
            else if (35 <= bki && bki <= 39.9)
                lblBKI.Text = "(2. Derece Obez)";
            else
                lblBKI.Text = "(3. Derece Obez(morbid obez)";

            kadin_cal = 655 + 9.6 * Convert.ToDouble(txtKilo.Text) + 1.8 * (Convert.ToDouble(txtBoy.Text) * 100) - 4.7 * Convert.ToDouble(txtYas.Text);
            erkek_cal = 66 + 13.7 * Convert.ToDouble(txtKilo.Text) + 5 * (Convert.ToDouble(txtBoy.Text) * 100) - 6.8 * Convert.ToDouble(txtYas.Text);
            if (label18.Text == "True")
                lblGerekenKalori.Text = erkek_cal.ToString();
            if (label18.Text == "False")
                lblGerekenKalori.Text = kadin_cal.ToString();
        }

        private void rdErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdErkek.Checked == true)
            {
                label18.Text = "True";
            }
        }

        private void rdKadin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKadin.Checked == true)
            {
                label18.Text = "False";
            }
        }

        private void label18_TextChanged(object sender, EventArgs e)
        {
            if (label18.Text == "True")
            {
                rdErkek.Checked = true;
            }
            if (label18.Text == "False")
            {
                rdKadin.Checked = true;
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //kalori-kilo-gün hesabı...
            if (txtKiloAlVer.Text == "")
            {
                kacKilo();
            }

            if (txtGun.Text == "")
            {
                kacGun();
            }

            if (txtAlinanKalori.Text == "")
            {
                kacKalori();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //kalori-gün-kilo metinlerini temizleme...
            txtKiloAlVer.Text = "";
            txtAlinanKalori.Text = "";
            txtGun.Text = "";
            txtGun.Focus();
        }
        //en az iki metin girili olması durumunda butonu aktif etme metodu...
        void butonAktif()
        {
            if ((txtGun.Text == "" && txtKiloAlVer.Text == "") || (txtGun.Text == "" && txtAlinanKalori.Text == "") || (txtKiloAlVer.Text == "" && txtAlinanKalori.Text == ""))
            {
                btnHesapla.Enabled = false;
            }
            else
            {
                btnHesapla.Enabled = true;
            }
        }

        private void txtGun_TextChanged(object sender, EventArgs e)
        {
            butonAktif();
        }

        private void txtKiloAlVer_TextChanged(object sender, EventArgs e)
        {
            butonAktif();
        }

        private void txtAlinanKalori_TextChanged(object sender, EventArgs e)
        {
            butonAktif();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmYararliBilgiler frm = new frmYararliBilgiler();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmBesinler frm = new frmBesinler();
            frm.Show();
            this.Hide();
        }
    }
}
