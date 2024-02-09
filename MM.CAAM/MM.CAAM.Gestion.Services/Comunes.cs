using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.Gestion.Services 
{
    public static class Com
    {
        public static readonly string KeyEncript = "d/pThAB45Fp#:S:3";
        private static readonly byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };

        public enum Roles
        {
            ADMINISTRADOR = 1,
            JEFE = 2,
            OPERADOR = 3,
            PACIENTE = 4
        }

        public enum GradoEducacion
        {
            DOCTORADO = 1,
            MAESTRIA = 2,
            LICENCIATURA = 3,
            BACHILLERATO = 4,
            SECUNDARIA = 5,
            PRIMARIA = 6
        }

        public enum EstadoVida
        {
            ACTIVO = 1,
            INACTIVO = 2
        }

        public enum TipoUsuario
        {
            PRIVADO = 1,
            EMPRESA = 2
        }

        public enum EstadoCivil
        {
            SOLTERO = 1,
            CASADO = 2,
            UNIONLIBRE = 3,
            SEPARADO = 4,
            DIVORCIADO = 5,
            VIUDO = 6
        }

        public enum Genero
        {
            MUJER = 1,
            HOMBRE = 2,
            NOBINARIO = 3,
            PREFIERONODECIRLO = 4,
            OTRO = 5
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

        /// <summary>
        /// Compara si es igual la contraseña encriptada contra enviado por el usuario
        /// </summary>
        /// <param name="hashedPassword">La hashedPassword que está almacenada en la base de datos (password + salt)</param>
        /// <param name="password">El password que tecleó el usuario</param>
        /// /// <param name="password">El salt que se guardo en la base datos</param>
        public static bool VerifyHashedPassword(string hashedPassword, string password, string salt)
        {
            var hash = HashPassword(password, salt);

            return hashedPassword == hash;
        }

        public static string HashPassword(string password, string salt)
        {
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            var hash = KeyDerivation.Pbkdf2(
                            password: password,
                            salt: Convert.FromBase64String(salt),
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8);

            var hashedPassword = Convert.ToBase64String(hash);

            return hashedPassword;
        }

        public static string GenerateSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] byteSalt = new byte[256 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(byteSalt);
            }

            var salt = Convert.ToBase64String(byteSalt);

            return salt;
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

        

        #region OLD
        public static string DecryptorOld(string stringToDecrypt)
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

        public static string DecryptorOld(this string stringToDecrypt, string keyEncript)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(keyEncript.Substring(0, 8));
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

        public static string EncryptorOld(string stringToEncrypt)
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

        public static string EncryptorOld(this string stringToEncrypt, string keyEncript)
        {
            try
            {
                var key = Encoding.UTF8.GetBytes(keyEncript.Substring(0, 8));
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
        #endregion
    }
}
