using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;

namespace Common.Encryption {


	/// <summary>
	/// DES加密辅助类
	/// </summary>
	public sealed class DESHelper {

		//private readonly static String sKey = "HNHBThpc";
        //private readonly static String sKey = "三同时监管平台V1.0";
		//private readonly static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
		private readonly static string DESKey = "三同时监管平台V1.0";

		internal static string Encrypt(string pToEncrypt) {			
			String Result = "";
			if (String.IsNullOrEmpty(pToEncrypt)) return Result;
			byte[] encData_byte = new byte[pToEncrypt.Length];
			encData_byte = System.Text.Encoding.UTF8.GetBytes(pToEncrypt);
			Result = Convert.ToBase64String(encData_byte);
			return Result;
			/*DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
			byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
			provider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			provider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			StringBuilder ret = new StringBuilder();
			foreach (byte b in ms.ToArray()) {
				ret.AppendFormat("{0:X2}", b);
			}
			Result = ret.ToString();
			cs.Close();
			return Result;*/
		}

		/// <summary> 
		/// 解密。 
		/// </summary> 
		internal static string Decrypt(string pToDecrypt) {
			String Result = "";
			if (String.IsNullOrEmpty(pToDecrypt)) return Result;
			try {
				System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
				System.Text.Decoder utf8Decode = encoder.GetDecoder();
				byte[] todecode_byte = Convert.FromBase64String(pToDecrypt);
				int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
				char[] decoded_char = new char[charCount];
				utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
				Result = new String(decoded_char);
				return Result;
			}
			catch{
				//throw new Exception("Error in base64Decode" + e.Message);
				return "";
			}
			/*DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
			byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
			for (int x = 0; x < pToDecrypt.Length / 2; x++) {
				int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}
			provider.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			provider.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();			
			Result= Encoding.Default.GetString(ms.ToArray());
			cs.Close();
			return Result;*/
		}

		/// <summary>
		/// 3DES加密
		/// </summary>
		/// <param name="a_strString"></param>
		/// <param name="a_strKey"></param>
		/// <returns></returns>
		public static string Encrypt3DES(string a_strString) {
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			DES.Key = Encoding.Default.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(DESKey, "md5").Substring(0, 24));
			DES.Mode = CipherMode.ECB;
			ICryptoTransform DESEncrypt = DES.CreateEncryptor();
			byte[] Buffer = Encoding.Default.GetBytes(a_strString);
			return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

		/// <summary>
		/// 3DES解密
		/// </summary>
		/// <param name="a_strString"></param>
		/// <param name="a_strKey"></param>
		/// <returns></returns>
		public static string Decrypt3DES(string a_strString) {
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			DES.Key = Encoding.Default.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(DESKey, "md5").Substring(0, 24));
			DES.Mode = CipherMode.ECB;
			DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
			ICryptoTransform DESDecrypt = DES.CreateDecryptor();
			string result = "";
			try {
				byte[] Buffer = Convert.FromBase64String(a_strString);
				result = Encoding.Default.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));			
			}
			catch (Exception) {
				return "";
			}
			return result;

		}

		#region Base64加密解密算法实现

		/// <summary>
		/// Base64加密
		/// </summary>
		/// <param name="Message"></param>
		/// <returns></returns>
		public static string Base64Code(string Message) {
			byte[] encData_byte = new byte[Message.Length];
			encData_byte = System.Text.Encoding.UTF8.GetBytes(Message);
			string encodedData = Convert.ToBase64String(encData_byte);
			return encodedData;
		}

		/// <summary>
		/// Base64解密
		/// </summary>
		/// <param name="Message"></param>
		/// <returns></returns>
		public static string Base64Decode(string Message) {
			try {
				System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
				System.Text.Decoder utf8Decode = encoder.GetDecoder();
				byte[] todecode_byte = Convert.FromBase64String(Message);
				int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
				char[] decoded_char = new char[charCount];
				utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
				string result = new String(decoded_char);
				return result;
			}
			catch (Exception e) {
				throw new Exception("Error in base64Decode" + e.Message);
			}
		}
		#endregion
	}
}
