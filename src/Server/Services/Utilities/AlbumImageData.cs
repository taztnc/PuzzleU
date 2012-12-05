using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
    public class AlbumImageData
    {
        public const string IMAGE_DATA_ELEMENT_TAG = "image";

        private const string IMAGE_DATA_ATTRIBUTE_NAME = "name";
        private const string IMAGE_DATA_ATTRIBUTE_URL = "url";
        private const string IMAGE_DATA_ATTRIBUTE_ALBUM_ID = "albumId";

        public AlbumImageData(string name, string url, int albumId)
        {
            Name = name;
            URL = url;
            AlbumId = albumId;
        }

        public AlbumImageData(XmlElement imageElement)
        {
            Name = imageElement.Attributes[IMAGE_DATA_ATTRIBUTE_NAME].Value;
            URL = imageElement.Attributes[IMAGE_DATA_ATTRIBUTE_URL].Value;
            AlbumId = int.Parse(imageElement.Attributes[IMAGE_DATA_ATTRIBUTE_ALBUM_ID].Value);
        }

        public string Name { get; set; }
        public string URL { get; set; }
        public int AlbumId { get; set; }

        public XmlElement CreateXmlElement(ref XmlDocument doc)
        {
            XmlElement imageElement = doc.CreateElement(IMAGE_DATA_ELEMENT_TAG);

            // Attributes
            XmlAttribute nameAttribute = doc.CreateAttribute(IMAGE_DATA_ATTRIBUTE_NAME);
            nameAttribute.Value = Name;

            XmlAttribute urlAttribute = doc.CreateAttribute(IMAGE_DATA_ATTRIBUTE_URL);
            urlAttribute.Value = URL;

            XmlAttribute albumIdAttribute = doc.CreateAttribute(IMAGE_DATA_ATTRIBUTE_ALBUM_ID);
            albumIdAttribute.Value = AlbumId.ToString();

            imageElement.Attributes.Append(nameAttribute);
            imageElement.Attributes.Append(urlAttribute);
            imageElement.Attributes.Append(albumIdAttribute);

            return imageElement;
        }
    }
}
