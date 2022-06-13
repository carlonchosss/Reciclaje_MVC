using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Datos.Utilidades

{
    class Encrypt
    {
        public string Encrypt_MD5(string valor)
        {
            string hash = "¡?=)(/&%$#";
            byte[] data = UTF8Encoding.UTF8.GetBytes(valor);
            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();
            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }
        public string Decrypt_MD5(string valor)
        {
            string hash = "¡?=)(/&%$#";
            byte[] data = Convert.FromBase64String(valor);
            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();
            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
