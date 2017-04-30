using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public class SentenceService : ISentenceService
{
    // http://localhost:61729/SentenceService.svc

    public string GetWordCount(string sentence, byte[] Key, byte[] IV)
    {
        string decryptedSentence = DecryptString_Aes(sentence, Key, IV);

        int result = decryptedSentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        return EncryptString_Aes(result.ToString(), Key, IV);
    }

    public string getReverseText(string sentence, byte[] Key, byte[] IV)
    {
        string decryptedSentence = DecryptString_Aes(sentence, Key, IV);

        string result = getReverseString(decryptedSentence);
        return EncryptString_Aes(result, Key, IV);
    }

    public string IsPalindrom(string sentence, byte[] Key, byte[] IV)
    {
        string decryptedSentence = DecryptString_Aes(sentence, Key, IV);

        if (decryptedSentence.Length == 0)
        {
            return "";
        }
        string srcSentence = decryptedSentence.Trim().ToUpper().Replace(" ", "");
        string palindromSentence = getReverseString(srcSentence);
        string result = (String.Compare(srcSentence, palindromSentence) == 0) ? "Igen" : "Nem";
        return EncryptString_Aes(result, Key, IV);
    }

    public string DecodeCaesarCipher(string sentence, byte[] Key, byte[] IV)
    {
        string decryptedSentence = DecryptString_Aes(sentence, Key, IV);

        var sb = new StringBuilder();
        foreach (char item in decryptedSentence)
        {
            if (item >= 'a' && item <= 'z')
            {
                var code = Convert.ToInt32(item);
                // if (code < (int)'d'){ code += Convert.ToInt32('z') - Convert.ToInt32('a') + 1;}
                code += (code < (int)'d') ? 26 : 0;
                sb.AppendFormat("{0}", Convert.ToChar(code - 3));
            }
            else if (item >= 'A' && item <= 'Z')
            {
                var code = Convert.ToInt32(item);
                code += (code < (int)'D') ? 26 : 0;
                sb.AppendFormat("{0}", Convert.ToChar(code - 3));
            }
            else
            {
                sb.Append(item);
            }

        }
        return EncryptString_Aes(sb.ToString(), Key, IV);
    }

    public string EncodeCaesarCipher(string sentence, byte[] Key, byte[] IV)
    {
        string decryptedSentence = DecryptString_Aes(sentence, Key, IV);

        var sb = new StringBuilder();
        foreach (char item in decryptedSentence)
        {
            if (item >= 'a' && item <= 'z')
            {
                var code = Convert.ToInt32(item);
                // if (code >= (int)'x') {code -= Convert.ToInt32('z') - Convert.ToInt32('a') + 1;}
                code -= (code >= (int)'x') ? 26 : 0;
                sb.AppendFormat("{0}", Convert.ToChar(code + 3));
            }
            else if (item >= 'A' && item <= 'Z')
            {
                var code = Convert.ToInt32(item);
                code -= (code >= (int)'X') ? 26 : 0;
                sb.AppendFormat("{0}", Convert.ToChar(code + 3));
            }
            else
            {
                sb.Append(item);
            }

        }
        return EncryptString_Aes(sb.ToString(), Key, IV);
    }

    private string getReverseString(string s)
    {
        return new string(s.Reverse().ToArray());
    }
    
    private static string EncryptString_Aes(string plainText, byte[] Key, byte[] IV)
    {
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
