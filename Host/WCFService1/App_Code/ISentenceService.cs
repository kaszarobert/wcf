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
    int GetWordCount(string sentence);

    [OperationContract]
	bool IsPalindrom(string sentence);

    [OperationContract]
    string EncodeCaesarCipher(string sentence);

    [OperationContract]
    string DecodeCaesarCipher(string sentence);

}