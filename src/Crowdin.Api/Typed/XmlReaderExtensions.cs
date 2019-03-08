using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
    internal static class XmlReaderExtensions
    {
        public static void ReadToNextRequiredSibling(this XmlReader reader, String elementName)
        {
            if (!reader.ReadToNextSibling(elementName))
            {
                throw CreateMissedElementException(reader, elementName);
            }
        }

        public static Boolean ReadRequiredSiblingElementContentAsBoolean(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsBoolean();
        }

        public static Int32 ReadRequiredSiblingElementContentAsInt(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsInt();
        }

        public static Int32? ReadOptionalSiblingElementContentAsInt(this XmlReader reader, String elementName)
        {
            if (reader.ReadToNextSibling(elementName) && !reader.IsEmptyElement)
            {
                return reader.ReadElementContentAsInt();
            }
            return null;
        }

        public static String ReadRequiredSiblingElementContentAsString(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsString();
        }

        public static T ReadElementContentAsEnum<T>(this XmlReader reader) where T: Enum
        {
            var enumString = reader.ReadElementContentAsString();
            T enumValue = (T)Enum.Parse(typeof(T), enumString, true);
            return enumValue;
        }

        public static T ReadRequiredSiblingElementContentAsEnum<T>(this XmlReader reader, String elementName) where T : Enum
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsEnum<T>();
        }

        public static DateTime ReadElementContentAsIsoDateTime(this XmlReader reader)
        {
            var dateTimeString = reader.ReadElementContentAsString();
            DateTime dateTime = DateTime.Parse(dateTimeString, null, DateTimeStyles.RoundtripKind);
            return dateTime;
        }

        public static DateTime ReadRequiredSiblingElementContentAsIsoDateTime(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsIsoDateTime();
        }

        public static DateTime? ReadOptionalSiblingElementContentAsIsoDateTime(this XmlReader reader, String elementName)
        {
            if (reader.ReadToNextSibling(elementName) && !reader.IsEmptyElement)
            {
                return reader.ReadElementContentAsIsoDateTime();
            }
            return null;
        }

        public static Uri ReadElementContentAsUri(this XmlReader reader)
        {
            var uriString = reader.ReadElementContentAsString();
            Uri uri = new Uri(uriString);
            return uri;
        }

        public static Uri ReadRequiredSiblingElementContentAsUri(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementContentAsUri();
        }

        public static T ReadElementSubtreeAsObject<T>(this XmlReader reader, String elementName)
        {
            var objectSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(elementName));
            using (XmlReader objectReader = reader.ReadSubtree())
            {
                var @object = (T)objectSerializer.Deserialize(objectReader);
                return @object;
            }
        }

        public static T ReadRequiredSiblingElementSubtreeAsObject<T>(this XmlReader reader, String elementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            return reader.ReadElementSubtreeAsObject<T>(elementName);
        }

        public static IEnumerable<T> ReadSiblingElementsAsCollection<T>(this XmlReader reader, String itemElementName)
        {
            var itemSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(itemElementName));
            while (reader.ReadToNextSibling(itemElementName))
            {
                using (XmlReader itemReader = reader.ReadSubtree())
                {
                    var item = (T)itemSerializer.Deserialize(itemReader);
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> ReadRequiredSiblingElementSubtreeAsCollection<T>(this XmlReader reader, String elementName, String itemElementName)
        {
            reader.ReadToNextRequiredSibling(elementName);
            reader.ReadStartElement();
            return reader.ReadSiblingElementsAsCollection<T>(itemElementName);
        }

        public static IEnumerable<T> ReadRequiredSiblingElementSubtreeAsCollection<T>(this XmlReader reader, String elementName, String itemElementName, Func<XmlReader, T> deserializer)
        {
            reader.ReadToNextRequiredSibling(elementName);
            reader.ReadStartElement();
            while (reader.ReadToNextSibling(itemElementName))
            {
                using (XmlReader itemReader = reader.ReadSubtree())
                {
                    T item = deserializer(itemReader);
                    yield return item;
                }
            }
        }

        private static XmlException CreateMissedElementException(XmlReader reader, String elementName)
        {
            var message = $"Missed expected element '{elementName}'";
            if (reader is IXmlLineInfo xmlLineInfo)
            {
                return new XmlException(message, null, xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
            }
            return new XmlException(message);
        }
    }
}
