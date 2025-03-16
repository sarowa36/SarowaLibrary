using System.Security.Cryptography;
using System.Text;

namespace SarowaLibrary.ToolsLayer.TripleDESCryption
{
    public class TripleDES
    {
        public readonly string DefaultKey;
        public TripleDES(string? defaultKey = null)
        {
            DefaultKey = defaultKey ?? "a29fa058-75df-4568-a050-a75af4f3cc9b";
        }
        public string Encrypt(string cipher)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(cipher);
            MD5 md5 = MD5.Create();
            var tripdes = System.Security.Cryptography.TripleDES.Create();
            tripdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.DefaultKey));
            tripdes.Mode = CipherMode.ECB;
            tripdes.Padding = PaddingMode.PKCS7;
            var transform = tripdes.CreateEncryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }
        public string Decrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            MD5 md5 = MD5.Create();
            var tripdes = System.Security.Cryptography.TripleDES.Create();
            tripdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.DefaultKey));
            tripdes.Mode = CipherMode.ECB;
            tripdes.Padding = PaddingMode.PKCS7;
            var transform = tripdes.CreateDecryptor();
            var result = transform.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(result);
        }
        public static string Decrypt(string cipher, string? key=null) => new TripleDES(key).Decrypt(cipher);
        public static string Encrypt(string text, string? key = null) => new TripleDES(key).Encrypt(text);
    }
}
