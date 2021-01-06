using System.IO;
using System.Security.Cryptography;

namespace SymmetricEncryption
{
    /// <summary>
    /// class TripleDes
    /// inherits from KeyGenerator, IDecryption and IEncryption
    /// has the purpose of making an object that can encrypt and decrypt with tripleDes encryption
    /// </summary>
    class TripleDes : KeyGenerator, IDecryption, IEncryption
    {
        public byte[] Encrypt(byte[] DataToEncrypt, byte[] key, byte[] iv)
        {
            using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Mode = CipherMode.CBC;
                tripleDes.Padding = PaddingMode.PKCS7;

                tripleDes.Key = key;
                tripleDes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(DataToEncrypt, 0, DataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] DataToDecrypt, byte[] key, byte[] iv)
        {
            using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.Mode = CipherMode.CBC;
                tripleDes.Padding = PaddingMode.PKCS7;

                tripleDes.Key = key;
                tripleDes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(DataToDecrypt, 0, DataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
}