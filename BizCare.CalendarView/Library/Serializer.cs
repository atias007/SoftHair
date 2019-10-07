using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BizCare.Calendar.Library
{
    internal class Serializer
    {
        #region Private Functions

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static string Utf8ByteArrayToString(byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUtf8ByteArray(string pXmlString)
        {
            var encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        #endregion Private Functions

        #region Public Function

        /// <summary>
        /// Serialize an object into an XML string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string SerializeObject<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof (T));
                var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                var stream = (MemoryStream) xmlTextWriter.BaseStream;
                stream.Position = 0;
                var xmlString = Utf8ByteArrayToString(stream.ToArray());
                return xmlString;
            }
        }

        /// <summary>
        /// Reconstruct an object from an XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        internal static T DeserializeObject<T>(string xml)
        {
            using (var memoryStream = new MemoryStream(StringToUtf8ByteArray(xml)))
            {
                var xs = new XmlSerializer(typeof(T));
                memoryStream.Position = 0;
                return (T) xs.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// Clones the specified obj.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        internal static T Clone<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof (T));
                var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                var stream = (MemoryStream) xmlTextWriter.BaseStream;
                stream.Position = 0;
                var result = (T)xs.Deserialize(stream);
                return result;
            }
        }

        /// <summary>
        /// Serializes the net data contract object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        internal static string SerializeNetDataContractObject<T>(T obj)
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

        /// <summary>
        /// Deserializes the net data contract object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static T DeserializeNetDataContractObject<T>(string xml)
        {
            using (var memoryStream = new MemoryStream(StringToUtf8ByteArray(xml)))
            {
                var serializer = new NetDataContractSerializer();
                memoryStream.Position = 0;
                var result = (T) serializer.Deserialize(memoryStream);
                return result;
            }
        }

        /// <summary>
        /// Clones the net data contract.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static T CloneNetDataContract<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new NetDataContractSerializer();
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                var result = (T)serializer.Deserialize(stream);
                return result;
            }
        }

        #endregion
    }
}
