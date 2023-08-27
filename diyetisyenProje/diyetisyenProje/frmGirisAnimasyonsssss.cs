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
    public partial class frmGirisAnimasyonsssss : Form
    {
        public frmGirisAnimasyonsssss()
        {
            InitializeComponent();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (islem == false)
            {
                Opacity += 0.009;
            }
            if (this.Opacity == 1.0)
            {
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.009;
                if (this.Opacity == 0)
                {
                    Form1 fr = new Form1();
                    fr.Hide();
                    frmAnaSayfa frm = new frmAnaSayfa();
                    frm.Show();
                    timer1.Enabled = false;
                }
            }
        }

        private void frmGirisAnimasyonsssss_Load(object sender, EventArgs e)
        {

        }
    }
}
