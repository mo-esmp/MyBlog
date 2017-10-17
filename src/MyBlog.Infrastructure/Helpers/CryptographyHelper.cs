using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Infrastructure.Helpers
{
    /// <summary>
    ///  Cryptography Helper Class.
    /// </summary>
    public static class CryptographyHelper
    {
        /// <summary>
        /// Encrypts the specified key value.
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(Dictionary<string, string> keyValue)
        {
            var queryStringBytes = Encoding.UTF8.GetBytes(StringFromDictionary(keyValue));

            var encryptedBytes = EncryptBytes(queryStringBytes);
            var encryptStr = ToBase64(encryptedBytes);
            return encryptStr;
        }

        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public static Dictionary<string, string> Decrypt(string encryptedText)
        {
            var encryptedBytes = FromBase64(encryptedText);
            var decryptedBytes = DecryptBytes(encryptedBytes);
            var dictionary = DictionaryFromBytes(decryptedBytes);
            return dictionary;
        }

        #region Private methods

        /// <summary>
        /// Strings from dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>System.String.</returns>
        private static string StringFromDictionary(Dictionary<string, string> dictionary)
        {
            return string.Join("-", dictionary.Select(d => d.Key + "+" + d.Value));
        }

        /// <summary>
        /// Gets the rijndael managed.
        /// </summary>
        /// <value>The rijndael managed.</value>
        private static RijndaelManaged RijndaelManaged
        {
            get
            {
                var keyBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                var rijndaelManaged = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = 128,
                    BlockSize = 128,
                    Key = keyBytes,
                    IV = keyBytes
                };
                return rijndaelManaged;
            }
        }

        /// <summary>
        /// Encrypts the bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] EncryptBytes(byte[] bytes)
        {
            return RijndaelManaged.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Decrypts the bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] DecryptBytes(byte[] bytes)
        {
            return RijndaelManaged.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// To the base64.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        private static string ToBase64(byte[] bytes)
        {
            var strBase64 = Convert.ToBase64String(bytes);
            return strBase64.Replace('+', '-').Replace('/', '_').Replace('=', ',');
        }

        /// <summary>
        /// Froms the base64.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] FromBase64(string encryptedText)
        {
            encryptedText = encryptedText.Replace('-', '+').Replace('_', '/').Replace(',', '=');
            return Convert.FromBase64String(encryptedText);
        }

        /// <summary>
        /// Dictionaries from bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        private static Dictionary<string, string> DictionaryFromBytes(byte[] bytes)
        {
            var decryptedString = Encoding.UTF8.GetString(bytes);
            var dictionary = new Dictionary<string, string>();
            var keyValuePair = decryptedString.Split('-');

            foreach (var key in keyValuePair)
            {
                var keyValue = key.Split('+');
                dictionary.Add(keyValue[0], keyValue[1]);
            }

            return dictionary;
        }

        #endregion Private methods
    }
}