using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using ManyMonkeys.Cryptography;

namespace TwofishTest
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestTwofish
	{
		/*
		/// <summary>
		/// </summary>
		*/

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <param name="args">the program arguments</param>
		[STAThread]
		static void Main(string[] args)
		{
			// these are the ECB Tests
			byte[] PT128 =			{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
			byte[] PT256 =			{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};

			byte[] Key128 =			{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
			byte[] CT128 =			{0x9F,0x58,0x9F,0x5C,0xF6,0x12,0x2C,0x32,0xB6,0xBF,0xEC,0x2F,0x2A,0xE8,0xC3,0x5A};

			byte[] Key192 =			{0x01,0x23,0x45,0x67,0x89,0xAB,0xCD,0xEF,0xFE,0xDC,0xBA,0x98,0x76,0x54,0x32,0x10,0x00,0x11,0x22,0x33,0x44,0x55,0x66,0x77};
			byte[] CT192 =			{0xCF,0xD1,0xD2,0xE5,0xA9,0xBE,0x9C,0xDF,0x50,0x1F,0x13,0xB8,0x92,0xBD,0x22,0x48};

			byte[] Key256 =			{0x01,0x23,0x45,0x67,0x89,0xAB,0xCD,0xEF,0xFE,0xDC,0xBA,0x98,0x76,0x54,0x32,0x10,0x00,0x11,0x22,0x33,0x44,0x55,0x66,0x77,0x88,0x99,0xAA,0xBB,0xCC,0xDD,0xEE,0xFF};
			byte[] CT256 =			{0x37,0x52,0x7B,0xE0,0x05,0x23,0x34,0xB8,0x9F,0x0C,0xFC,0xCA,0xE8,0x7C,0xFA,0x20};

			TestTwofishECB(ref Key128, ref PT128, ref CT128);
			TestTwofishECB(ref Key192, ref PT128, ref CT192);
			TestTwofishECB(ref Key256, ref PT128, ref CT256);  

			TestTwofishCBC(ref Key128, ref PT256, ref PT128, ref CT128);
			TestTwofishCBC(ref Key192, ref PT256, ref PT128, ref CT192);
			TestTwofishCBC(ref Key256, ref PT256, ref PT128, ref CT256);

			Cascade(ref Key128, ref Key256);

		}

		/// <summary>
		/// This encrypts our data using twofish and then converts to base64 and then reverses the process 
		/// </summary>
		/// <param name="Key">The Key to use for the encryption stage</param>
		/// <param name="plainText">The plain text to encrypt and encode and then to compare when it has been decoded and decrypted</param>
		static void Cascade(ref byte[] Key, ref byte[] plainText)
		{
			Twofish fish = new Twofish();

			fish.Mode = CipherMode.ECB;

			System.IO.MemoryStream ms = new System.IO.MemoryStream();

			// create an encoder
			ICryptoTransform encode = new ToBase64Transform();

			//create Twofish Encryptor from this instance
			ICryptoTransform encrypt = fish.CreateEncryptor(Key,plainText); // we use the plainText as the IV as in ECB mode the IV is not used

			// we have to work backwords defining the last link in the chain first
			CryptoStream cryptostreamEncode = new CryptoStream(ms,encode,CryptoStreamMode.Write);
			CryptoStream cryptostream = new CryptoStream(cryptostreamEncode,encrypt,CryptoStreamMode.Write);

			// or we could do this as we don't need to use cryptostreamEncode
			//CryptoStream cryptostream = new CryptoStream(new CryptoStream(ms,encode,CryptoStreamMode.Write), 
			//										encrypt,CryptoStreamMode.Write);


			cryptostream.Write(plainText,0,plainText.Length);


			cryptostream.Close();

			//long pos = ms.Position; // our stream is closed so we cannot find out what the size of the buffer is - daft
			byte[] bytOut = ms.ToArray();

			// and now we undo what we did

			// create a decoder
			ICryptoTransform decode = new FromBase64Transform();

			//create DES Decryptor from our des instance
			ICryptoTransform decrypt = fish.CreateDecryptor(Key,plainText);

			System.IO.MemoryStream msD = new System.IO.MemoryStream();

			//create crypto stream set to read and do a Twofish decryption transform on incoming bytes
			CryptoStream cryptostreamD = new CryptoStream(msD,decrypt,CryptoStreamMode.Write);
			CryptoStream cryptostreamDecode = new CryptoStream(cryptostreamD,decode,CryptoStreamMode.Write);

			// again we could do the following
			//CryptoStream cryptostreamDecode = new CryptoStream(new CryptoStream(msD,decrypt,CryptoStreamMode.Write),
			//											decode,CryptoStreamMode.Write);


			//write out the decrypted stream
			cryptostreamDecode.Write(bytOut,0,bytOut.Length); 

			cryptostreamDecode.Close();

			byte[] bytOutD = msD.ToArray(); // we should now have our plain text back			

			for (int i=0;i<plainText.Length;i++)
			{
				if (bytOutD[i] != plainText[i])
				{
					Trace.Write("Plaintext match failure");
					break;
				}
			}
		}

		/// <summary>
		/// Test the twofish cipher in ECB mode
		/// </summary>
		/// <param name="Key">The used to encrypt the data.</param>
		/// <param name="plainText">The plain text.</param>
		/// <param name="cryptText">The encrypted text to be used for comparison.</param>
		static void TestTwofishECB(ref byte[] Key, ref byte[] plainText, ref byte[] cryptText)
		{
			Twofish fish = new Twofish();

			fish.Mode = CipherMode.ECB;

			System.IO.MemoryStream ms = new System.IO.MemoryStream();

			//create Twofish Encryptor from this instance
			ICryptoTransform encrypt = fish.CreateEncryptor(Key,plainText); // we use the plainText as the IV as in ECB mode the IV is not used

			//Create Crypto Stream that transforms file stream using twofish encryption
			CryptoStream cryptostream = new CryptoStream(ms,encrypt,CryptoStreamMode.Write);

			//write out Twofish encrypted stream
			cryptostream.Write(plainText,0,plainText.Length);

			cryptostream.Close();

			byte[] bytOut = ms.ToArray();

			for (int i=0;i<cryptText.Length;i++)
			{
				if (bytOut[i] != cryptText[i])
				{
					Trace.Write("Cryptext match failure");
					break;
				}
			}

			//create Twofish Decryptor from our twofish instance
			ICryptoTransform decrypt = fish.CreateDecryptor(Key,plainText);

			System.IO.MemoryStream msD = new System.IO.MemoryStream();

			//create crypto stream set to read and do a Twofish decryption transform on incoming bytes
			CryptoStream cryptostreamDecr = new CryptoStream(msD ,decrypt,CryptoStreamMode.Write);

			//write out Twofish encrypted stream
			cryptostreamDecr.Write(bytOut,0,bytOut.Length);

			cryptostreamDecr.Close();

			byte[] bytOutD = msD.GetBuffer();

			for (int i=0;i<plainText.Length;i++)
			{
				if (bytOutD[i] != plainText[i])
				{
					Trace.Write("Plaintext match failure");
					break;
				}
			}
		}

		/// <summary>
		/// Test the twofish cipher in ECB mode
		/// </summary>
		/// <param name="Key">The used to encrypt the data.</param>
		/// <param name="plainText">The plain text.</param>
		/// <param name="cryptText">The encrypted text to be used for comparison.</param>
		static void TestTwofishCBC(ref byte[] Key, ref byte[] plainText, ref byte[] iv, ref byte[] cryptText)
		{
			Twofish fish = new Twofish();

			fish.Mode = CipherMode.CBC;

			System.IO.MemoryStream ms = new System.IO.MemoryStream();

			//create Twofish Encryptor from this instance
			ICryptoTransform encrypt = fish.CreateEncryptor(Key,iv); // we use the plainText as the IV as in ECB mode the IV is not used

			//Create Crypto Stream that transforms file stream using twofish encryption
			CryptoStream cryptostream = new CryptoStream(ms,encrypt,CryptoStreamMode.Write);

			//write out Twofish encrypted stream
			cryptostream.Write(plainText,0,plainText.Length);

			cryptostream.Close();

			byte[] bytOut = ms.ToArray();

/*
 			// check the first block only

			for (int i=0;i<cryptText.Length;i++)
			{
				if (bytOut[i] != cryptText[i])
				{
					Trace.Write("Cryptext match failure\n");
					break;
				}
			}
*/
			//create Twofish Decryptor from our twofish instance
			ICryptoTransform decrypt = fish.CreateDecryptor(Key,iv);

			System.IO.MemoryStream msD = new System.IO.MemoryStream();

			//create crypto stream set to read and do a Twofish decryption transform on incoming bytes
			CryptoStream cryptostreamDecr = new CryptoStream(msD ,decrypt,CryptoStreamMode.Write);

			//write out Twofish encrypted stream
			cryptostreamDecr.Write(bytOut,0,bytOut.Length);

			cryptostreamDecr.Close();

			byte[] bytOutD = msD.GetBuffer();

			// check
			for (int i=0;i<plainText.Length;i++)
			{
				if (bytOutD[i] != plainText[i])
				{
					Trace.Write("Plaintext match failure\n");
					break;
				}
			}
		}
	}
}
