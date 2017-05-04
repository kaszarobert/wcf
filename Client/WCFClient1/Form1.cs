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

        private void btAll_Click(object sender, EventArgs e)
        {
            try
            {
                using (AesManaged myAes = new AesManaged())
                {
                    sc = new ServiceReference1.SentenceServiceClient();
                    sc.Open();
                    string encryptedResult = "";
                    string encryptedText = "";

                    if (sender.Equals(btWordCount))
                    {
                        encryptedText = EncryptString_Aes(txtSentence.Text, myAes.Key, myAes.IV);
                        encryptedResult = sc.GetWordCount(encryptedText, myAes.Key, myAes.IV);
                    }
                    else if (sender.Equals(btReverseText))
                    {
                        encryptedText = EncryptString_Aes(txtSentence.Text, myAes.Key, myAes.IV);
                        encryptedResult = sc.getReverseText(encryptedText, myAes.Key, myAes.IV);
                    }
                    else if (sender.Equals(btIsPalindrom))
                    {
                        encryptedText = EncryptString_Aes(txtSentence.Text, myAes.Key, myAes.IV);
                        encryptedResult = sc.IsPalindrom(encryptedText, myAes.Key, myAes.IV);
                    }
                    else if (sender.Equals(btCaesarEncode))
                    {
                        encryptedText = EncryptString_Aes(txtSentence.Text, myAes.Key, myAes.IV);
                        encryptedResult = sc.EncodeCaesarCipher(encryptedText, myAes.Key, myAes.IV);
                    }
                    else if (sender.Equals(btCaesarDecode))
                    {
                        encryptedText = EncryptString_Aes(txtSentence.Text, myAes.Key, myAes.IV);
                        encryptedResult = sc.DecodeCaesarCipher(encryptedText, myAes.Key, myAes.IV);
                    }

                    txtOutput.Text = DecryptString_Aes(encryptedResult, myAes.Key, myAes.IV);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                sc.Close();
            }
            
        }

        private static string EncryptString_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // source: https://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged(v=vs.110).aspx
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                return "";
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Encoding.Default.GetString(encrypted);

        }

        private static string DecryptString_Aes(string cipherString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Encoding.Default.GetBytes(cipherString);

            // source: https://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged(v=vs.110).aspx
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                return "";
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