using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace exp.core.Extensions
{
    public class Cryptography
    {
        public const string HashSalt = "nl6mBxhqYhaPyQxONFyS";
        private static byte[] chave = { };
        private static readonly byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        private static readonly string chaveCriptografia =
            "abcdefghijklmnopqrstuvxwyzABCDEFGHIJKLMNOPQRSTUVXWYZ12345673xP#rtu";

        //Criptografa o Cookie
        public static string Criptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs;
            byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = Encoding.UTF8.GetBytes(valor);
                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Descriptografa o cookie
        public static string Descriptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs;
            byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));

                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string sha256(string text)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text), 0, Encoding.UTF8.GetByteCount(text));
            foreach (var theByte in crypto) hash.Append(theByte.ToString("x2"));
            return hash.ToString();
        }
    }
}