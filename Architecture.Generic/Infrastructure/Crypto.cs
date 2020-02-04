using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Architecture.Generic.Infrastructure
{
    public static class Crypto
    {
        private static string _key = "5ac356d1b4e34b5bf12703c38619f8a4";

        public static RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        private static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public static String Encrypt(String plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return HttpServerUtility.UrlTokenEncode(Encrypt(plainBytes, GetRijndaelManaged(_key)));
        }

        public static String Decrypt(String encryptedText)
        {
            try
            {
                var encryptedBytes = HttpServerUtility.UrlTokenDecode(encryptedText); //Convert.FromBase64String(encryptedText);
                return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(_key)));
            }
            catch
            {
                return null;
            }
        }

        public static bool IsValidBase64String(string encryptedText)
        {
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Dictionary<string, string> DecryptInKeyValue(string encryptedText)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            encryptedText = encryptedText.Replace('-', '=').Replace('_', '/').Replace(',', '+');
            string decryptedText = Decrypt(encryptedText);

            if (decryptedText != null)
            {
                string[] keyPair = decryptedText.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string key in keyPair)
                {
                    string[] keyValue = key.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    dictionary.Add(keyValue[0].ToUpper(), keyValue[1]);
                }
            }
            return dictionary;
        }

        public static string Encrypt(Dictionary<string, string> keyValue)
        {
            string encryptedText = string.Empty;

            foreach (KeyValuePair<string, string> key in keyValue)
            {
                encryptedText += key.Key + "=" + key.Value;
                encryptedText += ";";
            }
            encryptedText = Encrypt(encryptedText);
            return encryptedText.Replace('=', '-').Replace('/', '_').Replace('+', ',');
        }

        public static string Encrypt(string key, string value)
        {
            string encryptedText = key + "=" + value + ";";
            encryptedText = Encrypt(encryptedText);
            return encryptedText.Replace('=', '-').Replace('/', '_').Replace('+', ',');
        }
    }
}
