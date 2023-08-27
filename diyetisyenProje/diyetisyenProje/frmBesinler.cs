using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diyetisyenProje
{
    public partial class frmBesinler : Form
    {
        public frmBesinler()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBesinler.Items.Clear();
            if(cmbBesin.Text == "Sebzeler")
            {
                lstBesinler.Items.Add("Taze Mısır	96 kcal/100 gr");
                lstBesinler.Items.Add("Bezelye	84 kcal/100 gr");
                lstBesinler.Items.Add("Haşlanmış Patates	76 kcal/100 gr");
                lstBesinler.Items.Add("Pırasa	42 kcal/100 gr");
                lstBesinler.Items.Add("Pancar	43kcal/100 gr");
                lstBesinler.Items.Add("Havuç	42 kcal/100 gr");
                lstBesinler.Items.Add("Kereviz	40 kcal/100 gr");
                lstBesinler.Items.Add("Kuru Soğan	38 kcal/100 gr");
                lstBesinler.Items.Add("Fasülye 	32 kcal/100 gr");
                lstBesinler.Items.Add("Mantar	28 kcal/100 gr");
                lstBesinler.Items.Add("Karnabahar	27 kcal/100 gr");
                lstBesinler.Items.Add("Ispanak	26 kcal/100 gr");
                lstBesinler.Items.Add("Lahana	24 kcal/100 gr");
                lstBesinler.Items.Add("Biber	22 kcal/100 gr");
                lstBesinler.Items.Add("Domates	22 kcal/100 gr");
                lstBesinler.Items.Add("Turp	19 kcal/100 gr");
                lstBesinler.Items.Add("Salatalık	15 kcal/100 gr");
            }
            if (cmbBesin.Text == "Meyveler")
            {
                lstBesinler.Items.Add("Avokado	167 kcal/100 gr");
                lstBesinler.Items.Add("Muz	85 kcal/100 gr");
                lstBesinler.Items.Add("İncir	80 kcal/100 gr");
                lstBesinler.Items.Add("Erik	75 kcal/100 gr");
                lstBesinler.Items.Add("Kiraz	70 kcal/100 gr");
                lstBesinler.Items.Add("Üzüm	67 kcal/100 gr");
                lstBesinler.Items.Add("Armut	61 kcal/100 gr");
                lstBesinler.Items.Add("Elma	58 kcal/100 gr");
                lstBesinler.Items.Add("Vişne	58 kcal/100 gr");
                lstBesinler.Items.Add("Kayısı	51 kcal/100 gr");
                lstBesinler.Items.Add("Portakal	49 kcal/100 gr");
                lstBesinler.Items.Add("Mandalina	46 kcal/100 gr");
                lstBesinler.Items.Add("Şeftali	38 kcal/100 gr");
                lstBesinler.Items.Add("Çilek	37 kcal/100 gr");
                lstBesinler.Items.Add("Kavun	33 kcal/100 gr");
                lstBesinler.Items.Add("Limon	27 kcal/100 gr");
                lstBesinler.Items.Add("Karpuz	26 kcal/100 gr");
            }
            if (cmbBesin.Text == "Et Ürünleri")
            {
                lstBesinler.Items.Add("Domuz	513 kcal/100 gr");
                lstBesinler.Items.Add("Ördek	404 kcal/100 gr");
                lstBesinler.Items.Add("Yağlı Koyun Eti	310 kcal/100 gr");
                lstBesinler.Items.Add("Yağlı Sığır Eti	301 kcal/100 gr");
                lstBesinler.Items.Add("Kuzu Pirzola	263 kcal/100 gr");
                lstBesinler.Items.Add("Koyun Eti	246 kcal/100 gr");
                lstBesinler.Items.Add("Az Yağlı Sığır Eti	225 kcal/100 gr");
                lstBesinler.Items.Add("Dana Eti	223 kcal/100 gr");
                lstBesinler.Items.Add("Tavuk Eti	215 kcal/100 gr");
                lstBesinler.Items.Add("Hindi	160 kcal/100 gr");
            }
            if (cmbBesin.Text == "Süt Ürünleri")
            {
                lstBesinler.Items.Add("Kaşar Peyniri	404 kcal/100 gr");
                lstBesinler.Items.Add("Krem Peynir	349 kcal/100 gr");
                lstBesinler.Items.Add("Dil Peyniri	330 kcal/100 gr");
                lstBesinler.Items.Add("Beyaz Peynir	289 kcal/100 gr");
                lstBesinler.Items.Add("Tulum Peyniri	257 kcal/100 gr");
                lstBesinler.Items.Add("Krema	134 kcal/100 gr");
                lstBesinler.Items.Add("Koyun Sütü	108 kcal/100 gr");
                lstBesinler.Items.Add("Lor Peyniri	90 kcal/100 gr");
                lstBesinler.Items.Add("Yoğurt	62 kcal/100 gr");
                lstBesinler.Items.Add("İnek Sütü	61 kcal/100 gr");
                lstBesinler.Items.Add("Ayran	38 kcal/100 gr");
            }
            if (cmbBesin.Text == "Yağlar")
            {
                lstBesinler.Items.Add("Sıvı Yağlar	88 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Zeytin Yağı	88 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("İç Yağı	75 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Margarin	71 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Tereyağı	71 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Mayonez	39 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Hardal	14 kcal/10 gr(1yemek kaşığı)");
                lstBesinler.Items.Add("Ketçap	10 kcal/10 gr(1yemek kaşığı)");
            }
            if (cmbBesin.Text == "Kuru Bakliyatlar")
            {
                lstBesinler.Items.Add("Pirinç	363 kcal/10 gr");
                lstBesinler.Items.Add("Nohut	360 kcal/10 gr");
                lstBesinler.Items.Add("Fasulye	340 kcal/10 gr");
                lstBesinler.Items.Add("Mercimek	340 kcal/10 gr");
            }
            if (cmbBesin.Text == "Ekmek Grubu Besinler")
            {
                lstBesinler.Items.Add("Talaş Böreği	615 kcal/1 dilim");
                lstBesinler.Items.Add("Mısır Unu	368 kcal/100 gr");
                lstBesinler.Items.Add("Beyaz Un	365 kcal/100 gr");
                lstBesinler.Items.Add("Makarna	307 kcal/85 gr (1 Porsiyon)");
                lstBesinler.Items.Add("Yufka	257 kcal/1ad. (165 gr)");
                lstBesinler.Items.Add("Beyaz Ekmek	69 kcal/ 1 dilim (25 gr)");
                lstBesinler.Items.Add("Çavdar Ekmeği	60 kcal/1 dilim (25 gr)");
                lstBesinler.Items.Add("Kepek Ekmeği	53 kcal/1 dilim (25 gr)");
            }
            if (cmbBesin.Text == "Kuruyemiş")
            {
                lstBesinler.Items.Add("Ceviz	651 kcal/100 gr");
                lstBesinler.Items.Add("Fındık	634 kcal/100 gr");
                lstBesinler.Items.Add("Badem	598 kcal/100 gr");
                lstBesinler.Items.Add("Antep Fıstığı	594 kcal/100 gr");
                lstBesinler.Items.Add("Yer Fıstığı	582 kcal/100 gr");
                lstBesinler.Items.Add("Patlamış Mısır	386 kcal/100 gr");
                lstBesinler.Items.Add("Kavrulmuş Kestane	245 kcal/100 gr");
                lstBesinler.Items.Add("Haşlanmış Kestane	131 kcal/100 gr");
            }
            if (cmbBesin.Text == "Tatlılar")
            {
                lstBesinler.Items.Add("Çıkolatalı Pasta	431 kcal/1 dilim");
                lstBesinler.Items.Add("Bisküvi	418 kcal/100 gr");
                lstBesinler.Items.Add("Elmalı Tart	323 kcal/1 dilim");
                lstBesinler.Items.Add("Pandispanya	280 kcal/100 gr");
                lstBesinler.Items.Add("Dondurma	193 kcal/ 3 top (100 gr)");
                lstBesinler.Items.Add("Sütlü Çikolata	106 kcal/ 4 kare (20 gr)");
                lstBesinler.Items.Add("Bİtter Çikolata	95 kcal/ 4 kare (20 gr)");
                lstBesinler.Items.Add("Kakao	29 kcal/ 1 çorba kaşığı (10 gr)");
                lstBesinler.Items.Add("Bal	15 kcal/ 1 tatlı kaşığı (5 gr)");
                lstBesinler.Items.Add("Üzüm Pekmezi	14 kcal/ 1 tatlı kaşığı (5 gr)");
                lstBesinler.Items.Add("");
                lstBesinler.Items.Add("");
            }
            if (cmbBesin.Text == "İçecekler")
            {
                lstBesinler.Items.Add("Sütlü ve Şekerli Kakao	91 kcal/100 ml");
                lstBesinler.Items.Add("Kola	59 kcal/100 ml");
                lstBesinler.Items.Add("Elma Suyu	47 kcal/100 ml");
                lstBesinler.Items.Add("Meyveli Soda	46 kcal/100 ml");
                lstBesinler.Items.Add("Portakal Suyu	45 kcal/100 ml");
                lstBesinler.Items.Add("Gazlı İçecek	39 kcal/100 ml");
                lstBesinler.Items.Add("Soğuk Çay	30 kcal/100 ml");
                lstBesinler.Items.Add("Şekersiz Sade Kahve	9 kcal/100 ml");
                lstBesinler.Items.Add("Şekersiz Çay	3 kcal/100 ml");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmHastalar frm = new frmHastalar();
            frm.Show();
            this.Hide();
        }
    }
}
