using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kriptografija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            string poruka=textBox1.Text;
            textBox1.Text = "";
            KriptoPoruka kp = new KriptoPoruka(poruka);
            kp.IspisiPorukuITip(label3);
            kp.KriptoDekripto();
            kp.IspisiPorukuITip(label3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 560;
            Height = 300;
            label2.Text = "Šifrovanje se vrši tako što se:\n\n* Svako slovo pomera za onoliko u desno koliko ta poruka ima karaktera(velika slova ostaju velika, a mala ostaju mala)\n* Svaka cifra se menja u ogledalu u odnosu na cifru 5 (9 postaje 1, 8 postaje 2,…5 ostaje 5)\n* Razmak postaje uzvicnik, a uzvicnik postaje razmak\n* Preostali karakteri ne menjaju";
        }
    }
}
