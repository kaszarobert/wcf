using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class SentenceService : ISentenceService
{
    public int GetWordCount(string sentence)
    {
        return sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public bool IsPalindrom(string sentence)
    {
        string srcSentence = sentence.Trim().ToUpper().Replace(" ", "");
        string palindromSentence = "";

        for (int i = 0; i < srcSentence.Length; i++)
        {
            palindromSentence = srcSentence[i] + palindromSentence;
        }

        return String.Compare(srcSentence, palindromSentence) == 0;
    }

    public string DecodeCaesarCipher(string sentence)
    {
        var sb = new StringBuilder();
        foreach (char item in sentence)
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
        return sb.ToString();
    }

    public string EncodeCaesarCipher(string sentence)
    {
        var sb = new StringBuilder();
        foreach (char item in sentence)
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
        return sb.ToString();
    }
}
