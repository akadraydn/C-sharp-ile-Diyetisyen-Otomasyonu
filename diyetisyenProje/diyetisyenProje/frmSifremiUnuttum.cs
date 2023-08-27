using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace diyetisyenProje
{
    public partial class frmSifremiUnuttum : Form
    {
        public frmSifremiUnuttum()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        string onaykodu;
        void mailGonder()
        {
            onaykodu = rnd.Next(1000, 10000).ToString(); //gönderilecek onay kodu...
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient(); //smtp: simple mail transfer protocol...
            istemci.Credentials = new System.Net.NetworkCredential(txtEposta.Text, txtSifre.Text); //credentials = kimlik bilgileri...
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true; // SSL: secure socket layer(güvenli giriş katmanı)
            mesaj.To.Add(txtEposta.Text);
            mesaj.From = new MailAddress("kadr.aydnn0725@gmail.com", "Kadir.0725");
            mesaj.Subject = "Onay Kodu";
            mesaj.Body = onaykodu;
            istemci.Send(mesaj);
            MessageBox.Show("Onay Kodu E-Posta Adresinize Gönderildi...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void CAPCTCHA()
        {
            string[] k_harf = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "y", "z", "x", "q", "w" };
            string[] b_harf = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z", "Q", "W", "X" };
            int s1, s2, s3, s4, s5, s6;
            s1 = rnd.Next(0, k_harf.Length);
            s2 = rnd.Next(0, b_harf.Length);
            s3 = rnd.Next(0, 10);
            s4 = rnd.Next(0, k_harf.Length);
            s5 = rnd.Next(0, b_harf.Length);
            s6 = rnd.Next(0, 10);
            rchCaptcha.Text = k_harf[s1].ToString() + s3.ToString() + b_harf[s2].ToString() + k_harf[s4].ToString() + s6.ToString() + b_harf[s5].ToString();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            CAPCTCHA();
            txtCaptcha.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rchCaptcha.Text == txtCaptcha.Text)
            {
                mailGonder();
            }
            else
            {
                MessageBox.Show("CAPTCHA Yanlış Girildi...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSifremiUnuttum_Load(object sender, EventArgs e)
        {
            CAPCTCHA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtOnayKodu.Text == onaykodu)
            {
                Form1 fr = new Form1();
                frmGirisAnimasyonsssss frm = new frmGirisAnimasyonsssss();
                frm.Show();
                fr.Hide();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Onay Kodu...", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
