using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ClientManage.Interfaces
{
    public static class SerializeHelper
    {
        #region DataContract Serialization

        public static T MakeDataContractClone<T>(T objectToSerialize)
        {
            var xml = DataContractSerialize(objectToSerialize);
            var result = DataContractDeserialize<T>(xml);
            return result;
        }

        public static string DataContractSerialize<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new NetDataContractSerializer();
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                var xmlString = Utf8ByteArrayToString(stream.ToArray());
                return xmlString;
            }
        }

        public static T DataContractDeserialize<T>(string xml)
        {
            var byteArray = Encoding.UTF8.GetBytes(xml);
            using (var stream = new MemoryStream(byteArray))
            {
                stream.Position = 0;
                var serializer = new NetDataContractSerializer();
                var result = (T)serializer.Deserialize(stream);
                return result;
            }
        }

        #endregion DataContract Serialization

        #region Binary Serialization

        public static Stream BinarySerialize(object entity)
        {
            var stream = new MemoryStream();
            var bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, entity);
            stream.Position = 0;
            return stream;
        }

        public static T MakeBinaryClone<T>(T objectToSerialize)
        {
            using (var stream = new MemoryStream())
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, objectToSerialize);
                stream.Position = 0;
                var result = (T)bformatter.Deserialize(stream);
                return result;
            }
        }

        public static T BinaryDeserialize<T>(Stream stream)
        {
            var bformatter = new BinaryFormatter();
            var result = (T)bformatter.Deserialize(stream);
            return result;
        }

        public static T BinaryDeserialize<T>(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Binder = new Binder();
                var result = (T)bformatter.Deserialize(stream);
                return result;
            }
        }

        #endregion Binary Serialization

        #region Xml Serialization

        public static T MakeXmlClone<T>(T objectToSerialize)
        {
            var xml = XmlSerialize(objectToSerialize);
            return XmlDeserialize<T>(xml);
        }

        public static string XmlSerialize<T>(T entity)
        {
            return XmlSerialize(entity, SerializeOptions.Empty);
        }

        public static string XmlSerialize<T>(T entity, SerializeOptions options)
        {
            return XmlSerialize(typeof(T), entity, options);
        }

        public static string XmlSerialize(Type type, object entity, SerializeOptions options)
        {
            if (options == null)
            {
                options = SerializeOptions.Empty;
            }

            var xs = new XmlSerializer(type);
            var settings = options.GetXmlWriterSettings();

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    if (settings.OmitXmlDeclaration)
                    {
                        var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                        xs.Serialize(writer, entity, ns);
                    }
                    else
                    {
                        xs.Serialize(writer, entity);
                    }
                    var xmlString = Utf8ByteArrayToString(stream.ToArray());
                    if (!string.IsNullOrEmpty(xmlString) && xmlString[0] != '<')
                    {
                        xmlString = xmlString.Substring(xmlString.IndexOf("<"));
                    }
                    return xmlString;
                }
            }
        }

        public static T XmlDeserialize<T>(string xml)
        {
            return XmlDeserialize<T>(xml, Encoding.UTF8);
        }

        public static T XmlDeserialize<T>(string xml, Encoding encoding)
        {
            var xs = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream(StringToByteArray(xml, encoding));
            return (T)xs.Deserialize(memoryStream);
        }

        #endregion Xml Serialization

        #region Private

        private static string Utf8ByteArrayToString(byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static Byte[] StringToByteArray(string pXmlString, Encoding encoding)
        {
            var byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        #endregion Private
    }

    public class SerializeOptions
    {
        public SerializeOptions()
        {
            Encoding = Encoding.UTF8;
        }

        public static SerializeOptions Empty
        {
            get
            {
                return new SerializeOptions();
            }
        }

        public bool OmitXmlDeclaration { get; set; }

        public Encoding Encoding { get; set; }

        public bool Indent { get; set; }

        internal XmlWriterSettings GetXmlWriterSettings()
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = OmitXmlDeclaration,
                Encoding = Encoding.UTF8,
                Indent = true
            };
            return settings;
        }
    }

    public class Binder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type tyType = null;

            var sShortAssemblyName = assemblyName.Split(',')[0];
            var ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var ayAssembly in ayAssemblies)
            {
                if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
                {
                    tyType = ayAssembly.GetType(typeName);
                    break;
                }
            }

            return tyType;
        }
    }
}