// 5. Készítsen el WCF segítségével egy host (IIS) és egy kliens alkalmazást. Használjon titkosítást

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient1
{
    public partial class Form1 : Form
    {
        private ServiceReference1.SentenceServiceClient sc;

        public Form1()
        {
            InitializeComponent();
        }

        private void btWordCount_Click(object sender, EventArgs e)
        {
            txtOutput.Text = sc.GetWordCount(txtSentence.Text).ToString();
        }

        private void btIsPalindrom_Click(object sender, EventArgs e)
        {
            txtOutput.Text = (sc.IsPalindrom(txtSentence.Text)) ? "Igen" : "Nem";

        }

        private void btCaesarEncode_Click(object sender, EventArgs e)
        {
            txtOutput.Text = sc.EncodeCaesarCipher(txtSentence.Text);
        }

        private void btCaesarDecode_Click(object sender, EventArgs e)
        {
            txtOutput.Text = sc.DecodeCaesarCipher(txtSentence.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sc = new ServiceReference1.SentenceServiceClient();
            
        }
    }
}
