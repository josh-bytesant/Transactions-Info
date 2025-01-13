using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Info.Infrastructure.Data.Encryption
{
    public static class AESCryptography
    {
        static string GenerateKey()
        {
            
            return Guid.NewGuid().ToString().Replace("-", "").Substring(16).ToUpper();
        }
        static byte[] Encrypt(string plainText, string key)
        {
            byte[] encrypted;
            // Create a new AesManaged.
            using (Aes aes =  Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(key);
                byte[] iv = new byte[aes.IV.Length];
                // Create encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv);
                // Create MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream
                    // to encrypt
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] input = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(input, 0, input.Length);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data
            return encrypted;
        }
        static string Decrypt(string cipherText, string key)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            string plaintext = null;
            // Create AesManaged
            using (Aes aes =  Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(key);
                byte[] iv = new byte[aes.IV.Length];
                Array.Copy(fullCipher, 0, iv, 0, aes.IV.Length);
                // Create a decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv);
                // Create the streams used for decryption.
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(fullCipher, aes.IV.Length, fullCipher.Length -
                                aes.IV.Length);
                    }
                    plaintext = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return plaintext;
        }
    }
}
