using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
    class Program
    {
        // stopWatches to be used when runnig encrypt or decrypt method
        static Stopwatch swEncrypt = new Stopwatch();
        static Stopwatch swDecrypt = new Stopwatch();

        static void Main(string[] args)
        {
            bool start = false;
            Gui gui = new Gui();

            while (!start)
            {
                gui.EncryptionOptions();
                int userInput = int.Parse(Console.ReadLine());
                // switch on userinput if the user wants des tripleDes or aes encryption
                switch (userInput)
                {
                    // case 1 des
                    case 1:
                        // new object of Des
                        Des des = new Des();
                        Console.Clear();
                        // creating maximum size of a key when using des
                        byte[] key = des.GenerateKey(8);
                        // creating maximum size of an iv when using des
                        byte[] iv = des.GenerateKey(8);
                        Console.WriteLine("generating key and iv...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("key : " + Convert.ToBase64String(key));
                        Console.WriteLine("iv  : " + Convert.ToBase64String(iv));
                        Console.Write("Enter text to be encrypted :");
                        string desPlainText = Console.ReadLine();
                        swEncrypt.Start();
                        byte[] desEncrypted = des.Encrypt(Encoding.UTF8.GetBytes(desPlainText), key, iv);
                        swEncrypt.Stop();
                        swDecrypt.Start();
                        byte[] desDecrypted = des.Decrypt(desEncrypted, key, iv);
                        swDecrypt.Stop();
                        string desDecryptedMessage = Encoding.UTF8.GetString(desEncrypted);
                        Console.WriteLine("Encrypting text");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("your text has been encrypted");
                        Console.WriteLine("Original text : " + desPlainText);
                        Console.WriteLine("Encrypted text : " + Convert.ToBase64String(desEncrypted) + "\n" + "it took :" + swEncrypt.Elapsed.TotalMilliseconds + " ms. to encrypt");
                        Console.Write("1. to decrypt message :");
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput == 1)
                        {
                            Console.WriteLine("Decrypted message : " + desDecryptedMessage + "\n" + "it took :" + swDecrypt.Elapsed.TotalMilliseconds + " ms. to decrypt");
                        }

                        Thread.Sleep(5000);
                        swDecrypt.Reset();
                        swEncrypt.Reset();
                        Console.Clear();
                        break;
                    // case 2 triple des
                    case 2:
                        // new object of tripleDes
                        TripleDes tripleDes = new TripleDes();
                        Console.Clear();
                        // creating the maximum value of a key when using triple des
                        byte[] tripleDesKey = tripleDes.GenerateKey(16);
                        // creating the maximum value of an iv when using triple des
                        byte[] tripleDesIv = tripleDes.GenerateKey(8);
                        Console.WriteLine("generating key and iv...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("key : " + Convert.ToBase64String(tripleDesKey));
                        Console.WriteLine("iv  : " + Convert.ToBase64String(tripleDesIv));
                        Console.Write("Enter text to be encrypted :");
                        string tripleDesPlainText = Console.ReadLine();
                        swEncrypt.Start();
                        byte[] tripleDesEncrypted = tripleDes.Encrypt(Encoding.UTF8.GetBytes(tripleDesPlainText),
                            tripleDesKey, tripleDesIv);
                        swEncrypt.Stop();
                        swDecrypt.Start();
                        byte[] tripleDesDecrypted = tripleDes.Decrypt(tripleDesEncrypted, tripleDesKey, tripleDesIv);
                        swDecrypt.Stop();
                        string tripleDesDecryptedMessage = Encoding.UTF8.GetString(tripleDesDecrypted);
                        Console.WriteLine("Encrypting text");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("your text has been encrypted");
                        Console.WriteLine("Original text : " + tripleDesPlainText);
                        Console.WriteLine("Encrypted text : " + Convert.ToBase64String(tripleDesEncrypted) + "\n" + "it took :" + swEncrypt.Elapsed.TotalMilliseconds + " ms. to encrypt");
                        Console.Write("1. to decrypt message :");
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput == 1)
                        {
                            Console.WriteLine("Decrypted message : " + tripleDesDecryptedMessage + "\n" + "it took :" + swDecrypt.Elapsed.TotalMilliseconds + " ms. to decrypt");
                        }

                        Thread.Sleep(5000);
                        swDecrypt.Reset();
                        swEncrypt.Reset();
                        Console.Clear();

                        break;
                    // case 3 aes 
                    case 3:
                        // new object of Aes
                        Aes aes = new Aes();
                        Console.Clear();
                        // creating the maximum value of a key when using aes
                        byte[] aesKey = aes.GenerateKey(32);
                        // creating the maximum value of an iv when using aes
                        byte[] aesIv = aes.GenerateKey(16);
                        Console.WriteLine("generating key and iv...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("key : " + Convert.ToBase64String(aesKey));
                        Console.WriteLine("iv  : " + Convert.ToBase64String(aesIv));
                        Console.Write("Enter text to be encrypted :");
                        string aesPlainText = Console.ReadLine();
                        swEncrypt.Start();
                        byte[] aesEncrypted = aes.Encrypt(Encoding.UTF8.GetBytes(aesPlainText), aesKey, aesIv);
                        swEncrypt.Stop();
                        swDecrypt.Start();
                        byte[] aesDecrypted = aes.Decrypt(aesEncrypted, aesKey, aesIv);
                        swDecrypt.Stop();
                        string aesDecryptedMessage = Encoding.UTF8.GetString(aesDecrypted);
                        Console.WriteLine("Encrypting text");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("your text has been encrypted");
                        Console.WriteLine("Original text : " + aesPlainText);
                        Console.WriteLine("Encrypted text : " + Convert.ToBase64String(aesEncrypted) + "\n" + "it took :" + swEncrypt.Elapsed.TotalMilliseconds + " ms. to encrypt");
                        Console.Write("1. to decrypt message :");
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput == 1)
                        {
                            Console.WriteLine("Decrypted message : " + aesDecryptedMessage + "\n" + "it took :" + swDecrypt.Elapsed.TotalMilliseconds + " ms. to decrypt");
                        }

                        Thread.Sleep(5000);
                        swDecrypt.Reset();
                        swEncrypt.Reset();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("bye");
                        start = true;
                        break;
                }
            }
        }
    }
}