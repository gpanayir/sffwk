using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.Cryptography
{

    interface ISymetriCypher
    {
        string CreateKeyFile();
        string CreateKeyFile(string keyFileName);
        string Dencrypt(string val);
        string Encrypt(string val);
    }
}
