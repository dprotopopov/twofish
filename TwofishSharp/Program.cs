using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Medo.Security.Cryptography;

namespace TwofishSharp
{
    internal class Program
    {
        private static byte[] ParseHex(string s)
        {
            var list = new List<byte>();
            if ((s.Length & 1) == 1) s += '0';
            for (var i = 0; i < s.Length; i += 2)
            {
                var c = s.Substring(i, 2);
                var b = byte.Parse(c, NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                list.Add(b);
            }
            return list.ToArray();
        }

        // Consume them
        private static void Main(string[] args)
        {
            var dir = TwofishManagedTransformMode.Encrypt;
            var mode = CipherMode.ECB;
            var keysize = 128;
            var key = ParseHex("00000000000000000000000000000000");
            var iv = ParseHex("00000000000000000000000000000000");
            var inputFilename = "input.txt";
            var outputFilename = "output.txt";
            var bufferSize = 1024;
            for (var i = 0; i < args.Length; i++)
                if (args[i] == "--keysize") keysize = Convert.ToInt16(args[++i]);
                else if (args[i] == "--encrypt") dir = TwofishManagedTransformMode.Encrypt;
                else if (args[i] == "--decrypt") dir = TwofishManagedTransformMode.Decrypt;
                else if (args[i] == "--buffer") bufferSize = Convert.ToInt32(args[++i]);
                else if (args[i] == "--mode")
                {
                    i++;
                    if (args[i] == "ecb") mode = CipherMode.ECB;
                    else if (args[i] == "cbc") mode = CipherMode.CBC;
                }
                else if (args[i] == "--input") inputFilename = args[++i];
                else if (args[i] == "--output") outputFilename = args[++i];
                else if (args[i] == "--key") key = ParseHex(args[++i]);
                else if (args[i] == "--iv") iv = ParseHex(args[++i]);

            //if (dir == TwofishManagedTransformMode.Encrypt) Console.WriteLine("Encrypting...");
            //if (dir == TwofishManagedTransformMode.Decrypt) Console.WriteLine("Decrypting...");

            using (var twofish = new TwofishManaged
            {
                KeySize = keysize,
                Mode = mode,
                Padding = PaddingMode.None
            })
            using (var transform = twofish.NewEncryptor(key, mode, iv, dir))
            using (var reader = new BinaryReader(File.Open(inputFilename, FileMode.Open)))
            using (var writer = new BinaryWriter(File.Open(outputFilename, FileMode.Create)))
            {
                var t = DateTime.Now;
                long total = 0;
                for (var inputBuffer = reader.ReadBytes(bufferSize*16);
                    inputBuffer.Length > 0;
                    inputBuffer = reader.ReadBytes(bufferSize*16))
                {
                    Array.Resize(ref inputBuffer, (inputBuffer.Length + 15) & ~15);
                    var outputBuffer = new byte[inputBuffer.Length];
                    if (mode == CipherMode.ECB)
                    {
                        Parallel.For(0, inputBuffer.Length/16,
                            i => { transform.TransformBlock(inputBuffer, 16*i, 16, outputBuffer, 16*i); });
                    }
                    if (mode == CipherMode.CBC)
                    {
                        transform.TransformBlock(inputBuffer, 0, inputBuffer.Length, outputBuffer, 0);
                    }
                    writer.Write(outputBuffer);
                    total += inputBuffer.Length;
                }
                var dt = DateTime.Now - t;
                Console.WriteLine("{0} {1}", bufferSize,
                    (16*dt.TotalMilliseconds/total).ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}