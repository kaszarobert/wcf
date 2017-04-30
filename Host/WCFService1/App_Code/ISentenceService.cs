// 5. Készítsen el WCF segítségével egy host (IIS) és egy kliens alkalmazást. Használjon titkosítást

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface ISentenceService
{
    [OperationContract]
    string GetWordCount(string sentence, byte[] Key, byte[] IV);

    [OperationContract]
    string IsPalindrom(string sentence, byte[] Key, byte[] IV);

    [OperationContract]
    string EncodeCaesarCipher(string sentence, byte[] Key, byte[] IV);

    [OperationContract]
    string DecodeCaesarCipher(string sentence, byte[] Key, byte[] IV);

}