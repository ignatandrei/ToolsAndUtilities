using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptObjects
{

    /// <summary>
    /// see for more crypt https://gist.github.com/jbtule/4336842
    /// </summary>
    public class CryptUtilitiesSimple
    {
        internal const string password = "http://msprogrammer.serviciipeweb.ro/";
        private static RijndaelManaged aesAlg;
        private static ICryptoTransform encryptor;
        private static ICryptoTransform decryptor;
        static CryptUtilitiesSimple()
        {
            var saltBytes = Encoding.ASCII.GetBytes("AndreiIgnat");
            var key = new Rfc2898DeriveBytes(password, saltBytes);

            aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
            encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            decryptor= aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        }

        public static string Encrypt(string data)
        {
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt,Encoding.UTF8))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(data);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray(), Base64FormattingOptions.None);
                }
            }
        }
        public static string Decrypt(string data)
        {
            var bytes = Convert.FromBase64String(data);
            
            using (MemoryStream msDecrypt = new MemoryStream(bytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public static string EncryptDuration(string data, int SecondDuration)
        {
            var dt = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string toEncrypt = dt + SecondDuration.ToString("00000000#") + data;
            return Encrypt(toEncrypt);
        }

        public static string DecryptDuration(string data)
        {
            var dataDecrypt = Decrypt(data);
            var dt = DateTime.ParseExact(dataDecrypt.Substring(0, 14), "yyyyMMddHHmmss", null);
            var seconds = Convert.ToInt32(dataDecrypt.Substring(14, 9));//"000000#"
            var utcNow = DateTime.UtcNow;
            var ts = utcNow.Subtract(dt);
            if (ts.TotalSeconds < seconds)
            {
                return dataDecrypt.Substring(23);
            }
            else
            {
                return null;
                
            }
        }




    }
}
