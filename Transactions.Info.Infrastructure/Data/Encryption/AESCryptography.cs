using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Encryption;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.Data.Encryption
{
    public  class AESCryptography
    {
        private readonly AccountInfoDbContext _dbContext;
 
        public AESCryptography(AccountInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private string GetOrGenerateKey(string userName)
        {
            string key = string.Empty;
            var dbResult = _dbContext.ApplicationUserKeys.FirstOrDefault(t => t.UserName == userName);
            if (dbResult == null)
            {
                key = Guid.NewGuid().ToString().Replace("-", "").Substring(16).ToUpper();
                var data = new ApplicationUserKey
                {
                    UserName = userName,
                    Key = key
                };
                _dbContext.ApplicationUserKeys.Add(data);
                _dbContext.SaveChanges();
                return key;
            }
            key = dbResult.Key;
            return key;
        }
        public string Encrypt(string plainText, string userName)
        {
            string key = GetOrGenerateKey(userName);
            byte[] encryptedBytes = null;
            // Create a new AesManaged.
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Encrypt the input plaintext using the AES algorithm
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    encryptedBytes = encryptor.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }
        public string Decrypt(string cipherText, string userName)
        {
            string key = GetOrGenerateKey(userName);
            byte[] decryptedBytes = null;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Decrypt the input ciphertext using the AES algorithm
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                }
            }
            return System.Text.Encoding.Unicode.GetString(decryptedBytes);
        }
    }
}
