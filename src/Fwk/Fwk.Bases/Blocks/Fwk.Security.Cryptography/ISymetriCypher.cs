using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace Fwk.Security.Cryptography
{

    public interface ISymetriCypher
    {
        string CreateKeyFile();
        string CreateKeyFile(string keyFileName);
        string Dencrypt(string val);
        string Encrypt(string val);
        SymmetricAlgorithmProvider AlgorithmProvider { get; }
    }
}
