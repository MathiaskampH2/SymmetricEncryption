using System;

namespace SymmetricEncryption
{
    /// <summary>
    /// Gui class
    /// has method EncryptionOptions
    /// </summary>
    class Gui
    {
        public void EncryptionOptions()
        {
            Console.WriteLine("1. des");
            Console.WriteLine("2. Triple des");
            Console.WriteLine("3. aes");
        }
    }
}