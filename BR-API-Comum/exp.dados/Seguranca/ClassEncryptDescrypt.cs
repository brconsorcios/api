using System;
using System.Security.Cryptography;
using System.Text;

namespace exp.dados.Seguranca
{
    /// <summary>
    ///     Classe para realizar criptografia de dados
    ///     Fonte http://www.dijksterhuis.org/encrypting-decrypting-string/
    /// </summary>
    public class ClassEncryptDescrypt
    {
        /// <summary>
        ///     Metoldo utilizado para realizar a Criptografia dos daods.
        /// </summary>
        /// <param name="Message">Mensagem a ser criptografada</param>
        /// <param name="Passphrase">Chave de criptografia</param>
        /// <returns></returns>
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below 
            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            var DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                var Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        ///     Metoldo utilizado para realizar a Descriptografia dos daods.
        /// </summary>
        /// <param name="Message">Mensagem a ser descriptografada</param>
        /// <param name="Passphrase">Chave de criptografia</param>
        /// <returns></returns>
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            var UTF8 = new UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            var HashProvider = new MD5CryptoServiceProvider();
            var TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            var TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            var DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                var Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
    }
}