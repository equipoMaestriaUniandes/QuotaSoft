namespace Quota.Infra.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    public static class UtilRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// The deserialize xml.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T DeserializeXml<T>(this string value)
        {
            var xmldeserializer = new XmlSerializer(typeof(T));

            using (var reader = XmlReader.Create(new StringReader(value)))
            {
                return (T)xmldeserializer.Deserialize(reader);
            }
        }

        public static T DeserializeXml<T>(this string value, string root)
        {
            var xmldeserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));

            using (var reader = XmlReader.Create(new StringReader(value)))
            {
                return (T)xmldeserializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// The serializar json.
        /// </summary>
        /// <param name="resultado">
        /// The resultado.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string SerializeJson(object resultado)
        {
            return JsonConvert.SerializeObject(resultado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="customObject"></param>
        /// <param name="decorateName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetPropertiesWhitoutAttributes<T>(this T customObject, string decorateName)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            List<string> properties = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                var tieneDecorate = false;
                foreach (object attr in attrs)
                {
                    if (attr.GetType().Name.ToLower().Equals(decorateName.ToLower()))
                    {
                        tieneDecorate = true;
                        break;
                    }
                }
                if (!tieneDecorate)
                {
                    properties.Add(prop.Name);
                }
            }
            return properties;
        }
    }
}
