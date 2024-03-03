using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MM.CAAM.Admin.Web
{
    public class Com
    {
        public static readonly string KeyEncript = "d/pThAB45Fp#:S:3";
        private static readonly byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };

        public static string GetPropertyEnum<T>(Enum @enum)
        {
            if (@enum == null)
                return null;

            string description = @enum.ToString();
            FieldInfo fieldInfo = @enum.GetType().GetField(description);

            if (typeof(T) == typeof(DescriptionAttribute))
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Any())
                    description = attributes[0].Description;
            }

            if (typeof(T) == typeof(DefaultValueAttribute))
            {
                var attributes = (DefaultValueAttribute[])fieldInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                if (attributes.Any())
                    description = attributes[0].Value.ToString();
            }

            return description;
        }

        public static string RenombrarSiExisteArchivo(string full_path)
        {
            string fileName = Path.GetFileName(full_path);
            string fileExtension = Path.GetExtension(full_path);
            string fileDirectoryName = Path.GetDirectoryName(full_path);
            string tmp_filename = fileName;
            int contador = 1;

            //if (!Directory.Exists(fileDirectoryName))
            //{
            //    Directory.CreateDirectory(fileDirectoryName);
            //}

            while (File.Exists(Path.Combine(fileDirectoryName, tmp_filename)))
            {
                tmp_filename = fileName.Split('.')[0] + "_Copy_" + contador + fileExtension;
                contador++;
            }

            return tmp_filename.Replace(" ", "_");
        }

        public static string Decryptor(string stringToDecrypt)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(KeyEncript.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                var inputByteArray = Base64UrlDecode(stringToDecrypt);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string Encryptor(string stringToEncrypt)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(KeyEncript.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                var inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Base64UrlEncode(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string Base64UrlEncode(byte[] arg)
        {
            string s = Convert.ToBase64String(arg); // Regular base64 encoder
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            s = s.Replace('/', '_'); // 63rd char of encoding
            return s;
        }

        public static byte[] Base64UrlDecode(string arg)
        {
            string s = arg;
            s = s.Replace('-', '+'); // 62nd char of encoding
            s = s.Replace('_', '/'); // 63rd char of encoding
            switch (s.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: s += "=="; break; // Two pad chars
                case 3: s += "="; break; // One pad char
                default:
                    throw new System.Exception("Illegal base64url string!");
            }
            return Convert.FromBase64String(s); // Standard base64 decoder
        }

        public static DateTime GetUtcNowByZone()
        {
            DateTime timeUtc = DateTime.UtcNow;
            DateTime cstTime = default;
            try
            {
                //TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time (Mexico)");
                cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                //Console.WriteLine("The date and time are {0} {1}.", cstTime, cstZone.IsDaylightSavingTime(cstTime) ? cstZone.DaylightName : cstZone.StandardName);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error [Ahorita] {exc}");
            }

            return cstTime;
        }
    }
}
