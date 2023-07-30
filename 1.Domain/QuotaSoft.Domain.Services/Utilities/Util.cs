namespace Quota.Domain.Services.Utilities
{
    using EncryptConnectionString;
    using Quota.Domain.Entities.Config; 
    using Quota.Domain.Entities.ErrorHandler;
    using Quota.Domain.Entities.Response;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;

    public static class Util
    {
        public static GeneralResponse ManageResponse(object information = null, bool successful = true, string message = null)
        {
            return new GeneralResponse
            {
                isSuccess = successful,
                result = information,
                message = message
            };
        }

        public static GeneralResponse ManageFailureResponse(string message = null)
        {
            return new GeneralResponse
            {
                isSuccess = false,
                result = new ErrorDetails
                {
                    ResultCode = "API_INTERNAL_ERROR",
                    ResultMsg = !string.IsNullOrEmpty(message) ? message : "Ha ocurrido un error inesperado"
                }
            };
        }

        public static GeneralResponse ManageException(Exception ex,  string source, long startDate, object request, AppSettings dataSettings)
        {
            return ManageFailureResponse(ex.Message);
        }

      
        public static GeneralResponse ManageExceptionHandler( string source, object response, AppSettings dataSettings, string errorMessage)
        {
            return ManageFailureResponse(errorMessage);
        }

        public static long GetRequestStartDate()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static string GetCrypt(string data)
        {
            CryptLib _crypt = new CryptLib();
            string iv = "75npchtk5DpbTGbB";
            string key = CryptLib.getHashSha256("bGZkYjIwMTgq", 32);
            string connString = data ?? string.Empty;
            return _crypt.encrypt(connString, key, iv);
        }

        public static string GetDecrypt(string data)
        {
            CryptLib _crypt = new CryptLib();
            string iv = "75npchtk5DpbTGbB";
            string key = CryptLib.getHashSha256("bGZkYjIwMTgq", 32);
            string connString = data ?? string.Empty;
            return _crypt.decrypt(connString, key, iv);
        }

        /// <summary>
        /// The ConvertirDecimal
        /// </summary>
        /// <param name="valor">The valor<see cref="object"/></param>
        /// <param name="posicionesDecimales">The posicionesDecimales<see cref="int"/></param>
        /// <returns>The <see cref="decimal?"/></returns>
        public static decimal? ConvertirDecimal(this object valor, int posicionesDecimales = 0)
        {
            if (string.IsNullOrWhiteSpace(valor.ToString()))
            {
                return null;
            }
            return posicionesDecimales != 0 ? Math.Round(Convert.ToDecimal(valor, CultureInfo.InvariantCulture), posicionesDecimales) :
                Convert.ToDecimal(valor, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The BetweenDate
        /// </summary>
        /// <param name="value">The value<see cref="DateTime?"/></param>
        /// <param name="minimum">The minimum<see cref="DateTime"/></param>
        /// <param name="maximum">The maximum<see cref="DateTime"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool BetweenDate(this DateTime? value, DateTime minimum, DateTime maximum)
        {
            if (!value.HasValue)
            {
                return false;
            }
            return value >= minimum && value <= maximum;
        }

        /// <summary>
        /// The BetweenDate
        /// </summary>
        /// <param name="value">The value<see cref="DateTime"/></param>
        /// <param name="minimum">The minimum<see cref="DateTime"/></param>
        /// <param name="maximum">The maximum<see cref="DateTime"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool BetweenDate(this DateTime value, DateTime minimum, DateTime maximum)
        {
            return value >= minimum && value <= maximum;
        }

        /// <summary>
        /// The ConvertirFecha
        /// </summary>
        /// <param name="valor">The valor<see cref="object"/></param>
        /// <returns>The <see cref="DateTime?"/></returns>
        public static DateTime? ConvertirFecha(this object valor)
        {
            if (string.IsNullOrWhiteSpace(valor.ToString()) || valor.ToString() == "0")
            {
                return null;
            }
            return DateTime.FromOADate(Convert.ToDouble(valor));
        }

        /// <summary>
        /// The ConvertirFechaFormato
        /// </summary>
        /// <param name="valor">The valor<see cref="string"/></param>
        /// <param name="format">The format<see cref="string"/></param>
        /// <returns>The <see cref="DateTime?"/></returns>
        public static DateTime? ConvertirFechaFormato(this string valor, string format)
        {
            DateTime fechaConversion;
            if (DateTime.TryParseExact(valor, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out fechaConversion))
            {
                return fechaConversion;
            }
            return null;
        }

        /// <summary>
        /// The AddIfNotNull
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lista">The lista<see cref="List{T}"/></param>
        /// <param name="newItem">The newItem<see cref="T"/></param>
        public static void AddIfNotNull<T>(this List<T> lista, T newItem)
        {
            if (newItem != null)
            {
                lista.Add(newItem);
            }
        }

        /// <summary>
        /// The CloneObjectSerializable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj<see cref="T"/></param>
        /// <returns>The <see cref="T"/></returns>
        public static T CloneObjectSerializable<T>(this T obj) where T : class
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Position = 0;
            object result = bf.Deserialize(ms);
            ms.Close();
            return (T)result;
        }

        /// <summary>
        /// The ConvertirPorcentaje
        /// </summary>
        /// <param name="valor">The valor<see cref="object"/></param>
        /// <param name="posicionesDecimales">The posicionesDecimales<see cref="int"/></param>
        /// <returns>The <see cref="decimal?"/></returns>
        public static decimal? ConvertirPorcentaje(this object valor, int posicionesDecimales = 0)
        {
            if (string.IsNullOrWhiteSpace(valor.ToString()))
            {
                return null;
            }
            valor = valor.ToString().Replace("%", string.Empty).ToString(CultureInfo.InvariantCulture).ToString(new NumberFormatInfo());
            return posicionesDecimales != 0 ? Math.Round(Convert.ToDecimal(valor, CultureInfo.InvariantCulture), posicionesDecimales) :
                Convert.ToDecimal(valor, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The ValidarEmail
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool ValidarEmail(this string email)
        {
            string formato;
            formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, formato))
            {
                if (Regex.Replace(email, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool EsNumerico(this string valor)
        {
            var numeroReferencia = 0;
            return int.TryParse(valor, out numeroReferencia);
        }

        public static bool ComparePassword(string pass1, string pass2)
        {
            const int hashByte = 16;
            const int cicloFor = 20;
            string savedPasswordHash = pass1;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, hashByte);
            var pbkdf2 = new Rfc2898DeriveBytes(pass2, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < cicloFor; i++)
            {
                if (hashBytes[i + hashByte] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathSource"></param>
        /// <param name="pathDestine"></param>
        /// <returns></returns>
        public static bool copyFile(string pathSource, string pathDestine)
        {
            bool isSuccess = false;
            if (File.Exists(pathSource))
            {
                try
                {
                    File.Copy(pathSource, pathDestine, true);
                    File.Delete(pathSource);
                    isSuccess = true;
                }
                catch
                {
                    isSuccess = false;
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DeleteFile(string path, string fileName)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(fileName)) return false;
            string _path = Path.Combine(path, fileName);
            try
            {
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }
                return !File.Exists(_path);
            }
            catch (Exception e)
            {
                //log.Info(e.Message, e);
                return false;
            }
        }

        public static byte[] ConvertFileToBytes(string path)
        {
            byte[] bytBytes;
            try
            {
                FileStream fs;
                fs = File.Open(path, FileMode.Open);
                bytBytes = new byte[fs.Length];
                fs.Read(bytBytes, 0, bytBytes.Length);
                fs.Close();
            }
            catch (Exception e)
            {
                bytBytes = null;
            }

            return bytBytes;
        }

        public static byte[] ConvertBytesToFile(string data, string path, string fileName)
        {
            byte[] bytBytes;
            try
            {
                bytBytes = Convert.FromBase64String(data);
                FileStream stream = new FileStream(path + fileName, FileMode.CreateNew);
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(bytBytes, 0, bytBytes.Length);
                writer.Close();
            }
            catch (Exception e)
            {
                bytBytes = null;
            }

            return bytBytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="byBytes"></param>
        /// <returns></returns>
        public static bool ConvertBytesToFile(string path, byte[] byBytes)
        {
            try
            {
                File.WriteAllBytes(path, byBytes);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string FileExists(string url, string extension)
        {
            string ret = string.Empty;
            try { 
           
            string[] files = System.IO.Directory.GetFiles(url);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    string ext = System.IO.Path.GetExtension(s);
                    if (ext.ToUpper() == "."+extension.ToUpper())
                    {
                        ret = s;
                    }
                }
            }
            }
            catch(Exception e) {}
            return ret;
        }
    }
}