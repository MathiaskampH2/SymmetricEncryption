using System.IO;
using System.Security.Cryptography;

namespace SymmetricEncryption
{
    /// <summary>
    /// class Aes
    /// inherits from KeyGenerator, IDecryption and IEncryption
    /// has the purpose of making an object that can encrypt and decrypt with aes encryption
    /// </summary>
    class Aes : KeyGenerator, IDecryption, IEncryption
    {
        // method Encryption takes a byte array of data, byte array of a key and byte array of an iv
        // creates an encrypted message and returns the message in a byte array.
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            // using AesCryptoServiceProvider to make new object of aes
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // set the mode property of aes object to CBC
                aes.Mode = CipherMode.CBC;
                // set the padding property of aes object to PKCS7
                aes.Padding = PaddingMode.PKCS7;
                // sets the Key property of aes object equal to the key passed to the method
                aes.Key = key;
                // sets the iv property of aes object equal to the iv passed to the method
                aes.IV = iv;
                // using MemoryStream to make new object of memoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // create new object of CryptoStream 
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    // writes the sequence of bytes from dataToEncrypt, starts at index 0 and ends at dataToEncrypt.Length
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    // Flush the memory so that you can't find the data afterwards
                    cryptoStream.FlushFinalBlock();
                    // return the memoryStream to an array
                    return memoryStream.ToArray();
                }
            }
        }
        // method Decrypt takes a byte array of data, byte array of a key and byte array of an iv
        // Decrypts the encrypted message and returns the decrypted message in a byte array.
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            // new object of AesCryptoServiceProvider
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // sets the Mode property of aes object to CBC
                aes.Mode = CipherMode.CBC;
                // sets the Padding property of aes object to PKCS7
                aes.Padding = PaddingMode.PKCS7;
                // sets the Key property of aes object equal to the key passed to the method
                aes.Key = key;
                // sets the iv property of aes object equal to the iv passed to the method
                aes.IV = iv;

                // new object of memoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // create new object of CryptoStream 
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    // writes the sequence of bytes from dataToEncrypt, starts at index 0 and ends at dataToEncrypt.Length
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    // Flush the memory so that you can't find the data afterwards
                    cryptoStream.FlushFinalBlock();
                    // return the memoryStream to an array
                    return memoryStream.ToArray();
                }
            }
        }
    }
}