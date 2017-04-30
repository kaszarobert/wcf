// 5. Készítsen el WCF segítségével egy host (IIS) és egy kliens alkalmazást. Használjon titkosítást

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            using (AesManaged myAes = new AesManaged())
            {
                sc = new ServiceReference1.SentenceServiceClient();

                string encryptedResult = sc.GetWordCount(txtSentence.Text, myAes.Key, myAes.IV);
                txtOutput.Text = DecryptString_Aes(encryptedResult, myAes.Key, myAes.IV);

                sc.Close();
            }
        }

        private void btIsPalindrom_Click(object sender, EventArgs e)
        {
            using (AesManaged myAes = new AesManaged())
            {
                sc = new ServiceReference1.SentenceServiceClient();

                string encryptedResult = sc.IsPalindrom(txtSentence.Text, myAes.Key, myAes.IV);
                txtOutput.Text = DecryptString_Aes(encryptedResult, myAes.Key, myAes.IV);

                sc.Close();
            }
        }

        private void btCaesarEncode_Click(object sender, EventArgs e)
        {
            using (AesManaged myAes = new AesManaged())
            {
                sc = new ServiceReference1.SentenceServiceClient();

                string encryptedResult = sc.EncodeCaesarCipher(txtSentence.Text, myAes.Key, myAes.IV);
                txtOutput.Text = DecryptString_Aes(encryptedResult, myAes.Key, myAes.IV);

                sc.Close();
            }
                
        }

        private void btCaesarDecode_Click(object sender, EventArgs e)
        {
            using (AesManaged myAes = new AesManaged())
            {
                sc = new ServiceReference1.SentenceServiceClient();

                string encryptedResult = sc.DecodeCaesarCipher(txtSentence.Text, myAes.Key, myAes.IV);
                txtOutput.Text = DecryptString_Aes(encryptedResult, myAes.Key, myAes.IV);

                sc.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private static string DecryptString_Aes(string cipherString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Encoding.Default.GetBytes(cipherString);

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }

    }
}