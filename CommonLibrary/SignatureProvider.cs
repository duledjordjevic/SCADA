using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class SignatureProvider
    {
        public static string Sign(string message, string key)
        {
            return "";
        }

        public static bool Validate(string message, string signature, string key)
        {
            return false;
        }


    }
}
