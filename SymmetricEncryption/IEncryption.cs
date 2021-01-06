namespace SymmetricEncryption
{
    /// <summary>
    /// Interface IEncryption
    /// has method Encrypt
    /// All classes who inherits from this class has to implement their own Encrypt method
    /// </summary>
    interface IEncryption
    {
        byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv);
    }
}