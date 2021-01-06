using System;
using System.Diagnostics;

namespace SymmetricEncryption
{
    /// <summary>
    /// Interface IDecryption
    /// has method Decrypt
    /// All classes who inherits from this class has to implement their own Decrypt method
    /// </summary>
    interface IDecryption
    {
        byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv);


    }
}