using System.Security.Cryptography;

namespace SymmetricEncryption
{
    /// <summary>
    /// class KeyGenerator
    /// has the purpose of returning a random generated key based on a given size
    /// classes Des, TripleDes, Aes inherits from this class.
    /// </summary>
    public class KeyGenerator
    {
        public byte[] GenerateKey(int keySize)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte [] randomNumber = new byte[keySize];

                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}