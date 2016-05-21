using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization;
namespace WcfService.BLL
{
    [DataContract]
    public class PassHash
    {


        public PassHash()
        {

        }

        public string GetHashedPassword(string password)
        {
            SHA256CryptoServiceProvider shaCsp = new SHA256CryptoServiceProvider();

            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(password);

            shaCsp.ComputeHash(buffer);

            byte[] bt = shaCsp.Hash;

            StringBuilder strB = new StringBuilder();

            foreach (byte b in bt)
            {
                strB.Append(b.ToString("x2"));
            }

            return strB.ToString();
        }
    }
}